using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestSpa.Models
{
    //экстрасенсы
    public class Sensitive
    {
       //имя
        public string Name;

        //правдивость
        public int Reliability;
        //кол-во ответов
        public int AnswerCount { get { return AnswerItems.Count; } }
        //список ответов
        public List<SensitiveAnswer> AnswerItems = new List<SensitiveAnswer>();
        //добавить ответ
        internal void AddAnswer(SensitiveAnswer answer)
        {
            AnswerItems.Add(answer);
        }
        //id экстрасенса
        public string Hash { get; set; }
    }
}