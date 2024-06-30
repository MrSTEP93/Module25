using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public List<Book> GetBooks()
        {
            return db.Books.ToList();
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

        public void ChangeBookYear(int id, short newYear)
        {
            var changedBook = GetBookById(id);
            changedBook.Year = newYear;
            Save();
        }
    }
}
