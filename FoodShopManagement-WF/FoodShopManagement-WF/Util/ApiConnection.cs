using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FoodShopManagement_WF.Util
{
    public class ApiConnection
    {
        public static string URI = "https://localhost:44314/api/FoodShopManagement/";
        public static HttpResponseMessage loadPostJsonObjectLogin(string function, Object inputObj)
        {
            string json = JsonConvert.SerializeObject(inputObj);
            StringContent data = new StringContent(json, Encoding.UTF8, "application/json");
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(URI);
            HttpResponseMessage responseMessage = httpClient.PostAsync(function, data).Result;
            return responseMessage;
        }
        public static HttpResponseMessage loadPostJsonObject(string function, Object inputObj,string token)
        {
            string json = JsonConvert.SerializeObject(inputObj);
            StringContent data = new StringContent(json, Encoding.UTF8, "application/json");
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Authorization", token);
            httpClient.BaseAddress = new Uri(URI);
            HttpResponseMessage responseMessage = httpClient.PostAsync(function, data).Result;
            return responseMessage;
        }
        public static HttpResponseMessage loadPutJsonObject(string function, Object inputObj, string token)
        {
            string json = JsonConvert.SerializeObject(inputObj);
            StringContent data = new StringContent(json, Encoding.UTF8, "application/json");
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Authorization", token);
            httpClient.BaseAddress = new Uri(URI);
            HttpResponseMessage responseMessage = httpClient.PutAsync(function, data).Result;
            return responseMessage;
        }
        public static HttpResponseMessage loadGetJsonObject(string function, string token)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(URI);
            httpClient.DefaultRequestHeaders.Add("Authorization", token);
            HttpResponseMessage responseMessage = httpClient.GetAsync(function).Result;
            return responseMessage;
        }
        public static HttpResponseMessage loadGetJsonObject(string function,Dictionary<String,String> hashParam, string token)
        {
            if (hashParam != null)
            {
                function += "?";
                foreach (var entry in hashParam)
                {
                    function += entry.Key;
                    function += "=";
                    function += entry.Value;
                    function += "&";
                }
            }
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(URI);
            httpClient.DefaultRequestHeaders.Add("Authorization", token);
            HttpResponseMessage responseMessage = httpClient.GetAsync(function).Result;
            return responseMessage;
        }
    }
}
