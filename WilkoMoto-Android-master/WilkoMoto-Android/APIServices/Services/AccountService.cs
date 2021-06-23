using System;
using System.Net.Http;
using System.Threading.Tasks;
using WilkoMoto_Android.APIServices.Helpers;
using WilkoMoto_Android.Models.Requests;

namespace WilkoMoto_Android.APIServices.Services
{
    public class AccountService
    {
        private readonly string BaseAddress = $"{ApiConsts.BaseURL}{ApiConsts.Account}";

        public async Task<string> LoginAsync(LoginRequest request)
        {
            var data = ApiHelper.CreateJSONStringContent(request);

            var response = await SendLoginRequestAsync(data, "/login");

            return ApiHelper.GetResponseContent(response);
        }

        private async Task<HttpResponseMessage> SendLoginRequestAsync(StringContent data, string endpoint)
        {
            using var client = new HttpClient();

            var response = await client.PostAsync($"{BaseAddress}{endpoint}", data);

            return response;
        }
    }
}
