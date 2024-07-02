using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Module25.Final.Entities;

namespace Module25.Final.Repositories
{
    public class ClientRepository
    {
        private readonly AppContext db;

        public ClientRepository(AppContext context)
        {
            db = context;
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public List<Client> GetClients()
        {
            return db.Clients.ToList();
        }

        public Client GetClientById(int id)
        {
            //var list = db.Clients;
            //return list.Include(cli => cli.Books).FirstOrDefault(cli => cli.Id == id);
            return db.Clients.Include(cli => cli.Books).FirstOrDefault(cli => cli.Id == id);
        }

        public void AddClient(Client newClient)
        {
            //newClient.Books ??= new List<Book>();
            db.Clients.Add(newClient);
            Save();
        }

        public void DeleteClient(int id)
        {
            db.Clients.Remove(GetClientById(id));
            Save();
        }

        public void UpdateClientName(int id, string newName)
        {
            var updatedCli = GetClientById(id);
            updatedCli.Name = newName;
            db.Clients.Update(updatedCli);
            Save();
        }

        public bool GetFlagIfClientHasBook(Client client, Book book)
        {
            return db.Clients.Where(c => c == client).Any(c => c.Books.Contains(book));
        }

        public int GetCountOfBooksHasClient(Client client)
        {
            return db.Clients.Include(cli => cli.Books).FirstOrDefault(c => c == client).Books.Count;
        }

        public int GetCountOfBooksHasClient(int id)
        {
            return db.Clients.Include(cli => cli.Books).FirstOrDefault(c => c.Id == id).Books.Count;
        }
    }
}
