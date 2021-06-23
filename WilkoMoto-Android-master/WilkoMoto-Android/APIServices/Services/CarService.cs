using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using WilkoMoto_Android.APIServices.Helpers;
using WilkoMoto_Android.Models.Requests;

namespace WilkoMoto_Android.APIServices.Services
{
    public class CarService
    {
        private readonly string BaseAddress = $"{ApiConsts.BaseURL}{ApiConsts.Car}";

        public async Task<string> GetSingle(int carId)
        {
            var response = await SendGetSingle(carId);

            return ApiHelper.GetResponseContent(response);
        }

        public async Task<string> DeleteCar(int carId)
        {
            var response = await SendRemoveCar(carId);

            return ApiHelper.GetResponseContent(response);
        }

        public async Task<string> EditCar(EditCarRequest request, int carId)
        {
            var data = ApiHelper.CreateJSONStringContent(request);

            var response = await SendEditCar(data, carId);

            return ApiHelper.GetResponseContent(response);
        }

        public async Task<string> AddCar(AddCarRequest request)
        {
            var response = await SendAddCar(request);

            return ApiHelper.GetResponseContent(response);
        }

        public async Task<string> GetCarsAsync()
        {
            var response = await SendGetAllCars();

            return ApiHelper.GetResponseContent(response);
        }

        private async Task<HttpResponseMessage> SendGetSingle(int carId)
        {
            using var client = new HttpClient();

            ApiHelper.AddAuthorizationHeader(client);

            var response = await client.GetAsync($"{BaseAddress}/{carId}");

            return response;
        }

        private async Task<HttpResponseMessage> SendRemoveCar(int carId)
        {
            using var client = new HttpClient();

            ApiHelper.AddAuthorizationHeader(client);

            var response = await client.DeleteAsync($"{BaseAddress}/delete/{carId}");

            return response;
        }

        private async Task<HttpResponseMessage> SendEditCar(StringContent data, int carId)
        {
            using var client = new HttpClient();

            ApiHelper.AddAuthorizationHeader(client);

            var response = await client.PutAsync($"{BaseAddress}/update/{carId}", data);

            return response;
        }

        private async Task<HttpResponseMessage> SendAddCar(AddCarRequest request)
        {
            using var client = new HttpClient();
            using var content = new MultipartFormDataContent();

            ApiHelper.AddAuthorizationHeader(client);

            var imageContent = new ByteArrayContent(request.File);
            imageContent.Headers.ContentType =
                MediaTypeHeaderValue.Parse("image/jpeg");

            content.Add(imageContent, "File", "image.jpg");
            content.Add(new StringContent(request.Brand), "Brand");
            content.Add(new StringContent(request.Car), "Car");
            content.Add(new StringContent(request.FuelType), "FuelType");
            content.Add(new StringContent(request.Year.ToString()), "Year");
            content.Add(new StringContent(request.Price.ToString()), "Price");
            content.Add(new StringContent(request.Mileage.ToString()), "Mileage");
            content.Add(new StringContent(string.Empty), "CarPhotoUrl");

            var response = await client.PostAsync($"{BaseAddress}/add", content);

            return response;
        }

        private async Task<HttpResponseMessage> SendGetAllCars()
        {
            using var client = new HttpClient();

            ApiHelper.AddAuthorizationHeader(client);

            var response = await client.GetAsync($"{BaseAddress}");

            return response;
        }
    }
}
