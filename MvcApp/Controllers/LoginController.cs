using MvcApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcApp.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly UserOps _userDb = new UserOps();
        // GET: Login
        public ActionResult Login()
        {
            _userDb.GetAll();
            return View();
        }
        [HttpPost]
        public ActionResult Login(User pUser)
        {
            User foundUser = _userDb.FindUser(pUser.Username);
            if (foundUser == null)
            {
                return View("Login");
            }
            else if (foundUser.Username == pUser.Username && foundUser.Password == pUser.Password)
            {
                FormsAuthentication.SetAuthCookie(foundUser.Username, false);
                Session["username"] = foundUser.Username;
                return View("Dashboard");
            }
            ModelState.AddModelError("Password","Identity theft is not a joke JIM! Millions of people suffer everyday!");
            return View("Login");
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}