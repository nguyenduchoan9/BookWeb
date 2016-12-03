using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookManagement.Models.UserModel
{
    public class UserModel
    {
        public class User : LoginModel
        {
            public string Img_Link { get; set; }
            public string Name { get; set; }
            public int RoldeID { get; set; }
        }
        public class LoginModel
        {
            public int ID { get; set; }
            [Required(ErrorMessage="Email is required!")]
            public string Email { get; set; }
            [Required(ErrorMessage="Password is required!")]
            public string Password { get; set; }
            public bool Remember { get; set; }
        }

        public class CreateUser
        {
            [Required]
            public string Name { get; set; }
            [Required]
            public string Password { get; set; }
            public int RoleID { get; set; }
            [Required]
            public DateTime DOB { get; set; }
            [Required]
            public bool Sex { get; set; }
            public string Img_Name { get; set; }
            public string Address { get; set; }
            public string Phone { get; set; }
            [Required]
            [Remote("GetEmail", "Validation")]
            public string Mail { get; set; }
            public int StatusID { get; set; }
        }

        public class EditUser : CreateUser
        {
            public int ID { get; set; }
        }
    }
}