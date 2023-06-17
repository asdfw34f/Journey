using Journey.MVVM.Models;
using Microsoft.EntityFrameworkCore;

namespace Journey.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-9N46EPK\DANIIL_BANK1230;Database=Journy;Trusted_Connection=True;");
        }
    }
}