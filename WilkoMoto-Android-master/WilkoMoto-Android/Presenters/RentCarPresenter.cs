using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Android.App;
using Android.Widget;
using Newtonsoft.Json;
using WilkoMoto_Android.APIServices.Services;
using WilkoMoto_Android.Helpers;
using WilkoMoto_Android.Models.Responses;

namespace WilkoMoto_Android.Presenters
{
    public class RentCarPresenter
    {
        private readonly ClientService clientService;
        private readonly CarService carService;

        public RentCarPresenter()
        {
            clientService = new ClientService();
        }

        public async Task<List<CarResponse>> UnpickCar(int carId)
        {
            try
            {
                var userId = int.Parse(LocalStorage.GetUser().Id);

                var response = await clientService.UnpickAsync(userId, carId);

                if (response != null)
                {
                    var cars = await GetCarsAsync();
                    Toast.MakeText(Application.Context, "Anulowano.", ToastLength.Short).Show();
                    return cars ?? new List<CarResponse>();
                }

                return new List<CarResponse>();

            }
            catch (Exception exception)
            {
                Toast.MakeText(Application.Context, exception.Message, ToastLength.Short).Show();
                return new List<CarResponse>();
            }
        }

        public async Task<List<CarResponse>> PickCar(int carId)
        {
            try
            {
                var userId = int.Parse(LocalStorage.GetUser().Id);

                var response = await clientService.PickAsync(userId, carId);

                if (response != null)
                {
                    var cars = await GetCarsAsync();
                    Toast.MakeText(Application.Context, "Wybrano.", ToastLength.Short).Show();
                    return cars ?? new List<CarResponse>();
                }

                return new List<CarResponse>();

            }
            catch (Exception exception)
            {
                Toast.MakeText(Application.Context, exception.Message, ToastLength.Short).Show();
                return new List<CarResponse>();
            }
        }

        public async Task<List<CarResponse>> GetCarsAsync()
        {
            try
            {
                var response = await carService.GetCarsAsync();

                if (response != null)
                {
                    var carsResponse = GetFreeOnly(response);
                    return carsResponse;
                }

                return null;

            }
            catch
            {
                return null;
            }
        }

        private static List<CarResponse> GetFreeOnly(string response)
        {
            var carsResponse = JsonConvert.DeserializeObject<List<CarResponse>>(response);
            return carsResponse.Where(x => x.IsTaken == false).ToList();

        }
    }
}
