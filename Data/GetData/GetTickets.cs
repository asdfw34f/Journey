// This is a personal academic project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using Journey.MVVM.Models.Tables;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;

namespace Journey.Data
{
    public class GetTickets
    {
        public async Task<List<Tickets>?> GetFile()
        {
            string file = Path.GetTempPath() + "avia.json";
            try
            {
                 new WebClient().DownloadFileAsync(
                     new Uri("https://raw.githubusercontent.com/Mirkitanov/jsonexmpl/main/avia.json"),
                     file);
            }
            catch (WebException ex)
            {
                _ = MessageBox.Show(
                    ex.Message, ex.Source, MessageBoxButton.OK, MessageBoxImage.Error
                    );
                return null;
            }

            return ReadFile(file);
        }

        private List<Tickets>? ReadFile(string path)
        {
            List<Tickets>? tickets;

            using (FileStream file = new(path, FileMode.Open, FileAccess.Read))
            {
                tickets = JsonSerializer.Deserialize<List<Tickets>>(file);
            }

            return tickets ?? null;
        }
    }
}