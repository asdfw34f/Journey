using Journey.MVVM.Models;
using Microsoft.EntityFrameworkCore;

namespace Journey.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Server=DESKTOP-9N46EPK\DANIIL_BANK1230;Database=Journеy;Integrated Security=true
            
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-9N46EPK\DANIIL_BANK1230;Database=Journеy;Integrated" 
                           + " Security=False; User Id=User;Password=User123;MultipleActiveResultSets=True;"
                           + "TrustServerCertificate=True;", sqlServerOptionsAction: sqlOptions => 
                           { sqlOptions.EnableRetryOnFailure(); });
        }

       /* protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(u => u.Email);
        }*/
    }
}