using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookManagement.Models;

namespace BookManagement.DAO.Users
{
    public class UserDAO
    {
        BookManagementEntities _db = null;
        public UserDAO()
        {
            _db = new BookManagementEntities();
        }
        public User LoginUser(string email, string password)
        {

            return _db.Users.SingleOrDefault(m => (m.Email.Equals(email.Trim())) && (m.Pass.Equals(password.Trim())));
        }

        public bool CreateUser(BookManagement.Models.UserModel.UserModel.CreateUser user)
        {
            try
            {
                var entity = new User
                {
                    Email = user.Mail,
                    Name = user.Name,
                    Phone = user.Phone,
                    Pass = user.Password,
                    DOB = user.DOB,
                    Sex = user.Sex,
                    RoleID = user.RoleID,
                    StatusID = user.StatusID,
                    Address = user.Address,
                    RegDate = System.DateTime.Now,
                    Img_Link = user.Img_Name
                };
                _db.Users.Add(entity);
                _db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool EditUser(BookManagement.Models.UserModel.UserModel.EditUser _eidtuser)
        {
            try
            {
                var user = FindByID(_eidtuser.ID);
                user.Email = _eidtuser.Mail;
                user.Name = _eidtuser.Name;
                user.Phone = _eidtuser.Phone;
                user.Pass = _eidtuser.Password;
                user.DOB = _eidtuser.DOB;
                user.Sex = _eidtuser.Sex;
                user.RoleID = _eidtuser.RoleID;
                user.StatusID = _eidtuser.StatusID;
                user.Address = _eidtuser.Address;
                user.Img_Link = _eidtuser.Img_Name;
                _db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public User FindByID(int id)
        {
            return _db.Users.Find(id);
        }
        public User CheckAvailability(string email)
        {
            return _db.Users.Where(m => m.Email.Equals(email, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
        }


    }
}