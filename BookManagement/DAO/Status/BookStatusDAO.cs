using BookManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookManagement.DAO.Status
{
    public class BookStatusDAO
    {
        BookManagementEntities _db = null;
        public BookStatusDAO()
        {
            _db = new BookManagementEntities();
        }
        public List<BookManagement.Models.Status.BookStatuses> ListBookStatus()
        {
            var bookstatuslist = _db.BookStatus.ToList();
            List<BookManagement.Models.Status.BookStatuses> bookstatuses = new List<Models.Status.BookStatuses>();
            foreach (var item in bookstatuslist)
            {
                bookstatuses.Add(new Models.Status.BookStatuses
                {
                    ID = item.ID,
                    Name = item.Name
                });
            }
            return bookstatuses;
        }
    }
}