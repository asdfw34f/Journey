using Journey.Data.MSSQL;
using Journey.MVVM.Models.Tables;
using Journey.Security;
using System.Collections.Generic;
using System.Linq;

namespace Journey.Data.GetData
{
    public static class GetFavorites
    {
        public static int count = 0;
        public static List<Favorites> Favorites { get; set; } = new List<Favorites>();

        public static List<Favorites>? Get()
        {
            using (ApplicationContext db = new())
            {
                FileLog log = new();
                Users user = log.ReadLog();
                Favorites = db.Favorites.Where(f => f.Email == user.Email).ToList();
            }
            count = Favorites.Count;
            return Favorites;
        }

        public static Favorites? GetNext()
        {
            count++;
            return count < Favorites.Count ? Favorites[count] : null;
        }
    }
}