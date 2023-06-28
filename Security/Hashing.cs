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
        internal string GetHash(string password) => Convert.ToHexString(MD5
            .Create().ComputeHash(Encoding.UTF8.GetBytes(password)));

        internal bool EqualsLog(string password)
        {
            if (password == null)
                return false;

            password = GetHash(password);

            using (ApplicationContext db = new ApplicationContext())
            {
                Users? user = db.Users
                    .Where(u=>u.Password == password).FirstOrDefault();
                if (user != null)
                {
                    return true;
                }
            }
            return false;
        }
    }
}