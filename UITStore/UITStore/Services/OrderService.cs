using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using UITStore.Models;

namespace UITStore.Services
{
    public class OrderService : IOrderService
    {
        private static OrderService _ServiceClientInstance;
        public static OrderService ServiceClientInstance
        {
            get
            {
                if (_ServiceClientInstance == null)
                    _ServiceClientInstance = new OrderService();
                return _ServiceClientInstance;
            }
        }
        private HttpClient client = new HttpClient();
        public OrderService()
        {
            client.BaseAddress = new Uri("https://backenduit.azurewebsites.net/api/v1/order/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public async Task<OrderModel> AddOrder(RequestOrder requestOrder)
        {
            try
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(requestOrder), Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PostAsync("create/order", content).Result;
                string responseRead = await response.Content.ReadAsStringAsync();
                OrderModel data = JsonConvert.DeserializeObject<OrderModel>(responseRead);
                return await Task.FromResult(data);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<ListOrder> GetOrderByUserid(Guid id)
        {
            try
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(""), Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PostAsync($"ASC/0/100/page?userId={id}", content).Result;
                string responseRead = await response.Content.ReadAsStringAsync();
                ListOrder data = JsonConvert.DeserializeObject<ListOrder>(responseRead);
                return await Task.FromResult(data);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<DataDetailOrder> GetDataDetailOrder(Guid id)
        {
            try
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(""), Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PostAsync("https://backenduit.azurewebsites.net/api/v1/detail-order/ASC/0/100/page?orderId=" + $"{id}", content).Result;
                string responseRead = await response.Content.ReadAsStringAsync();
                DataDetailOrder data = JsonConvert.DeserializeObject<DataDetailOrder>(responseRead);
                return await Task.FromResult(data);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<DeleteOrder> DeleteOrder(Guid id)
        {
            try
            {
                HttpResponseMessage response = client.DeleteAsync($"{id}/delete").Result;
                string responseRead = await response.Content.ReadAsStringAsync();
                DeleteOrder data = JsonConvert.DeserializeObject<DeleteOrder>(responseRead);
                return await Task.FromResult(data);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<DeleteOrder> DeleteDetailOrder(Guid id)
        {
            try
            {
                HttpResponseMessage response = client.DeleteAsync("https://backenduit.azurewebsites.net/api/v1/detail-order/" + $"{id}/delete").Result;
                string responseRead = await response.Content.ReadAsStringAsync();
                DeleteOrder data = JsonConvert.DeserializeObject<DeleteOrder>(responseRead);
                return await Task.FromResult(data);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
