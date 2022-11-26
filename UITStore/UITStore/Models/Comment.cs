using System;
using System.Collections.Generic;
using System.Text;

namespace UITStore.Models
{
    public class Comment
    {
        public Guid id { get; set; }
        public Guid productid { get; set; }
        public Guid userid { get; set; }
        public int rating { get; set; }
        public string content { get; set; }
    }
}
