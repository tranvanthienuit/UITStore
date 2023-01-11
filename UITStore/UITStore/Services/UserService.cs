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
    public class UserService : IUserService
    {
        private static UserService _ServiceClientInstance;
        public static UserService ServiceClientInstance
        {
            get
            {
                if (_ServiceClientInstance == null)
                    _ServiceClientInstance = new UserService();
                return _ServiceClientInstance;
            }
        }
        private HttpClient client = new HttpClient();
        public UserService()
        {
            client.BaseAddress = new Uri("https://backenduit.azurewebsites.net/api/v1/user/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<UserModel> AddUser(RequestUser user)
        {
           try
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PostAsync("create", content).Result;
                string responseRead = await response.Content.ReadAsStringAsync();
                UserModel data = JsonConvert.DeserializeObject<UserModel>(responseRead);
                return await Task.FromResult(data);
            } catch (Exception)
            {
                return null;
            }
        }

        public async Task<UserModel> Login(LoginModel login)
        {
            try
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(login), Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PostAsync("login", content).Result;
                string responseRead = await response.Content.ReadAsStringAsync();
                UserModel data = JsonConvert.DeserializeObject<UserModel>(responseRead);
                return await Task.FromResult(data);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<UserModel> UpdateUser(User user)
        {
            try
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PutAsync("update", content).Result;
                string responseRead = await response.Content.ReadAsStringAsync();
                UserModel data = JsonConvert.DeserializeObject<UserModel>(responseRead);
                return await Task.FromResult(data);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<UserModel> ChangePassword(Guid id, string password)
        {
            try
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(password), Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PostAsync($"{id}/change-password", content).Result;
                string responseRead = await response.Content.ReadAsStringAsync();
                UserModel data = JsonConvert.DeserializeObject<UserModel>(responseRead);
                return await Task.FromResult(data);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<UserModel> GetUserById(Guid id)
        {
            try
            {
                HttpResponseMessage response = client.GetAsync($"{id}/detail").Result;
                string responseRead = await response.Content.ReadAsStringAsync();
                UserModel data = JsonConvert.DeserializeObject<UserModel>(responseRead);
                return await Task.FromResult(data);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<ListUserModel> GetListUser()
        {
            try
            {
                HttpResponseMessage response = client.GetAsync("list").Result;
                string responseRead = await response.Content.ReadAsStringAsync();
                ListUserModel data = JsonConvert.DeserializeObject<ListUserModel>(responseRead);
                return await Task.FromResult(data);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
