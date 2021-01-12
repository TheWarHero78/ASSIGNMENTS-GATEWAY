using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Products_AarshModi.Models
{
    public class Product
    {
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public string SmallImage { get; set; }
        public string LargeImage { get; set; }

        public virtual Category tblCategory { get; set; }
    }
}