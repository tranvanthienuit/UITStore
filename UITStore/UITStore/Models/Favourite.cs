using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace UITStore.Models
{
    public class Favourite
    {
        [PrimaryKey] [AutoIncrement] public int id { get; set; }
        public string sneakerId { get; set; }
        public int userid { get; set; }
        public string img { get; set; }
        public string name { get; set; }
        public double price { get; set; }
        public double saleprice { get; set; }
        public string description { get; set; }
        public string size { get; set; }
        public int stock { get; set; }
        public string category { get; set; }
        public double discount { get; set; }
        public double rating { get; set; }
    }
}
