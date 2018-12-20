using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
namespace FormAuthentication.Controllers
{
    public class AdminController : Controller
    {
        DAL.dbContext db = new DAL.dbContext();
        // GET: Admin
        public ActionResult Admin_Login()
        { return View(); }
        [HttpPost]
        public ActionResult Admin_Login(FormCollection fc)
        {
            int res = db.Admin_Login(fc["adminid"], fc["Password"]);
            if (res == 1)
            {
                FormsAuthentication.SetAuthCookie(fc["Admin_Id"],true);
                return RedirectToAction("Profile");
            }
            else {
                TempData["msg"] = "Admin Id and Password is wrong...";
            }
            return View();
        }
        [Authorize]
        public ActionResult Profile()
        {
            return View();
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return View();
        }
    }
}