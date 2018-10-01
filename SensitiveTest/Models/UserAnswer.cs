using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestSpa.Models
{
    public class UserAnswer
    {
       //знач ответа
        public int Value;
        //результат ответа
        public bool Result;
        //описание ответа
        public string Description;
        //id теста
        public string QueryHash;
        //id пользователя
        public string UserHash;
    }
}