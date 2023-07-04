// This is a personal academic project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using Journey.MVVM.Models.Tables;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace Journey.Data.GetData
{
    public static class GetTickets
    {
        public static List<Tickets>? Tickets { get; private set; }

        private static int count = -1;

        public static Tickets? GetNext()
        {
            count++;
            return count < Tickets.Count ? Tickets[count] : null;
        }

        public static void GetFile()
        {

            string file_name = "D:\\ПРОЕКТЫ\\Journey\\bin\\Debug\\" + "\\avia\\avia.json";

            if (File.Exists(file_name) == true)
            {
                var list = JsonConvert.DeserializeObject<List<Tickets>>(File.ReadAllText(file_name));
                if (list != null)
                    Tickets = list;
            }
        }
    }
}