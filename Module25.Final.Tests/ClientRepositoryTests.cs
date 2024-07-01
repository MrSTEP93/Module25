using Module25.Final.Entities;
using Module25.Final.Repositories;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Module25.Final.Tests
{
    [TestFixture]
    public class ClientRepositoryTests
    {
        readonly AppContext db = new();

        [Test]
        public void ClientCRUDMustWork()
        {
            Client cli = new() { Name = "NUnit", Surname = "Test", Email = "nu@test" };
            var rep = new ClientRepository(db);
            var cliList = rep.GetClients();
            bool isExists = cliList.Contains(cli);
            Assert.IsFalse(isExists);
            // ^^ проверяем, что тестового пользователя еще нет

            rep.AddClient(cli);
            db.SaveChanges();
            cliList = rep.GetClients();
            int cliId = cliList.FirstOrDefault(c => c == cli).Id;
            Assert.AreNotEqual(0, cliId);
            // ^^ проверяем, что тестовый пользователь появился

            rep.UpdateClientName(cliId, "updated NUnit");
            cliList = rep.GetClients();
            Assert.AreEqual("updated NUnit", cliList.FirstOrDefault(c => c.Id == cliId).Name);
            // ^^ проверяем, что у тестового пользователя сменилось имя

            rep.DeleteClient(cliId);
            cliList = rep.GetClients();
            isExists = cliList.Contains(cli);
            Assert.IsFalse(isExists);
            // ^^ проверяем, что тестовый пользователь не существует
        }

        [Test]
        public void GetFlagIfClientHasBookReturnsCorrentValue()
        {
            var bookRep = new BookRepository(db);
            var book = bookRep.GetBookById(1);

            var rep = new ClientRepository(db);
            var cli = rep.GetClientById(7);
            bool flag = rep.GetFlagIfClientHasBook(cli, book);
            Assert.AreEqual(true, flag);
        }

        [Test]
        public void GetCountOfBooksHasClientMustReturnsCorrentCount()
        {
            var rep = new ClientRepository(db);
            var cli = rep.GetClientById(8);
            var count = rep.GetCountOfBooksHasClient(cli);
            Assert.AreEqual(2, count);
        }
    
        /*
        [Test]
        public void GetClientsMustReturnsCorrentCount()
        {
            var rep = new ClientRepository(db);
            var cliList = rep.GetClients();
            Assert.AreEqual(8, cliList.Count);
        }

        [Test]
        public void GetClientByIdMustReturnsCorrentValue()
        {
            var rep = new ClientRepository(db);
            var cli = rep.GetClientById(5);
            Assert.AreEqual("Mikhailo", cli.Name);
        }
        */
    }
}
