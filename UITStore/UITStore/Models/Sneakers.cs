using System;

namespace UITStore.Models
{
    public class Sneakers
    {
        public Guid id { get; set; }
        public string name { get; set; }
        public string size { get; set; }
        public int stock { get; set; }
        public double price { get; set; }
        public string description { get; set; }
        public string category { get; set; }
        public double salePrice { get; set; }
        public string image { get; set; }
        public double discount {  get; set;}
        public double rating { get; set; }
        public DateTime createDate { get; set; }
        
        
    }
}