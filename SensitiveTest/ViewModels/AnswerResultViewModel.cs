using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestSpa.ViewModels
{
    public class AnswerResultViewModel
    {
        //получ ошибки
        public string ErrorMessage { get; set; }

        //пользов id
        public string UserHash { get; set; }
    }
}