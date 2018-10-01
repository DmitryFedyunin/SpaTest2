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
    public class AnswerController : ApiController
    {
        
        // список ответов пользователя
        public UserAnswerListViewModel Get()
        {
            // идентификация через куки
            var cookie = Request.Headers.GetCookies("UserHash").FirstOrDefault();
            string userHash = cookie != null ? cookie["UserHash"].Value : "";

            UserService userService = new UserService();
            var vm = new UserAnswerListViewModel();
            if (!string.IsNullOrEmpty(userHash))
            {
                var answers = userService.GetAnswers(userHash);
                if (answers != null && answers.Count > 0)
                    foreach (var answer in answers)
                    {
                        var userAnswer =
                            new UserAnswerViewModel
                            {
                                Value = answer.Value,
                                Description = answer.Description
                            };
                        vm.Items.Add(userAnswer);
                    }
            }
            return vm;
        }
    }
}
