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
    public class SneakerService : ISneakerService
    {
        private static SneakerService _ServiceClientInstance;
        public static SneakerService ServiceClientInstance
        {
            get
            {
                if (_ServiceClientInstance == null)
                    _ServiceClientInstance = new SneakerService();
                return _ServiceClientInstance;
            }
        }
        private HttpClient client = new HttpClient();
        public SneakerService()
        {
            client.BaseAddress = new Uri("https://backenduit.azurewebsites.net/api/v1/product/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public async Task<SneakerModel> GetSneaker()
        {
            try
            {
                HttpResponseMessage response = client.GetAsync("list").Result;
                string responseRead = await response.Content.ReadAsStringAsync();
                SneakerModel data = JsonConvert.DeserializeObject<SneakerModel>(responseRead);
                return await Task.FromResult(data);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<SneakerModel> SneakerFilter(int size,string type, string filter)
        {
            try
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(""), Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PostAsync($"ASC/0/{size}/page?{type}={filter}", content).Result;
                string responseRead = await response.Content.ReadAsStringAsync();
                SneakerModel data = JsonConvert.DeserializeObject<SneakerModel>(responseRead);
                return await Task.FromResult(data);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<ResponseUpdateSneaker> UpdateSneaker(Sneakers sneakers)
        {
            try
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(sneakers), Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PutAsync("update", content).Result;
                string responseRead = await response.Content.ReadAsStringAsync();
                ResponseUpdateSneaker data = JsonConvert.DeserializeObject<ResponseUpdateSneaker>(responseRead);
                return await Task.FromResult(data);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<ResponseUpdateSneaker> GetSneakerById(Guid id)
        {
            try
            {
                HttpResponseMessage response = client.GetAsync($"{id}/detail").Result;
                string responseRead = await response.Content.ReadAsStringAsync();
                ResponseUpdateSneaker data = JsonConvert.DeserializeObject<ResponseUpdateSneaker>(responseRead);
                return await Task.FromResult(data);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<ResponseUpdateSneaker> AddSneaker(RequestSneaker sneaker)
        {
            try
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(sneaker), Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PostAsync("create", content).Result;
                string responseRead = await response.Content.ReadAsStringAsync();
                ResponseUpdateSneaker data = JsonConvert.DeserializeObject<ResponseUpdateSneaker>(responseRead);
                return await Task.FromResult(data);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<DeleteSneaker> DeleteSneaker(Guid id)
        {
            try
            {
                HttpResponseMessage response = client.DeleteAsync($"{id}/delete").Result;
                string responseRead = await response.Content.ReadAsStringAsync();
                DeleteSneaker data = JsonConvert.DeserializeObject<DeleteSneaker>(responseRead);
                return await Task.FromResult(data);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
