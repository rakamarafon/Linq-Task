using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace Linq_Task.DAL
{
    public class HttpDataSource : IDataSource
    {
        private string GrabResponce(string endpoint)
        {
            string BASE_URL = "https://5b128555d50a5c0014ef1204.mockapi.io/";

            using (var client = new HttpClient())
            {
                var jsonData = client.GetStringAsync(BASE_URL + endpoint);
                return jsonData.Result;
            }
        }
        public List<Address> GetAddressesList()
        {
            string responce = GrabResponce("address");
            return JsonConvert.DeserializeObject<List<Address>>(responce);
        }

        public List<Comments> GetCommentsList()
        {
            string responce = GrabResponce("comments");
            return JsonConvert.DeserializeObject<List<Comments>>(responce);
        }

        public List<Posts> GetPostsList()
        {
            string responce = GrabResponce("posts");
            return JsonConvert.DeserializeObject<List<Posts>>(responce);
        }    

        public List<Todos> GetTodosList()
        {
            string responce = GrabResponce("todos");
            return JsonConvert.DeserializeObject<List<Todos>>(responce);
        }

        public List<Users> GetUsersList()
        {
            string responce = GrabResponce("users");
            return JsonConvert.DeserializeObject<List<Users>>(responce);
        }
    }
}
