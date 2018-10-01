using TestSpa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestSpa.Services
{
    public class UserService
    {
        //нач данные
        internal void InitData()
        {
            HttpContext.Current.Application["Users"] = new List<UserAnswer>();
            HttpContext.Current.Application["UserIndex"] = 0;
        }

        //список ответов
        public List<UserAnswer> GetAnswers(string userHash)
        {
            var res = (List<UserAnswer>)HttpContext.Current.Application["Users"];
            return res.Where(u => u.UserHash == userHash).ToList();
        }

        //добавляем ответ пользователя
        public void AddUserAnswer(UserAnswer answer)
        {
            ((List<UserAnswer>)HttpContext.Current.Application["Users"]).Add(answer);
        }

        //получ id пользователя
        public int GetUserID()
        {
            var index = (int)HttpContext.Current.Application["UserIndex"];
            index++;
            HttpContext.Current.Application["UserIndex"] = index;
            return index;

        }

    }
}