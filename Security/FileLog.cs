// This is a personal academic project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using Journey.MVVM.Models.Tables;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;

namespace Journey.Security
{
    internal class FileLog
    {
        private protected class Path
        {
            internal string FullName => System.IO.Path.GetDirectoryName(App.ResourceAssembly.Location) + @"\log\user.json";

            internal string Directory => System.IO.Path.GetDirectoryName(App.ResourceAssembly.Location) + @"\log";
        }

        private readonly Path path = new();

        internal bool CheckLogFile()
        {
            return File.Exists(path.FullName);
        }

        internal void FileDelete()
        {
            File.Delete(path.FullName);
        }

        internal Task WriteLogAsync(Users Login)
        {
            try
            {
                using FileStream f = new(
                    path.FullName, FileMode.OpenOrCreate);
            }
            catch (DirectoryNotFoundException)
            {
                _ = Directory.CreateDirectory(path.Directory);
            }
            catch (IOException ex)
            {
                _ = MessageBox.Show(
                    ex.Source,
                    ex.Message,
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);

            }
            finally
            {
                using FileStream f = new(
                    path.FullName, FileMode.OpenOrCreate);

                JsonSerializer.Serialize(f, Login);
                Dispose(f);
            }

            return Task.CompletedTask;
        }

        internal Users? ReadLog()
        {
            if (!CheckLogFile())
            {
                return null;
            }

            try
            {
                using FileStream f = new(
                path.FullName, FileMode.Open);

                Users? user = JsonSerializer.Deserialize<Users>(f);
                Dispose(f);
                return user;
            }
            catch (IOException ex)
            {
                _ = MessageBox.Show(
                    ex.Source,
                    ex.Message,
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
                return null;
            }
        }

        private void Dispose(FileStream file)
        {
            file.Close();
            file.Dispose();
        }

        internal FileLog()
        {

        }
    }
}