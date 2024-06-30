using Module25.Final.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Module25.Final
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to digital library!");
            Console.WriteLine("Connecting to db...");
            try
            {
                using (var db = new AppContext())
                {
                    Console.WriteLine("Connected successfuly!");
                    // FillData(db);
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                Console.WriteLine("\t" + ex.InnerException?.Message);
            }
        }

        public static void FillData(AppContext db)
        {
            Console.WriteLine("Filling db...");
            var user1 = new Client { Name = "Arthur", Email = "archi@ya.ru" };
            var user2 = new Client { Name = "Klim", Email = "KilmSanych@ya.ru" };
            db.Clients.Add(user1);
            db.Clients.Add(user2);
            db.SaveChanges();

            var genres = new List<Genre>
            {
                new() { Name = "Drama" },
                new() { Name = "Comedy" },
                new() { Name = "Biography" },
                new() { Name = "Historical" },
                new() { Name = "Novel" },
                new() { Name = "The play"}
            };

            var books = new List<Book>()
            {
                new() { Name = "War and piece", Author = "Tolstoy", Year = 1869, Genres = new() { genres[0], genres[3] } },
                new() { Name = "Storm", Author = "Ostrovskiy", Year = 1859, Genres = new() { genres[5], genres[0] } }
            };

            var clients = new List<Client>()
            {
                new() { Name = "uVasya", Surname = "Pupinskiy", Email = "vas@ya.ru" },
                new() { Name = "Peter", Surname = "Sallywan", Email = "sally000@ty.ept" },
                new() { Name = "Mikhailo", Surname = "Titov", Email = "titMix@ya.ru" }
            };

            books[0].Client = user1;
            books[1].Client = user2;

            db.Clients.AddRange(clients);
            db.Genres.AddRange(genres);
            db.Books.AddRange(books);
            db.SaveChanges();
            // genres.FirstOrDefault(g => g.Name == "Drama")
        }
    }
}
