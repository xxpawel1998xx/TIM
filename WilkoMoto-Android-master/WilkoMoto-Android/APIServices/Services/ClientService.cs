using System;
using System.Net.Http;
using System.Threading.Tasks;
using WilkoMoto_Android.APIServices.Helpers;

namespace WilkoMoto_Android.APIServices.Services
{
    public class ClientService
    {
        private readonly string BaseAddress = $"{ApiConsts.BaseURL}{ApiConsts.Client}";

        public async Task<string> PickAsync(int userId, int carId)
        {
            var response = await SendPick(userId, carId);

            return ApiHelper.GetResponseContent(response);
        }

        public async Task<string> UnpickAsync(int userId, int carId)
        {
            var response = await SendUnpick(userId, carId);

            return ApiHelper.GetResponseContent(response);
        }

        private async Task<HttpResponseMessage> SendPick(int userId, int carId)
        {
            using var client = new HttpClient();

            ApiHelper.AddAuthorizationHeader(client);

            var response = await client.PostAsync($"{BaseAddress}/{userId}/pick/{carId}", null);

            return response;
        }

        private async Task<HttpResponseMessage> SendUnpick(int userId, int carId)
        {
            using var client = new HttpClient();

            ApiHelper.AddAuthorizationHeader(client);

            var response = await client.PostAsync($"{BaseAddress}/{userId}/unpick/{carId}", null);

            return response;
        }

    }
}
