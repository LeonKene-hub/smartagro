using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SmartAgro.Services
{
    public static class ApiService
    {

        private static HttpClient client;

        public static HttpClient Client
        {
            get {
                if (client == null)
                {
                    client = new HttpClient();
                    client.BaseAddress = new Uri("https://smartagroapi.azurewebsites.net/api/");
                }
                return client; }
        }


        public static void SetAuthToken(string token)
        {
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
        }

        public static HttpContent ToBodyContent(object obj)
        {
            var json = JsonConvert.SerializeObject(obj);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            return content;
        }

        public async static Task<T> Desserialize<T>(this HttpResponseMessage response) where T : class
        {
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(content);
        }

        public async static Task<List<T>> DesserializeList<T>(this HttpResponseMessage response) where T : class
        {
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<T>>(content);
        }


    }
}
