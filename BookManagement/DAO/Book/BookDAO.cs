using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookManagement.Models;
using PagedList;
using System.Globalization;

namespace BookManagement.DAO
{
    public class BookDAO
    {
        BookManagementEntities _db = null;
        
        public BookDAO ()
        {
            _db = new BookManagementEntities();
        }
        public IEnumerable<Book> ListBook(string searchkey, int page, int pageSize)
        {
            IQueryable<Book> model = _db.Books;
            if (!string.IsNullOrEmpty(searchkey))
            {
                model = model.Where(b=>b.Name.Contains(searchkey.Trim()));
            }
            return model.OrderBy(b=>b.AddedDate.Day).ToPagedList(page, pageSize);
            
        }

        public List<Book> ListBook()
        {
            IQueryable<Book> model = _db.Books;
            return model.OrderBy(b => b.AddedDate.Day).ToList();

        }
        public bool InsertBook(BookManagement.Models.Books.AddBookView book, string img_name)
        {
            //DateTime publishedDate = DateTime.ParseExact(book.PublishedDate.ToString(), "YYYY-MM-DD", CultureInfo.InvariantCulture);
            //DateTime addedDate = DateTime.ParseExact(System.DateTime.Now.ToString(), "YYYY-MM-DD HH:MI:SS", CultureInfo.InvariantCulture);
            //DateTime modDate = DateTime.ParseExact(System.DateTime.Now.ToString(), "YYYY-MM-DD HH:MI:SS", CultureInfo.InvariantCulture);            
            try
            {
                _db.Books.Add(new Book
                {
                    Name = book.Name,
                    Description = book.Description,
                    StatusID = book.StatusID,
                    Price = book.Price,
                    PublisherID = book.PublisherID,
                    PublishedDate = book.PublishedDate,
                    GenreID = book.GenreID,
                    AddedDate = System.DateTime.Now,
                    ModifiedDate = System.DateTime.Now,
                    Img_Link = img_name,
                    AuthorID = book.AuthorID
                });
                _db.SaveChanges();

            }
            catch(Exception e)
            {
                return false;
            }
            return true;
        }

        public bool CheckBook(string name, int publisID, DateTime publishedDate)
        {
            if (_db.Books.Where(b => (b.Name.Equals(name.Trim())) 
                && (b.PublisherID == publisID) 
                && (b.PublishedDate.CompareTo(publishedDate) == 0)).Count() > 0) 
            {
                return true;
            }
            return false;
        }
        //public bool UpdateBook(int id)
        //{
        //    //_db.Books.
        //}
        public Book BookDetail(int bookID)
        {
            return _db.Books.SingleOrDefault(m => m.ID == bookID);
        }

        public IEnumerable<Book> GetByAuthor(int authorID, int page, int pageSize)
        {
            IQueryable<Book> model = _db.Books;
            return model.OrderBy(m=>m.Name).Where(m => m.AuthorID == authorID).ToPagedList(page, pageSize);
        }
    }
}