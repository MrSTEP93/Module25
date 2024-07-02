using Module25.Final.Entities;
using Module25.Final.Repositories;
using NUnit.Framework;
using System;
using System.Linq;

namespace Module25.Final.Tests
{
    [TestFixture]
    public class BooksRepositoryTests
    {
        readonly AppContext db = new();

        [Test]
        public void GetBookByIdMustRerurnCurrentValue()
        {
            var rep = new BookRepository(db);
            var book = rep.GetBookById(4);
            Assert.AreEqual("Kasa Mare", book.Name);
        }

        [Test]
        public void GetBooksByAlphabetMustReturnCurrentValue()
        {
            var bookRep = new BookRepository(db);
            var bookList = bookRep.GetBooksByAlphabet();
            var lastBook = bookList.Last();
            Console.WriteLine(lastBook.Name);
            Assert.AreEqual("War and piece", lastBook.Name);
        }

        [Test]
        public void GetBooksByYearDescMustReturnCurrentValue()
        {
            var bookRep = new BookRepository(db);
            var bookList = bookRep.GetBooksByYearDesc();
            Console.WriteLine(bookList[0].Author);
            Assert.AreEqual("N. Doronina", bookList[0].Author);
        }

        [Test]
        public void GetBooksWithGenreAndYearsMustReturnCurrentValue()
        {
            var rep = new BookRepository(db);
            var genreRep = new GenreRepository(db);
            var genre = genreRep.GetGenreById(3);
            var bookList = rep.GetBooksWithGenreAndYears(genre, 1990, 1991);
            Assert.AreEqual(1, bookList.Count);
        }

        [Test]
        public void GetCountBooksOfAuthorMustReturnCurrentValue()
        {
            var rep = new BookRepository(db);
            Assert.AreEqual(1,rep.GetCountBooksOfAuthor("Tolstoy"));
        }

        [Test]
        public void GetCountBooksOfGenreMustReturnCurrentValue()
        {
            var bookRep = new BookRepository(db);
            var genreRep = new GenreRepository(db);
            var genre = genreRep.GetGenreById(2);
            Assert.AreEqual(1, bookRep.GetCountBooksOfGenre(genre));
        }

        [Test]
        public void GetFlagOfAuthorAndNameMustReturnCurrentValue()
        {
            var rep = new BookRepository(db);
            Assert.AreEqual(false, rep.GetFlagOfAuthorAndName("Tolstoy", "War and piec"));
        }

        [Test]
        public void GetLatestBookMustReturnCurrentValue()
        {
            var rep = new BookRepository(db);
            var book = rep.GetLatestBook();
            Assert.AreEqual(2022, book.Year);
        }
    }
}
