using System;

namespace PrintOrders
    {
    public class Orders
        {
        public int OrderID { get; set; }
        public int ClientID { get; set; }
        public string ClientName { get; set; }
        public string CPF { get; set; }
        public string CarID { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Price { get; set; }
        public DateTime PurchaseDate { get; set; }
        }
    }
