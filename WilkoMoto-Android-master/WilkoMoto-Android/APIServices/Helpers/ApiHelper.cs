using System;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using WilkoMoto_Android.Helpers;

namespace WilkoMoto_Android.APIServices.Helpers
{
    public class ApiHelper
    {
        public static StringContent CreateJSONStringContent(object request)
        {
            var json = JsonConvert.SerializeObject(request);

            var data = new StringContent(json, Encoding.UTF8, "application/json");

            return data;
        }

        public static string GetResponseContent(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;

                return result;
            }

            throw new Exception(response.StatusCode.ToString());
        }

        public static void AddAuthorizationHeader(HttpClient client)
        {
            var token = LocalStorage.GetToken();

            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
        }
    }
}
