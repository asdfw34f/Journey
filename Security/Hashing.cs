// This is a personal academic project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using Journey.Data.MSSQL;
using Journey.MVVM.Models;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Journey.Security
{
    internal class Hashing
    {
        internal string GetHash(string password)
        {
            return Convert.ToHexString(MD5
            .Create().ComputeHash(Encoding.UTF8.GetBytes(password)));
        }

        internal bool EqualsLog(string password)
        {
            if (password == null)
            {
                return false;
            }

            password = GetHash(password);

            using ApplicationContext db = new();
            Users? user = db.Users
                .Where(u => u.Password == password).FirstOrDefault();
            return user != null;
        }
    }
}