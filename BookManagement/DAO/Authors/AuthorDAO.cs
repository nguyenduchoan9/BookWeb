using BookManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookManagement.DAO.Authors
{
    public class AuthorDAO
    {
        BookManagementEntities _db = null;
        public AuthorDAO()
        {
            _db = new BookManagementEntities();
        }
        public List<BookManagement.Models.Authors.Author> ListAuthor()
        {
            var authorlist = _db.Authors.ToList();
            List<BookManagement.Models.Authors.Author> bookauthor = new List<Models.Authors.Author>();
            foreach (var item in authorlist)
            {
                bookauthor.Add(new Models.Authors.Author
                {
                    ID = item.ID,
                    Name = item.Name
                });
            }
            return bookauthor;
        }
    }
}