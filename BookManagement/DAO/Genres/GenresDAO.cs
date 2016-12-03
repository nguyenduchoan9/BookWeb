using BookManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookManagement.DAO.Genres
{
    public class GenresDAO
    {
        BookManagementEntities _db = null;
        public GenresDAO()
        {
            _db = new BookManagementEntities();
        }
        public List<BookManagement.Models.Genres.Genres> ListGenres()
        {
            var genreslist = _db.Genres.ToList();
            List<BookManagement.Models.Genres.Genres> bookgenres = new List<Models.Genres.Genres>();
            foreach (var item in genreslist)
            {
                bookgenres.Add(new Models.Genres.Genres
                {
                    ID = item.ID,
                    Name = item.Name
                });
            }
            return bookgenres;
        }
    }
}