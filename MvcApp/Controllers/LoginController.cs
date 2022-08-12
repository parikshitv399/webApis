using MvcApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApp.Controllers
{
    public class LoginController : Controller
    {
        private readonly UserOps _userDb = new UserOps();
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(User pUser)
        {
            User foundUser = _userDb.FindUser(pUser.Username);
            if(foundUser == null)
            {
                return View("Login");
            }
            Session["username"] = foundUser.Username;
            return View("Dashboard");
        }
    }
}