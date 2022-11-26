using System;
using System.Collections.Generic;
using System.Text;

namespace UITStore.Models
{
    public class SneakerModel
    {
        public bool success { get; set; }
        public List<Sneakers> data { get; set; }
    }
    public class ResponseUpdateSneaker
    {
        public bool success { get; set; }
        public Sneakers data { get; set; }
    }
    public class RequestSneaker
    {
        public string name { get; set; }
        public string size { get; set; }
        public int stock { get; set; }
        public double price { get; set; }
        public string description { get; set; }
        public string category { get; set; }
        public double salePrice { get; set; }
        public string image { get; set; }
        public double discount { get; set; }
        public double rating { get; set; }
    }
}
