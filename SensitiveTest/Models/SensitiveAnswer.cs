using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestSpa.Models
{
    //ответ экстрасенса
    public class SensitiveAnswer
    {
        //его угаданное значение
        public int Value;
        //результат ответа true false
        public bool Result;
        //id теста
        public string QueryHash;


    }
}