using TestSpa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestSpa.ViewModels
{
    public class UserAnswerListViewModel
    {
        //ответы пользователя
        public List<UserAnswerViewModel> Items = new List<UserAnswerViewModel>();
    }
}