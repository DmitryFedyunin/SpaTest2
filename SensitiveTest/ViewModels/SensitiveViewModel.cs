using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestSpa.ViewModels
{
    //история ответов
    public class SensitiveViewModel
    {
        //ответы экстрасенсов
        public List<Models.SensitiveAnswer> Answers { get; set; }

        //id экстрасенса
        public string Hash { get; set; }
    }
}