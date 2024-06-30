using Module25.Final.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Module25.Final
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to digital library!");
            Console.WriteLine("Connecting to db...");
            using (var db = new AppContext())
            {
                Console.WriteLine("Connected successfuly!");
                //FillData2(db);
                //FillBookClient(db);
            };

            /*
            Console.WriteLine("Error: " + ex.Message);
            Console.WriteLine("\t" + ex.InnerException?.Message);
            */
        }

        public static void FillData(AppContext db)
        {
            Console.WriteLine("Filling db...");
            var user1 = new Client { Name = "Arthur", Email = "archi@ya.ru" };
            var user2 = new Client { Name = "Klim", Email = "KilmSanych@ya.ru" };
            db.Clients.Add(user1);
            db.Clients.Add(user2);
            db.SaveChanges();

            var genres = new List<Genre>  // тут id идут с нуля
            {
                new() { Name = "Drama" },  // 0
                new() { Name = "Comedy" },  // 1
                new() { Name = "Biography" },  // 2
                new() { Name = "Historical" },  // 3
                new() { Name = "Novel" },  // 4
                new() { Name = "The play"}  // 5
            };

            var books = new List<Book>()
            {
                new() { Name = "War and piece", Author = "Tolstoy", Year = 1869, Genres = new() { genres[0], genres[3] } },  // 0
                new() { Name = "Storm", Author = "Ostrovskiy", Year = 1859, Genres = new() { genres[5], genres[0] } }   // 1
            };

            var clients = new List<Client>()
            {
                new() { Name = "uVasya", Surname = "Pupinskiy", Email = "vas@ya.ru" },  // 0
                new() { Name = "Peter", Surname = "Sallywan", Email = "sally000@ty.ept" },  // 1
                new() { Name = "Mikhailo", Surname = "Titov", Email = "titMix@ya.ru" }  // 2
            };

            books[0].Client = user1;
            books[1].Client = user2;

            db.Clients.AddRange(clients);
            db.Genres.AddRange(genres);
            db.Books.AddRange(books);
            db.SaveChanges();
            // genres.FirstOrDefault(g => g.Name == "Drama")
        }

        public static void FillData2(AppContext db)
        {
            Console.WriteLine("Filling (2) db...");

            var genres = db.Genres.ToList();  // и тут тоже

            var books = new List<Book>()
            {
                new() { Name = "Compilation of comedy novels by Zoschenko", Author = "Zoschenko", Year = 1963, Genres = new() { genres[1] } },
                new() { Name = "Essays on the history of Russia", Author = "N. Doronina", Year = 2022, Genres = new() { genres[3] } },
                new() { Name = "Valley of Storks", Author = "Ion Druce", Year = 1923, Genres = new() { genres[5], genres[0] } },
                new() { Name = "Vertinskiy and Ladies", Author = "A. Vertinskiy", Year = 1986, Genres = new() { genres[5], genres[2] } },
            };
            db.Books.AddRange(books);
            db.SaveChanges();

            var clients = new List<Client>()
            {
                new() { Name = "Elena", Surname = "Titova", Email = "el@tit.ru" },
                new() { Name = "Sandra", Surname = "Bullock", Email = "t0bi@privet.com" },
                new() { Name = "Till", Surname = "Lindemann", Email = "till@ya.de" }
            };
            db.Clients.AddRange(clients);
            db.SaveChanges();
            // genres.FirstOrDefault(g => g.Name == "Drama")
        }

        public static void FillBookClient(AppContext db)
        {
            var books = db.Books.ToList();
            var clients = db.Clients.ToList();

            var b = books.Select(b => b.Name);
            var c = clients.Select(c => c.Name + c.Surname);

            books[0].Client = clients[6];
            books[1].Client = clients[1];
            books[2].Client = clients[7];
            books[3].Client = clients[7];
            books[4].Client = clients[5];

            db.SaveChanges();
        }
    }
}
