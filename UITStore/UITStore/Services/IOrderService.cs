using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UITStore.Models;

namespace UITStore.Services
{
    public interface IOrderService
    {
        Task<OrderModel> AddOrder(RequestOrder requestOrder);
        Task<ListOrder> GetOrderByUserid(Guid id);
        Task<DataDetailOrder> GetDataDetailOrder(Guid id);
        Task<DeleteOrder> DeleteOrder(Guid id);
        Task<DeleteOrder> DeleteDetailOrder(Guid id);
    }
}
