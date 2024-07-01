using Microsoft.EntityFrameworkCore;
using Module25.Final.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module25.Final
{
    public class AppContext : DbContext
    {
        // Объекты таблицы Users
        public DbSet<Client> Clients { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }

        public AppContext()
        {
            Database.EnsureCreated();
        }

        public AppContext(bool needToDeleteDB)
        {
            if (needToDeleteDB)
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
