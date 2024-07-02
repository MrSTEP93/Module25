using Module25.Final.Entities;
using Module25.Final.Repositories;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module25.Final.Tests
{
    [TestFixture]
    public class GenreRepositoryTests
    {
        private readonly AppContext db = new();

        [Test]
        public void GenreCRUDMustWork()
        {
            Genre gen = new() { Name = "NUnitGenre" };
            var rep = new GenreRepository(db);
            var genList = rep.GetGenres();
            bool isExists = genList.Contains(gen);
            Assert.IsFalse(isExists);
            // ^^ проверяем, что тестового жанра еще нет

            rep.AddGenre(gen);
            db.SaveChanges();
            genList = rep.GetGenres();
            int cliId = genList.FirstOrDefault(c => c == gen).Id;
            Assert.AreNotEqual(0, cliId);
            // ^^ проверяем, что тестовый жанр появился

            rep.UpdateGenreName(cliId, "updated_NUnitGenre");
            genList = rep.GetGenres();
            Assert.AreEqual("updated_NUnitGenre", genList.FirstOrDefault(c => c.Id == cliId).Name);
            // ^^ проверяем, что у тестового жанра изменилось название

            rep.DeleteGenre(cliId);
            genList = rep.GetGenres();
            isExists = genList.Contains(gen);
            Assert.IsFalse(isExists);
            // ^^ проверяем, что тестовый пользователь не существует
        }
    }
}
