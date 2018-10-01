using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestSpa.FormModels
{
    public class ValueResultFormModel
    {
       //число введенное пользователем
        public string Value { get; set; }
        // ид теста
        public string QueryHash { get; set; }
    }
}