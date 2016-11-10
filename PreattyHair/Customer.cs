
using System;
using System.Collections.Generic;

namespace PrettyHair {

    public class Customer {
        public string Address { get; internal set; }
        public int ID { get; internal set; }
        public string Name { get; internal set; }
        public List<Order> Orders;

        public Customer(int v1, string v2, string v3) {
            Orders = new List<Order>();
            ID = v1;
            Name = v2;
            Address = v3;
        }

        public Customer() {
            Orders = new List<Order>();
        }

        public void CreateOrder(string v1, string v2, int v3) {
            Orders.Add(new Order() { orderDate = v1, deliveryDate = v2, ordernumber = v3});
        }
    }
}
