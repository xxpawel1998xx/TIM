using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Android.Widget;
using Newtonsoft.Json;
using WilkoMoto_Android.Activities;
using WilkoMoto_Android.Adapters;
using WilkoMoto_Android.APIServices.Services;
using WilkoMoto_Android.Models.Responses;

namespace WilkoMoto_Android.Presenters
{
    public class FreeCarsPresenter
    {
        private readonly CarService carService;
        private readonly FreeCarsActivity activity;

        public static async Task<FreeCarsPresenter> CreateAsync(FreeCarsActivity activity)
        {
            var presenter = new FreeCarsPresenter(activity);
            await presenter.GetFreeCarsAsync();
            return presenter;
        }

        private FreeCarsPresenter(FreeCarsActivity activity)
        {
            this.activity = activity;
            carService = new CarService();
        }

        private async Task GetFreeCarsAsync()
        {
            try
            {
                var response = await carService.GetCarsAsync();

                if (response != null)
                {
                    List<CarResponse> freeCars = GetFreeOnly(response);
                    activity.Adapter = new RentCarAdapter(freeCars);
                    activity.FreeCarsRecyclerView.SetAdapter(activity.Adapter);
                }

            }
            catch (Exception exception)
            {
                Toast.MakeText(activity, exception.Message, ToastLength.Short).Show();
            }
        }

        private static List<CarResponse> GetFreeOnly(string response)
        {
            var carsResponse = JsonConvert.DeserializeObject<List<CarResponse>>(response);
            return carsResponse.Where(x => x.IsTaken == false).ToList();
            
        }
    }
}
