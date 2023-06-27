using Microsoft.VisualBasic.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Journey.Data.Resources.Safing
{
    public class Hashing
    {
        private byte[] GetHash(string log)
        {
            var md5 = MD5.Create();
            byte[] hash = md5.ComputeHash(Encoding.UTF8.GetBytes(log));
            
            return hash;
        }

        public bool WriteLog(string login, string password) 
        { 
            var hash = GetHash("Login " + login + " Password " + password);

            try
            {
                using FileStream f = new FileStream(
                        System.Reflection.Assembly.GetExecutingAssembly().Location + "user.melog",
                        FileMode.OpenOrCreate);
                {
                    f.Write(hash);
                }
                return true;
            }
            catch (IOException ex)
            {
                MessageBox.Show(
                    ex.Source,
                    ex.Message,
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
                return false;
            }
        }


        public bool EqualsLog(string login, string password)
        {
            string log = "Login " + login +" Password " + password;
            byte[] hash = null;
            var oldHash = GetHash(log);
            try
            {
                using FileStream f = new FileStream(
                        System.Reflection.Assembly.GetExecutingAssembly().Location + "user.melog",
                        FileMode.Open);
                {
                    f.Read(hash);
                }

                bool bEqual = false;

                if (oldHash.Length == hash.Length)
                {
                    int i = 0;
                    while ((i < oldHash.Length) && (oldHash[i] == hash[i]))
                    {
                        i += 1;
                    }
                    if (i == oldHash.Length)
                    {
                        bEqual = true;
                    }
                }
                return true;
            }
            catch (IOException ex)
            {
                MessageBox.Show(
                    ex.Source,
                    ex.Message,
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
                
            }

            return false;
        }
    }
}