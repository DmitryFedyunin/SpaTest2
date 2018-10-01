using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestSpa.ViewModels
{
    //ответы экстрасенсов
    public class SensitiveAnswerListViewModel
    {
        //список ответов
        public List<SensitiveAnswerViewModel> Items = new List<SensitiveAnswerViewModel>();

        //id теста
        public string QueryHash { get; set; }
    }
}