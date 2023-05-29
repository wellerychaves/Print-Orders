using System;

namespace PrintOrders
    {
    public class OrderDetail
        {
        public int OrderID { get; set; }
        public string ClientName { get; set; }
        public string CPF { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Price { get; set; }
        public DateTime PurchaseDate { get; set; }
        }
    }
