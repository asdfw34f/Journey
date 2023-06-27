using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows;

namespace Journey.Security
{
    public class Hashing
    {
        LogPath logPath = new LogPath();
        public string GetHash(string log) => Convert.ToHexString(MD5
            .Create().ComputeHash(Encoding.UTF8.GetBytes(log)));

        private bool CheckLogFile() => File.Exists(logPath.FileLogPath);

        public bool WriteLog(string login, string password)
        {
            var hash = GetHash("Login " + login + " Password " + password);

            try
            {
                using FileStream f = new FileStream(logPath.FileLogPath,
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

        public string ReadLog()
        {
            if (!CheckLogFile())
                return null;
            try
            {
                byte[] hash = null;

                using (FileStream f = new FileStream(logPath.FileLogPath,
                            FileMode.Open))
                {
                    f.Read(hash);
                }
                return Convert.ToHexString(hash);
            }
            catch (IOException ex)
            {
                MessageBox.Show(
                    ex.Source,
                    ex.Message,
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
                return null;
            }
        }

        public bool EqualsLog(string login, string password)
        {
            
            string hash = ReadLog();
            if (string.IsNullOrEmpty(hash))
                return false;

            string log = "Login " + login + " Password " + password;
            string oldHash = GetHash(log);

            bool bEqual = false;

            if (oldHash.Length == hash.Length)
            {
                int i = 0;
                while (i < oldHash.Length && oldHash[i] == hash[i])
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