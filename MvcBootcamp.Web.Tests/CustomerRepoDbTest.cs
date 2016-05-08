using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using DataAccessLayer;
using NorthwindRepository.Repositories;
using System.Linq;

namespace MvcBootcamp.Web.Tests
{
    [TestClass]
    public class CustomerRepoDbTest
    {
        [TestMethod]
        public void GetAllData_ReturnAllCustomer()
        {
            var repo = new CustomerRepository();
            var allCust = repo.GetAllData().ToList();
            Assert.AreEqual(92, allCust.Count());
        }

        [TestMethod]
        public void Search_ReturnACustomer()
        {
            var repo = new CustomerRepository();
            var cust = repo.Search("ALFKI");
            Assert.AreNotEqual("Alfred F", cust.CompanyName);
        }
    }
}
