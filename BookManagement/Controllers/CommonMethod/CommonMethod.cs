using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookManagement.Controllers.CommonMethod
{
    public class CommonMethod : Controller
    {
        public void SetMessage(string type, string message)
        {
            TempData["SYSTEM_MESSAGE"] = message;
            if (type.ToUpper().Equals("SUCCESS"))
            {
                TempData["MESSAGE_TYPE"] = "alert-success";
            }
            else if (type.ToUpper().Equals("WARNING"))
            {
                TempData["MESSAGE_TYPE"] = "alert-warning";
            }
            else if(type.ToUpper().Equals("ERROR"))
            {
                TempData["MESSAGE_TYPE"] = "alert-danger";
            }
        }
    }
}