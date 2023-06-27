using Journey.MVVM.Models;
using Microsoft.EntityFrameworkCore;

namespace Journey.Data.MSSQL
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Server=DESKTOP-9N46EPK\DANIIL_BANK1230;Database=Journеy;Integrated Security=true
            // DESKTOP-U2DHO8A\MYSERVER
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-U2DHO8A\MYSERVER;Database=Journеy;Integrated"
                           + " Security=True;TrustServerCertificate=true;",
                           sqlServerOptionsAction: sqlOptions => 
                           { sqlOptions.EnableRetryOnFailure(); });
        }

    }
}