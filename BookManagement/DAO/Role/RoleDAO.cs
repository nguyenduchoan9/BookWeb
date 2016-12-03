using BookManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookManagement.DAO.Role
{
    public class RoleDAO
    {
        BookManagementEntities _db = null;
        public RoleDAO()
        {
            _db = new BookManagementEntities();
        }
        public List<BookManagement.Models.RoleModel.RoleModel> ListRole()
        {
            var rolelist = _db.BookStatus.ToList();
            List<BookManagement.Models.RoleModel.RoleModel> roles = new List<BookManagement.Models.RoleModel.RoleModel>();
            foreach (var item in rolelist)
            {
                roles.Add(new BookManagement.Models.RoleModel.RoleModel
                {
                    ID = item.ID,
                    Name = item.Name
                });
            }
            return roles;
        }
    }
}