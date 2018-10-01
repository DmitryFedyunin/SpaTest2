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
    public class SensitiveController : ApiController
    {
        SensitiveService sensitiveService = new SensitiveService();

        
        // получаем список экстрасенсов
        public SensitiveListViewModel Get()
        {
            var vm = new SensitiveListViewModel();
            vm.Items = sensitiveService.GetSensitives();
            return vm;
        }

       
        // история догадок
        public SensitiveViewModel Get(string id)
        {
            var vm = new SensitiveViewModel
            {
                Hash = id
            };

            var sensitive = sensitiveService.GetSensitive(id);
            if (sensitive != null)
                vm.Answers = sensitive.AnswerItems;

            return vm;
        }

      
        // id экстрасенса
        public string Hash { get; set; }
    }
}
