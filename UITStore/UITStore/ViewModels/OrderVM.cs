using System;
using System.Collections.Generic;
using System.Text;
using UITStore.Models;
using UITStore.Services;

namespace UITStore.ViewModels
{
    public class OrderVM
    {
        public bool AddNewOrder(Guid UserId, string FullName, string Telephone, string Address, double Total, List<ListDetailOrder> listDetailOrders)
        {
            RequestOrder requestOrder = new RequestOrder
            {
                userId = UserId, fullName = FullName, telephone = Telephone, address = Address, total = Total, status = "Đang xử lý",
                DetailOrders = listDetailOrders
            };
            OrderModel result = OrderService.ServiceClientInstance.AddOrder(requestOrder).Result;
            if (result.success)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public List<Order> GetOrderByUserId(Guid id)
        {
            ListOrder result = OrderService.ServiceClientInstance.GetOrderByUserid(id).Result;
            if(result.success)
            {
                List<Order> orders = result.data;
                return orders;
            } else
            {
                return null;
            }
        }
        public List<DetailOrder> GetDetailOrders(Guid id)
        {
            DataDetailOrder result = OrderService.ServiceClientInstance.GetDataDetailOrder(id).Result;
            if (result.success)
            {
                List<DetailOrder> detailOrders = result.data;
                return detailOrders;
            }
            else
            {
                return null;
            }
        }
        public bool DeleteOrder(Guid id)
        {
            DeleteOrder result = OrderService.ServiceClientInstance.DeleteOrder(id).Result;
            if (result.success)
            {
               
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool DeleteDetailOrder(Guid id)
        {
            List<DetailOrder> list = GetDetailOrders(id);
            foreach(var item in list)
            {
                _ = OrderService.ServiceClientInstance.DeleteDetailOrder(item.id).Result;
            }
            return true;
        }
    }
}
