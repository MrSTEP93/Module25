using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Module25.Final.Entities;

namespace Module25.Final.Repositories
{
    public class BookRepository
    {
        private readonly AppContext db;

        public BookRepository(AppContext context)
        {
            db = context;
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public Book GetBookById(int id)
        {
            return db.Books.FirstOrDefault(book => book.Id == id);
        }

        public void AddBook(Book newBook)
        {
            db.Books.Add(newBook);
            Save();
        }

        public void DeleteBook(int id)
        { 
            db.Books.Remove(GetBookById(id));
            Save();
        }

        public List<Book> GetBooks()
        {
            return db.Books.ToList();
        }

        public List<Book> GetBooksByAlphabet()
        {
            return db.Books.OrderBy(b => b.Name).ToList();
        }

        public List<Book> GetBooksByYearDesc()
        {
            return db.Books.OrderByDescending(b => b.Year).ToList();
        }

        public void ChangeBookYear(int id, short newYear)
        {
            var changedBook = GetBookById(id);
            changedBook.Year = newYear;
            Save();
        }

        public List<Book> GetBooksWithGenreAndYears(Genre genre, short startYear, short endYear)
        {
            return db.Books.Where(b => (b.Year >= startYear) && (b.Year <= endYear) && b.Genres.Contains(genre)).ToList();
        }

        public int GetCountBooksOfAuthor(string author)
        {
            return db.Books.Count(b => b.Author == author);
        }

        public int GetCountBooksOfGenre(Genre genre)
        {
            return db.Books.Count(b => b.Genres.Contains(genre));
        }

        public bool GetFlagOfAuthorAndName(string author, string bookName)
        {
            return db.Books.Any(b => (b.Author == author) && (b.Name == bookName));
        }

        public Book GetLatestBook()
        {
            return db.Books.OrderByDescending(b => b.Year).FirstOrDefault();
        }
    }
}
