using Microsoft.AspNetCore.Components;

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http.Json;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AONLOGBOOK.MAUI.Services
{

    public interface IHttpService
    {
       
        Task<T> Get<T>(string uri);
       
        Task Post(string uri, object value);
        Task<T> Post<T>(string uri, object value);
        Task Put(string uri, object value);
        Task<T> Put<T>(string uri, object value);
        Task Delete(string uri);
        Task<T> Delete<T>(string uri);
    }

    public class HttpServices : IHttpService
    {
        private HttpClient _httpClient;
        private NavigationManager _navigationManager;


        public HttpServices(HttpClient httpClient, NavigationManager navigationManager)
        {
            _httpClient = httpClient;
            _navigationManager = navigationManager;
        }

        public async Task<T> Get<T>(string uri)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, uri);
            return await sendRequest<T>(request);
        }

        public async Task<DataTable> GetDataTable(string uri)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, uri);
            var response = await _httpClient.SendAsync(request);

            await handleErrors(response);

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            string dataString = await response.Content.ReadAsStringAsync();
            return (DataTable)Newtonsoft.Json.JsonConvert.DeserializeObject(dataString, (typeof(DataTable)));
        }



        public async Task Post(string uri, object value)
        {
            var request = createRequest(HttpMethod.Post, uri, value);
            await sendRequest(request);
        }

        public async Task<T> Post<T>(string uri, object value)
        {
            var request = createRequest(HttpMethod.Post, uri, value);
            return await sendRequest<T>(request);
        }

        public async Task Put(string uri, object value)
        {
            var request = createRequest(HttpMethod.Put, uri, value);
            await sendRequest(request);
        }

        public async Task<T> Put<T>(string uri, object value)
        {
            var request = createRequest(HttpMethod.Put, uri, value);
            return await sendRequest<T>(request);
        }

        public async Task Delete(string uri)
        {
            var request = createRequest(HttpMethod.Delete, uri);
            await sendRequest(request);
        }

        public async Task<T> Delete<T>(string uri)
        {
            var request = createRequest(HttpMethod.Delete, uri);
            return await sendRequest<T>(request);
        }

        // helper methods

        private HttpRequestMessage createRequest(HttpMethod method, string uri, object value = null)
        {
            var request = new HttpRequestMessage(method, uri);
            if (value != null)
               request.Content = new StringContent(JsonSerializer.Serialize(value), Encoding.UTF8, "application/json");
            return request;
        }

        private async Task sendRequest(HttpRequestMessage request)
        {
            // send request
            using var response = await _httpClient.SendAsync(request);

            // auto logout on 401 response
            await handleErrors(response);
        }

        private async Task<T> sendRequest<T>(HttpRequestMessage request)
        {


            using var response = await _httpClient.SendAsync(request);

            await handleErrors(response);
            if(typeof(T).ToString()=="System.String")
            {
                var data =await response.Content.ReadAsStringAsync();
                return (T)Convert.ChangeType(data,typeof(T));
            }

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,

                //PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            };

            return await response.Content.ReadFromJsonAsync<T>(options);

        }

        private async Task<string> sendPostRequest(HttpRequestMessage request)
        {
            using var response = await _httpClient.SendAsync(request);

            await handleErrors(response);

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,

                //PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            };

         return await response.Content.ReadAsStringAsync();

        }

        private static List<T> ConvertDataTable<T>(DataTable dt)
        {
            List<T> data = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                T item = GetItem<T>(row);
                data.Add(item);
            }
            return data;
        }
        private static T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name == column.ColumnName)
                        pro.SetValue(obj, dr[column.ColumnName], null);
                    else
                        continue;
                }
            }
            return obj;
        }


        private async Task handleErrors(HttpResponseMessage response)
        {
            // throw exception on error response
            if (!response.IsSuccessStatusCode)
            {
                //var error = await response.Content.ReadFromJsonAsync<string>();
                //error.Add("message", error);
                throw new Exception(response.ReasonPhrase);
            }
        }

    }
}
