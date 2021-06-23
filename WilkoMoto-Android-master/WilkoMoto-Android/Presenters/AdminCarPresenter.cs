using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Android.App;
using Android.Widget;
using Newtonsoft.Json;
using WilkoMoto_Android.APIServices.Services;
using WilkoMoto_Android.Models.Responses;

namespace WilkoMoto_Android.Presenters
{
    public class AdminCarPresenter
    {
        private readonly CarService carService;

        public AdminCarPresenter()
        {
            carService = new CarService();
        }

        public async Task<List<CarResponse>> RemoveAndGetAllAsync(int id)
        {
            try
            {
                var response = await carService.DeleteCar(id);

                if (response != null)
                {
                    var cars = await GetCarsAsync();
                    Toast.MakeText(Application.Context, "Usunięto.", ToastLength.Short).Show();
                    return cars;
                }

                return null;

            }
            catch (Exception exception)
            {
                Toast.MakeText(Application.Context, exception.Message, ToastLength.Short).Show();
                return null;
            }
        }

        public async Task<List<CarResponse>> GetCarsAsync()
        {
            try
            {
                var response = await carService.GetCarsAsync();

                if (response != null)
                {
                    var carsResponse = JsonConvert.DeserializeObject<List<CarResponse>>(response);
                    return carsResponse;
                }

                return null;

            }
            catch
            {
                return null;
            }
        }


    }
}
