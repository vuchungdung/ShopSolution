using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Shop.WebApp.Areas.Admin.Models
{
    public class LoginViewModel
    {
        public string userName { set; get; }
        public string passWord { set; get; }
        public bool RememberMe { set; get; }
    }
}