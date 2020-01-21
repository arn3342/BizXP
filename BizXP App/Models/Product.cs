using System;

namespace BizXP_App.Models
{
    public class Product
    {
        public string ProductName { get; set; }
        public string Quantity { get; set; }
        public string BuyingPrice { get; set; }
        public string SellingPrice { get; set; }
        public DateTime StockAdded { get; set; }

    }
}