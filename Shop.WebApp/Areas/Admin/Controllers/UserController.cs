using Newtonsoft.Json;
using Shop.Domain.DAO;
using Shop.Domain.Dtos;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.WebApp.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult UpdateUser(UserDtos userDtos)
        {
            var dao = new UserDAO();
            if (dao.UpDate(userDtos))
            {
                return Json(new { Success = true }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { Success = false }, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult GetUserById(int id)
        {
            var dao = new UserDAO();
            var user = dao.GetSingle(id);
            string value = string.Empty;
            value = JsonConvert.SerializeObject(user, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return Json(value, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetAllPaging(string keyword, int pageIndex, int pageSize = 1)
        {
            var dao = new UserDAO();
            var result = dao.GetPagingUser(pageIndex, pageSize, keyword);
            if(result != null)
            {
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            return Json(null, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Create(User user)
        {
            var dao = new UserDAO();
            var result = dao.Create(user);
            if(result > 0)
            {
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            return Json(null, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Delete(int id)
        {
            var dao = new UserDAO();
            if (dao.Delete(id))
            {
                return Json(new {Success = true}, JsonRequestBehavior.AllowGet);
            }
            return Json(new { Success = false }, JsonRequestBehavior.AllowGet);
        }
    }
}