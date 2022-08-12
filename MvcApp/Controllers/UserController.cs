using MvcApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApp.Controllers
{
    public class UserController : Controller
    {
        private readonly UserOps _userDb = new UserOps();
        // GET: User
        public ActionResult Index()
        {
            return View(_userDb.GetAll());
        }
        [HttpGet]
        public ActionResult Details(string username)
        {
            return View(_userDb.FindUser(username));
        }
        [HttpGet]
        public ActionResult Edit(string username)
        {
            return View(_userDb.FindUser(username));
        }
        [HttpPost]
        public ActionResult Edit(User pUser)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _userDb.Update(pUser.Username, pUser);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("Not found error", ex.Message);
                    return View("Edit");
                }
            }
            return View("edit");            
        }
        [HttpGet]
        public ActionResult Delete(string username)
        {
            return View(_userDb.FindUser(username));
        }
        [HttpPost]
        public ActionResult Delete(User pUser)
        {
            _userDb.Delete(pUser);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View(new User());
        }
        [HttpPost]
        public ActionResult Register(User pUser)
        {
            _userDb.Add(pUser);
            return RedirectToAction("Login","Login");
        }
    }
}