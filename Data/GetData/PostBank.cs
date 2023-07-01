using Journey.Data.MSSQL;
using Journey.MVVM.Models.Views;
using System.Collections.Generic;
using System.Linq;

namespace Journey.Data.GetData
{
    public static class PostBank
    {
        public static List<Posts>? posts { get; set; }
        private static int ind = -1;

        public static Posts? GetNextPost()
        {
            if (ind < posts.Count)
                return posts[ind++];
            else
                return null;
        }

        static PostBank()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                posts = db.Posts.OrderBy(p => p.Created).ToList();
            }
        }
    }
}