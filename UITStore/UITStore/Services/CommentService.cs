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
    public class CommentService : ICommentService
    {
        private static CommentService _ServiceClientInstance;
        public static CommentService ServiceClientInstance
        {
            get
            {
                if (_ServiceClientInstance == null)
                    _ServiceClientInstance = new CommentService();
                return _ServiceClientInstance;
            }
        }
        private HttpClient client = new HttpClient();
        public CommentService()
        {
            client.BaseAddress = new Uri("https://backenduit.azurewebsites.net/api/v1/comment/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<CommentModel> AddComment(CommentRequest cmtRequest)
        {
            try
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(cmtRequest), Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PostAsync("create", content).Result;
                string responseRead = await response.Content.ReadAsStringAsync();
                CommentModel data = JsonConvert.DeserializeObject<CommentModel>(responseRead);
                return await Task.FromResult(data);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<CommentByProduct> GetComment(Guid productId)
        {
            try
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(""), Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PostAsync($"ASC/0/100/page?productId={productId}", content).Result;
                string responseRead = await response.Content.ReadAsStringAsync();
                CommentByProduct data = JsonConvert.DeserializeObject<CommentByProduct>(responseRead);
                return await Task.FromResult(data);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<DeleteComment> DeleteComment(Guid id)
        {
            try
            {
                HttpResponseMessage response = client.DeleteAsync($"{id}/delete").Result;
                string responseRead = await response.Content.ReadAsStringAsync();
                DeleteComment data = JsonConvert.DeserializeObject<DeleteComment>(responseRead);
                return await Task.FromResult(data);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
