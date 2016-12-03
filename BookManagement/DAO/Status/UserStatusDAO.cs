using BookManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookManagement.DAO.Status
{
    public class UserStatusDAO
    {
        BookManagementEntities _db = null;
        public UserStatusDAO()
        {
            _db = new BookManagementEntities();
        }
        public List<BookManagement.Models.Status.UserStatus> ListUserStatus()
        {
            var userstatuslist = _db.BookStatus.ToList();
            List<BookManagement.Models.Status.UserStatus> userstatuses = new List<Models.Status.UserStatus>();
            foreach (var item in userstatuslist)
            {
                userstatuses.Add(new Models.Status.UserStatus
                {
                    ID = item.ID,
                    Name = item.Name
                });
            }
            return userstatuses;
        }
    }
}