using Shop.Domain.DAO;
using Shop.WebApp.Areas.Admin.Models;
using Shop.WebApp.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.WebApp.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDAO();
                var result = dao.Login(model.userName, model.passWord);
                if (result == 1)
                {
                    var userSession = new UserLogin();
                    var user = dao.GetSingleByUser(model.userName);
                    userSession.username = user.UserName;
                    userSession.userid = user.ID;
                    Session.Add(CommonUser.USER_SESSION, userSession);
                    if (model.RememberMe)
                    {
                        HttpCookie _remember = new HttpCookie("_remember");
                        _remember.Expires = DateTime.Now.AddDays(30);
                        _remember["userName"] = model.userName;
                        _remember["passWord"] = model.passWord;
                        _remember.Secure = false;
                        Response.Cookies.Add(_remember);
                    }
                    return RedirectToAction("Index", "Home");
                }
            }
            return View("Index");          
        }
    }
}