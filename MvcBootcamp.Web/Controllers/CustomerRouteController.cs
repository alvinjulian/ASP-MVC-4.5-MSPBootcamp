using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NorthwindRepository.Repositories;

namespace MvcBootcamp.Web.Controllers
{
    [RoutePrefix("CustomerData")]
    public class CustomerRouteController : Controller
    {
        private CustomerRepository custRepo = new CustomerRepository();
        // GET: CustomerAJAX

        //[Route("CustomerData/AllCustomer")]
        [Route("AllCustomer")] // kalau pakai prefix
        public ActionResult Index()
        {
            return View(custRepo.GetAllData().Take(5));
        }

        //[Route("CustomerData/{id}")]
        [Route("{id}")] //kalau pakai prefix
        public ActionResult Search(string id)
        {
            return View(custRepo.Search(id));
        }
    }
}