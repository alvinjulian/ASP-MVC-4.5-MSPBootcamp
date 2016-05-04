using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcBootcamp.Web.Controllers
{
    public class StoreController : Controller
    {
        // GET: Store
        public string Index()
        {
            return "Hello from Store.Index";
        }

        public string Browse(string category)
        {
            return HttpUtility.HtmlEncode("Hello from Browse with category: " + category);
        }

        public string News(int year, int month, int day)
        {
            return HttpUtility.HtmlEncode("Hello from Store.News with year: " + year + ", month: " + month + ", day: " + day);
        }

        public ActionResult Home()
        {
            //return View();
            //return View("About"); //selama controllernya sama bisa
            return View("~/Views/Home/About.cshtml"); //kalau ada di controller yang berbeda
        }

        //public ActionResult About()
        //{
        //    return View()
        //}

        public ActionResult DataSample()
        {
            ViewData["event"] = "MSP Bootcamp";
            ViewData["place"] = "Hotel Neo";

            ViewBag.events = "MSP Bootcamp";
            ViewBag.place = "Hotel Neo"; //dynamic object

            var books = new List<string>() { "ASP.NET", "Ms SQL Server", "Windows 10" };
            ViewBag.booklist = books;


            return View();

        }
        public ViewResult StronglyTypeView()
        {
            var newCust = new Models.Customer()
            {
                CompanyName = "Native Enterprise",
                City = "Bandung"
            };

            return View(newCust);
        }

        public ViewResult hw()
        {
            List<Models.Customer> newCust = new List<Models.Customer>()
            {
                new Models.Customer() {CompanyName = "Microsoft", City="United States of America" },
                new Models.Customer() {CompanyName = "TOA", City = "Japan" },
                new Models.Customer() {CompanyName = "SONY", City = "Japan" }
            };
            return View(newCust);
        }
    }
}