using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookManagement.DAO.Users;
using BookManagement.Models.UserModel;
using BookManagement.Common;
using System.Security.Claims;
using System.IO;
using BookManagement.DAO.Status;
using BookManagement.DAO.Role;


namespace BookManagement.Controllers
{
    public class UserController : CommonMethod.CommonMethod
    { 
        //
        // GET: /User/
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View("UserLogin");
        }

        [HttpPost]
        public ActionResult Login(UserModel.LoginModel user)
        {
            if(ModelState.IsValid)
            {
                var UserAccess = new UserDAO();
                var result = UserAccess.LoginUser(user.Email, Encryptor.MD5Hash(user.Password));
                if (result != null)
                {
                    Session.Add(CommonConstant.USER_NAME, result.Name);
                    Session.Add(CommonConstant.USER_ID, result.ID);
                    Session.Add(CommonConstant.USER_EMAIL, result.Email);
                    Session.Add(CommonConstant.USER_ROLE, result.RoleID);
                    Session.Add(CommonConstant.USER_IMG, result.Img_Link);
                    //var user_profile = new UserModel.User
                    //{
                    //    Email = result.Email,
                    //    ID = result.ID,
                    //    Name = result.Name,
                    //    Img_Link = result.Img_Link,
                    //    RoldeID = result.RoleID
                        
                    //};
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "This user is not existed!");
                    return View("UserLogin", user);
                }
            }
            else
            {
                ModelState.AddModelError("", "");
            }
            
            return View("UserLogin");
        }
        [HttpGet]
        public ActionResult Logout()
        {
            Session.RemoveAll();
            return RedirectToAction("Index","Home");
        }

        [HttpGet]
        public ActionResult SignUp()
        {
            SetViewBag();
            return View("SignUp");
            //return RedirectToAction("SignUp",);
        }
        [HttpPost]
        public ActionResult SignUp(UserModel.CreateUser user, HttpPostedFileBase upload_File)
        {
            var _userAccess = new UserDAO();
            if (ModelState.IsValid)
            {
                if ((upload_File.ContentLength < 0) || (upload_File == null))
                {
                    user.Img_Name = "member.png";
                    //string relativePath = "~/Content/Img/User/" + Path.GetFileName(upload_File.FileName);
                    //string physicalPath = Server.MapPath(relativePath);
                    //upload_File.SaveAs(physicalPath);
                }
                else
                {
                    string relativePath = "~/Content/Img/User/" + Path.GetFileName(upload_File.FileName);
                    string physicalPath = Server.MapPath(relativePath);
                    upload_File.SaveAs(physicalPath);
                    user.Img_Name = upload_File.FileName;
                }
                
                
                //Set invisible variable
                user.RoleID = 2;
                user.StatusID = 1;
                var temppass = user.Password;
                user.Password = Encryptor.MD5Hash(user.Password);
                if (_userAccess.CreateUser(user) == true)
                {
                    var userLogin = new UserModel.LoginModel
                    {
                        Email = user.Mail,
                        Password = temppass
                    };
                    
                    Login(userLogin);
                    return RedirectToAction("Index", "Home");
                }
            }
            SetViewBag();
            SetMessage("ERROR", "User is not created!");
            return View("SignUp");
        }
        [HttpGet]
        public ActionResult EditUser(int userID)
        {
            var user = new UserDAO().FindByID(userID);
            //var edituser = new Common.Translator().MakeUser(user);
            SetViewBag();
            return View(new Common.Translator().MakeUser(user));
        }

        [HttpPost]
        public ActionResult EditUser(UserModel.EditUser user, HttpPostedFileBase upload_File)
        {

            return RedirectToAction("Index", "Home");
        }

        public JsonResult GetEmail(string Mail)
        {
            var _userAccess = new UserDAO();
            if (_userAccess.CheckAvailability(Mail) != null)
            {
                return Json(new
                {
                    result = true
                }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { result = false }, JsonRequestBehavior.AllowGet);
        }
        public void SetViewBag()
        {
            var _useraccess = new UserStatusDAO();
            var _userrole = new RoleDAO();
            ViewBag.UserRole = _userrole.ListRole();
            ViewBag.UserStatus = _useraccess.ListUserStatus();
        }
	}
}