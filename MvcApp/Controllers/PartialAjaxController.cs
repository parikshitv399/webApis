using MvcApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApp.Controllers
{
    public class PartialAjaxController : Controller
    {
        private readonly UserOps _userDb = new UserOps();
        // GET: PartialAjax
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ShowItems()
        {
            return PartialView("_ShowItems");
        }
        public ActionResult ShowAjaxIndexPage()
        {
            return View("UsingAjax");
        }
        public ActionResult UsingAjax(string username)
        {
            var user = new UserOps().FindUser(username);
            return RedirectToAction("Details", "User", user);
        }
        [HttpGet]
        public ActionResult SearchUser()
        {
            return View(new User());
        }
        [HttpPost]
        public ActionResult SearchUser(User pUser)
        {
            return RedirectToAction("Details", "User", new { username = pUser.Username });
        }
        [HttpPost]
        public ActionResult MatchUser(string pUser)
        {
            return View(_userDb.MatchUser(pUser));
        }
    }
}