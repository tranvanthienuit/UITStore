using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace UITStore.Models
{
    public class Cart
    {
        [PrimaryKey] [AutoIncrement] public int id { get; set; }
        public int userid { get; set; }
        public string productid { get; set; }
        public string img { get; set; }
        public string name { get; set; }
        public double price { get; set; }
        public int productsize { get; set; }
        public int quantity { get; set; }

    }
    
}
