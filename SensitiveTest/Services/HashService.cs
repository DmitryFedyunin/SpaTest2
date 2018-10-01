using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace TestSpa.Services
{
    //md5 хеш
    public class HashService
    {
        static string GetMd5Hash(MD5 md5Hash, string input)
        {
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }
        public static string GetHashValue(string source)
        {
            string res = "";
            using (MD5 md5Hash = MD5.Create())
            {
                res = GetMd5Hash(md5Hash, source);
            }
            return res;
        }
    }
}