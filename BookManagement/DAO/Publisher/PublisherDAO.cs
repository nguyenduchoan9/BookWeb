using BookManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookManagement.DAO.Publisher
{
    public class PublisherDAO
    {
        BookManagementEntities _db = null;
        public PublisherDAO()
        {
            _db = new BookManagementEntities();
        }
        public List<BookManagement.Models.Publishers.Publishers> GetPublisher()
        {
            var publisherlist = _db.Publishers.ToList();
            List<BookManagement.Models.Publishers.Publishers> bookpublisher = new List<Models.Publishers.Publishers>();
            foreach (var item in publisherlist)
            {
                bookpublisher.Add(new Models.Publishers.Publishers
                {
                    ID = item.ID,
                    Name = item.Name
                });
            }
            return bookpublisher;
        }
    }
}