using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcApp.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Encryption()
        {
            ViewBag.EncryptedCookie = Convert.ToBase64String(
                MachineKey.Protect(Encoding.UTF8.GetBytes("Your cookie value"), "none"));
            HttpCookie cookie = new HttpCookie("encrypted", "Your cookie value");
            cookie.Secure = true;
            cookie.Expires = DateTime.Now.AddDays(1);
            HttpContext.Request.Cookies.Add(cookie);
            ViewBag.DecryptedCookie = Encoding.UTF8.GetString
                (MachineKey.Unprotect(
                    Convert.FromBase64String(ViewBag.EncryptedCookie), "none"));
            return View();
        }
    }
}