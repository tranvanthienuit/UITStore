using System;
using System.Collections.Generic;
using System.Text;

namespace UITStore.Models
{
    public class DetailOrder
    {
        public string id { get; set; }
        public string orderid { get; set; }
        public string productid { get; set; }
        public string img { get; set; }
        public string name { get; set; }
        public double price { get; set; }
        public int productsize { get; set; }
        public int quantity { get; set; }
    }
   
}
