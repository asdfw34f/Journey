using Journey.MVVM.Models;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text.Json;
using System.Windows;

namespace Journey.Infrastructure.Commands.Json
{
    public class GetJson
    {
        private string _remoteUri { get; } = "https://raw.githubusercontent.com/Mirkitanov/jsonexmpl/main/avia.jso";
        private string FileName { get; } = Path.GetTempPath() + "avia.json";

        public List<Tickets>? GetFile()
        {
            try
            {
                WebClient myWebClient = new();
                // Concatenate the domain with the Web resource filename.
                // Download the Web resource and save it into the current filesystem folder.
                myWebClient.DownloadFile(_remoteUri, FileName);
            }
            catch (WebException ex)
            {
                _ = MessageBox.Show(
                    ex.Message, ex.Source, MessageBoxButton.OK, MessageBoxImage.Error
                    );
                return null;
            }

            return ReadFile(FileName);
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