using System;

namespace Module25.EF_go1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine("Connecting to db...");
            try
            {
                using (var db = new AppContext())
                {
                    Console.WriteLine("Connected successfuly!");
                    var user1 = new User { Name = "Arthur", Role = "Admin" };
                    var user2 = new User { Name = "Klim", Role = "User" };
                    db.Users.Add(user1);
                    db.Users.Add(user2);
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
