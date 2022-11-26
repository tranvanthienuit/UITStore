using System;
using System.Collections.Generic;
using System.Text;

namespace UITStore.Models
{
    public class OrderModel
    {
        public bool success { get; set; }
        public Order data { get; set; }
    }
    public class ListDetailOrder
    {
        public Guid productId { get; set; }
        public string image { get; set; }
        public string name { get; set; }
        public double price { get; set; }
        public int size { get; set; }
        public int quantity { get; set; }
    }
    public class RequestOrder
    {
        public Guid userId { get; set; }
        public string fullName { get; set; }
        public string telephone { get; set; }
        public string address { get; set; }
        public double total { get; set; }
        public string status { get; set; }
        public List<ListDetailOrder> DetailOrders { get; set; }
    }
    public class ListOrder
    {
        public bool success { get; set; }
        public List<Order> data { get; set; }
    }
    public class DataDetailOrder
    {
        public bool success { get; set; }
        public List<DetailOrder> data { get; set; } 
    }
    public class DeleteOrder
    {
        public bool success { get; set; }
        public bool data { get; set; }
    }
}
