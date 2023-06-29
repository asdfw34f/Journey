﻿using Journey.MVVM.Models;
using Microsoft.EntityFrameworkCore;

namespace Journey.Data.MSSQL
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Users>? Users { get; set; } = null;
        public DbSet<Posts>? Posts { get; set; } = null;
        public DbSet<Groups>? Groups { get; set; } = null;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Server=DESKTOP-9N46EPK\DANIIL_BANK1230;
            // Database=Journеy;
            // Integrated Security=true

            // DESKTOP-U2DHO8A\MYSERVER

            _ = optionsBuilder.UseSqlServer(
                            @"Server=.\MYSERVER;"
                           + "DataBase=Journey;"
                           + "Trusted_Connection=true;"
                           //   + "User ID=user;pwd=user;"
                           + "TrustServerCertificate=true;",
                           sqlServerOptionsAction: sqlOptions =>
                           { _ = sqlOptions.EnableRetryOnFailure(); });
        }
    }
}