using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using NorthwindRepository.Interfaces;
using NorthwindRepository.Repositories;
using DataAccessLayer;

using Telerik.JustMock;

using MvcBootcamp.Web.Controllers;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq; //syntax linq

//Diminta untuk mencari tahu mengenai Dependencies Injector
//

namespace MvcBootcamp.Web.Tests
{
    [TestClass]
    public class CustomerMockTest
    {
        [TestMethod]
        public void GetAllData_ReturnAllCustomer()
        {
            //Mock akan create sebuah class yang mengimplementasikan IENtityRepository
            var custRepo = Mock.Create<IEntityRepository<Customer, string>>();

            Mock.Arrange(() => custRepo.GetAllData()).Returns(
                new List<Customer>()
                {
                    new Customer {CustomerID="1", CompanyName="Native 1" },
                    new Customer {CustomerID="2", CompanyName="Native 2" },
                    new Customer {CustomerID="3", CompanyName="Native 3" },
                    new Customer {CustomerID="4", CompanyName="Native 4" },
                }.AsQueryable()).MustBeCalled();
             

            CustomersController controller = new CustomersController(custRepo);
            ViewResult view = controller.Index() as ViewResult;
            var model = view.Model as IEnumerable<Customer>;

            Assert.AreEqual(4, model.Count());
            Assert.IsNotNull(model);
            Assert.AreEqual("Native 2", model.ToList()[1].CompanyName);
        }

        [TestMethod]
        public void Search_ReturnACustomer()
        {
            //Mock akan create sebuah class yang mengimplementasikan IENtityRepository
            var custRepo = Mock.Create<IEntityRepository<Customer, string>>();

            Mock.Arrange(() => custRepo.Search("1")).Returns(
                new Customer
                {
                    CustomerID="1", CompanyName="Native 1"
                }).MustBeCalled();


            CustomersController controller = new CustomersController(custRepo);
            ViewResult view = controller.Details("1") as ViewResult;
            var model = view.Model as Customer;

            Assert.AreEqual("Native 1", model.CompanyName);
        }
    }
}
