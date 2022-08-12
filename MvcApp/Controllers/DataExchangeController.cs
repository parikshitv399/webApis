using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApp.Controllers
{
    public class DataExchangeController : Controller
    {
        // GET: DataExchange
        public ActionResult Index()
        {
            string title = "Dynamic Title";
            ViewBag.Title = title;
            ViewBag.Username = "Parikshit";
            ViewBag.Age = 25;
            //Add a list to the ViewBag
            List<string> shoppingItems = new List<string>() { "Apparels","Groceries","Video Games"};
            ViewBag.ShoppingItems = shoppingItems;
            return View();

        }
        public ActionResult UsingViewData()
        {
            ViewData["Name"] = "Lalalala";
            ViewData["EmpID"] = 121984;
            ViewData["Awards"] = new List<string>() { "Spot Award", "Best Performer" };

            return View();
        }
        public ActionResult UsingSessionData()
        {
            Session["LoginEmail"] = "parikshitverma@kpmg.com";
            return View();
        }
    }
}