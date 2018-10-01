using TestSpa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestSpa.Services
{
    public class SensitiveService
    {
        //начальные данные об экстрасенсе 
        private List<Sensitive> GetNewSensitives()
        {
            var res = new List<Sensitive>();
            res.Add(new Sensitive
            {
                Hash = HashService.GetHashValue("1"),
                Name = "Экстрасенс 1",
                Reliability = 0,
            });
            res.Add(new Sensitive
            {
                Hash = HashService.GetHashValue("2"),
                Name = "Экстрасенс 2",
                Reliability = 0,
            });
            res.Add(new Sensitive
            {
                Hash = HashService.GetHashValue("3"),
                Name = "Экстрасенс 3",
                Reliability = 0,
            });
            res.Add(new Sensitive
            {
                Hash = HashService.GetHashValue("4"),
                Name = "Экстрасенс 4",
                Reliability = 0,
            });
            res.Add(new Sensitive
            {
                Hash = HashService.GetHashValue("5"),
                Name = "Экстрасенс 5",
                Reliability = 0,
            });
            return res;
        }

        //получ список экстрасенсов
        internal List<Sensitive> GetSensitives()
        {
            return (List<Sensitive>)HttpContext.Current.Application["Sensitives"];
        }

        //инициализация списка
        internal void InitData()
        {
            HttpContext.Current.Application["Sensitives"] = GetNewSensitives();
            HttpContext.Current.Application["RandomSensitiveIndex"] = 0;
        }
        
        internal List<Sensitive> GetRandomSensitives()
        {
            var sensitives = GetSensitives();
            var r = new Random();
            return sensitives.OrderBy(emp => Guid.NewGuid()).Take(5).ToList();
        }

        //номер тестиррования
        internal int GetRandomSensitiveIndex()
        {
            int index = (int)HttpContext.Current.Application["RandomSensitiveIndex"];
            index++;
            HttpContext.Current.Application["RandomSensitiveIndex"] = index;
            return index;
        }

        //данные об экстрасенсе
        internal Sensitive GetSensitive(string hash)
        {
            return GetSensitives().Where(s => s.Hash == hash).FirstOrDefault();
        }
    }
}