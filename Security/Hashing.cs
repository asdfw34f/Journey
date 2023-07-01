// This is a personal academic project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using Journey.Data.MSSQL;
using Journey.MVVM.Models.Tables;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Journey.Security
{
    internal class Hashing
    {
        internal byte[] GetHash(string password)
        {
            return MD5
            .Create().ComputeHash(Encoding.UTF8.GetBytes(password));
        }

        internal async Task<bool> EqualsLog(string password)
        {
            if (password == null)
            {
                return false;
            }

            var pwd = GetHash(password);
            Users? user = null;
            using (ApplicationContext db = new())
            {
                user = db.Users
                    .Where(u => u.Password == pwd).FirstOrDefault();
            }
            if (user != null)
            {
                await new FileLog().WriteLogAsync(user);
                return true;
            }
            else
                return false;
        }
    }
}