using System;

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
                    var user1 = new Client { Name = "Arthur", Email = "archi@ya.ru" };
                    var user2 = new Client { Name = "Klim", Email = "KilmSanych@ya.ru" };
                    db.Client.Add(user1);
                    db.Client.Add(user2);
                    db.SaveChanges();
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                Console.WriteLine("\t" + ex.InnerException?.Message);
            }
        }
    }
}
