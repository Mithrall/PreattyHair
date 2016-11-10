using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Security.Cryptography.X509Certificates;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PrettyHair {
    [TestClass]
    public class UnitTest1
    {
        public List<Customer> Customers;

        [TestInitialize]
        public void SetupForTest() {
            Customers = new List<Customer>();
            Customers.Add(new Customer() { ID = 1, Name = "Peter", Address = "Vibevej 1 Odense"});
            Customers.Add(new Customer() { ID = 2, Name = "Jesper", Address = "Vibevej 2 Odense"});
        }

        [TestMethod]
        public void CustomerSearchByID() {
            //Customer 1
            Assert.AreEqual(1, Customers.Find(x => x.ID == 1).ID);
            Assert.AreEqual("Peter", Customers.Find(x => x.ID == 1).Name);
            Assert.AreEqual("Vibevej 1 Odense", Customers.Find(x => x.ID == 1).Address);
            
            //Customer 2
            Assert.AreEqual(2, Customers.Find(x => x.ID == 2).ID);
            Assert.AreEqual("Jesper", Customers.Find(x => x.ID == 2).Name);
            Assert.AreEqual("Vibevej 2 Odense", Customers.Find(x => x.ID == 2).Address);
        }

        [TestMethod]
        public void ACustomerCanBeRegistered() {
            Customers.Add(new Customer() { ID = 3, Name = "Hans", Address = "Vibevej 17 Odense" });
            Assert.IsNotNull(Customers.Find(x => x.ID == 3));

        }

        [TestMethod]
        public void CanCreateAnOrder()
        {
            Customer tempCustomer = Customers.Find(x => x.ID == 1);
            tempCustomer.CreateOrder("12/12-2016", "16/12-2016", 1);

            Assert.AreEqual(1, tempCustomer.Orders.First().ordernumber);
            Assert.AreEqual("12/12-2016", tempCustomer.Orders.First().orderDate);
            Assert.AreEqual("16/12-2016", tempCustomer.Orders.First().deliveryDate);
        }
    }
}
