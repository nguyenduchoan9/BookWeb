using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookManagement.Common
{
    [Serializable]
    public class UserLogin
    {
        public string Email { get; set; }
        public string UserName { get; set; }
    }
}