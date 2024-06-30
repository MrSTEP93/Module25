using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Module25.EF_go1.Entities;

namespace Module25.EF_go1
{
    public class AppContext : DbContext
    {
        // Объекты таблицы Users
        public DbSet<User> Users { get; set; }
        
        // Объекты таблицы Companies
        public DbSet<Company> Companies { get; set; }

        // Объекты таблицы UserCredentials
        public DbSet<UserCredential> UserCredentials { get; set; }

        public AppContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = File.ReadAllText("connString.txt");
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
