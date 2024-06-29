using Microsoft.EntityFrameworkCore;
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
        public DbSet<Client> Client { get; set; }
        public DbSet<Book> Book { get; set; }

        public AppContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = File.ReadAllText("connString.txt");
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
