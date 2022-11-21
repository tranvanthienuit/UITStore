using System;
using System.Collections.Generic;
using System.Text;

namespace UITStore.Models
{
    public class Order
    {
        public string id { get; set; }
        public string userid { get; set; }
        public string fullname { get; set; }
        public string telephone { get; set; }
        public string address { get; set; }
        public double total { get; set; }
        public string status { get; set; } = "Đang xử lý";
    }
}
