using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookManagement.Models;
namespace BookManagement.Common
{
    public class Translator
    {
        public Models.UserModel.UserModel.EditUser MakeUser(User user)
        {
            var edituser = new Models.UserModel.UserModel.EditUser
            {
                ID = user.ID,
                Mail = user.Email,
                Name = user.Name,
                Phone = user.Phone,
                Password = user.Pass,
                DOB = user.DOB,
                Sex = user.Sex,
                RoleID = user.RoleID,
                StatusID = user.StatusID,
                Address = user.Address,
                Img_Name = user.Img_Link
            };
            return edituser;
        }
    }
}