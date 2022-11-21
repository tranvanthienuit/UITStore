using System;
using System.Collections.Generic;
using System.Text;

namespace UITStore.Models
{
    public class Comment
    {
        public string id { get; set; }
        public string productid { get; set; }
        public string userid { get; set; }
        public int rating { get; set; }
        public string content { get; set; }
    }
}
