using TestSpa.FormModels;
using TestSpa.Services;
using TestSpa.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TestSpa.Controllers
{

    public class ValuesController : ApiController
    {
         // Получаем варианты экстрасенсов
        public SensitiveAnswerListViewModel Get()
        {
            var vm = new SensitiveAnswerListViewModel();
            SensitiveService sensitiveService = new SensitiveService();

            // Получаем список экстрасенсов
            var sensitives = sensitiveService.GetRandomSensitives();

            // задаем рандомные числа для экстрасенсов
            if (sensitives != null)
            {
                Random random = new Random();

                // запрос бд при помощи хеша
                string queryHash = HashService.GetHashValue(sensitiveService.GetRandomSensitiveIndex().ToString());
                vm.QueryHash = queryHash;
                foreach (var s in sensitives)
                {
                    var answer = new Models.SensitiveAnswer
                        {
                            Value = random.Next(10, 99),
                            QueryHash = queryHash
                        };
                    s.AddAnswer(answer);

                    vm.Items.Add(new SensitiveAnswerViewModel
                    {
                        Name = s.Name,
                        Value = answer.Value,
                    });

                }
            }
            return vm;
        }

        
        /// Ввод числа пользователем
        public AnswerResultViewModel Post([FromBody]ValueResultFormModel form)
        {
            var vm = new AnswerResultViewModel();

            UserService userService = new UserService();

            var cookie = Request.Headers.GetCookies("UserHash").FirstOrDefault();
            string userHash = cookie != null ? cookie["UserHash"].Value : HashService.GetHashValue(userService.GetUserID().ToString());

            // преобразуем в число
           int res = 0;
           Int32.TryParse(form.Value, out res);

            // проверяем диапозон
            if (res >= 10 && res <= 99)
            {
                var userAnswer = new Models.UserAnswer
                {
                    Value = res,
                    UserHash = userHash
                };

                SensitiveService sensitiveService = new SensitiveService();

                // проверка экстрасенсов
                var sensitives = sensitiveService.GetSensitives();
                foreach (var s in sensitives)
                {
                    var answer = s.AnswerItems.Where(a => a.QueryHash == form.QueryHash).FirstOrDefault();
                    if (answer != null)
                    {
                        if (answer.Value == res)
                        {
                            answer.Result = true;
                            s.Reliability++;
                            userAnswer.Result = true;
                            if (!string.IsNullOrEmpty(userAnswer.Description))
                                userAnswer.Description += ", ";
                            userAnswer.Description += s.Name;
                        }
                        else
                            s.Reliability--;
                    }
                }
                userService.AddUserAnswer(userAnswer);
            }
            else
            {
                vm.ErrorMessage = "Вы ввели не верное число...";
            }
            vm.UserHash = userHash;

            return vm;
        }
    }
}