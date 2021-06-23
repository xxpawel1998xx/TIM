using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Android.Widget;
using Newtonsoft.Json;
using WilkoMoto_Android.Activities;
using WilkoMoto_Android.Adapters;
using WilkoMoto_Android.APIServices.Services;
using WilkoMoto_Android.Models.Responses;

namespace WilkoMoto_Android.Presenters
{
    public class AllCarsPresenter
    {
        private readonly CarService carService;
        private readonly AllCarsActivity activity;

        public static async Task<AllCarsPresenter> CreateAsync(AllCarsActivity activity)
        {
            var presenter = new AllCarsPresenter(activity);
            await presenter.GetCarsAsync();
            return presenter;
        }

        public AllCarsPresenter(AllCarsActivity activity)
        {
            this.activity = activity;
            carService = new CarService();
        }

        private async Task GetCarsAsync()
        {
            try
            {
                var response = await carService.GetCarsAsync();

                if (response != null)
                {
                    var carsResponse = JsonConvert.DeserializeObject<List<CarResponse>>(response);
                    activity.Adapter = new AdminCarAdapter(carsResponse, activity);
                    activity.AllCarsRecyclerView.SetAdapter(activity.Adapter);
                }

            }
            catch (Exception exception)
            {
                Toast.MakeText(activity, exception.Message, ToastLength.Short).Show();
            }
        }
    }
}
