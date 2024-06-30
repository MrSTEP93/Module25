using Module25.Final.Repositories;
using NUnit.Framework;
using System;

namespace Module25.Final.Tests
{
    [TestFixture]
    public class BooksRepositoryTests
    {
        readonly AppContext db = new();

        [Test]
        public void GetCountBooksOfAuthorMustReturnCurrentValue()
        {
            var rep = new BookRepository(db);
            Assert.AreEqual(1,rep.GetCountBooksOfAuthor("Tolstoy"));
        }
    }
}
