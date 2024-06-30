using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public Client GetClientById(int id)
        {
            return db.Clients.FirstOrDefault(cli => cli.Id == id);
        }

        public List<Client> GetClients()
        {
            return db.Clients.ToList();
        }

        public void AddBook(Client newClient)
        {
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
            Save();
        }
    }
}
