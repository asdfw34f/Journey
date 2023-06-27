using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows;

namespace Journey.Data.Resources.Safing
{
    public class Hashing
    {
        private string GetHash(string log) => Convert.ToHexString(MD5
            .Create().ComputeHash(Encoding.UTF8.GetBytes(log)));

        public bool WriteLog(string login, string password)
        {
            var hash = GetHash("Login " + login + " Password " + password);

            try
            {
                using FileStream f = new FileStream(
                        System.Reflection.Assembly.GetExecutingAssembly().Location + "user.melog",
                        FileMode.OpenOrCreate);
                {
                    f.Write(Encoding.UTF8.GetBytes(hash));
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

        private string ReadLog()
        {
            try
            {
                byte[] hash = null;

                using (FileStream f = new FileStream(
                            System.Reflection.Assembly
                            .GetExecutingAssembly().Location + "user.melog",
                            FileMode.Open))
                {
                    f.Read(hash);
                }
                return Convert.ToHexString(hash);
            }
            catch (FileNotFoundException ex)
            {
                return null;
            }
        }

        public bool EqualsLog(string login, string password)
        {
            string log = "Login " + login + " Password " + password;
            string hash = ReadLog();
            string oldHash = GetHash(log);

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
            return bEqual;
        }
    }
}