using Module25.Final.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module25.Final.Repositories
{
    public class GenreRepository
    {
        private readonly AppContext db;

        public GenreRepository(AppContext context)
        {
            db = context;
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public Genre GetGenreById(int id)
        {
            return db.Genres.FirstOrDefault(genre => genre.Id == id);
        }

        public List<Genre> GetGenres()
        {
            return db.Genres.ToList();
        }

        public void AddGenre(Genre newGenre)
        {
            db.Genres.Add(newGenre);
            Save();
        }

        public void DeleteGenre(int id)
        {
            db.Genres.Remove(GetGenreById(id));
            Save();
        }

        public void ChangeGenreYear(int id, short newYear)
        {
            var changedGenre = GetGenreById(id);
            //changedGenre.Year = newYear;
            Save();
        }
    }
}