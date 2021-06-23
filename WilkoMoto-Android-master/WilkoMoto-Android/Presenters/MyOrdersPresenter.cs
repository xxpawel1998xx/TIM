using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Android.Widget;
using Newtonsoft.Json;
using WilkoMoto_Android.Activities;
using WilkoMoto_Android.APIServices.Services;
using WilkoMoto_Android.Helpers;
using WilkoMoto_Android.Models.Responses;

namespace WilkoMoto_Android.Presenters
{
    public class MyOrdersPresenter
    {
        private readonly CarService carService;
        private readonly MyOrdersActivity activity;

        public static async Task<MyOrdersPresenter> CreateAsync(MyOrdersActivity activity)
        {
            var presenter = new MyOrdersPresenter(activity);
            await presenter.GetMyOrdersAsync();
            return presenter;
        }

        private MyOrdersPresenter(MyOrdersActivity activity)
        {
            this.activity = activity;
            carService = new CarService();
        }

        private async Task GetMyOrdersAsync()
        {
            try
            {
                var response = await carService.GetCarsAsync();

                if (response != null)
                {
                    List<CarResponse> MyOrders = GetMineOnly(response);
                    activity.Adapter = new Adapters.MyOrderAdapter(MyOrders);
                    activity.MyOrdersRecyclerView.SetAdapter(activity.Adapter);
                }

            }
            catch (Exception exception)
            {
                Toast.MakeText(activity, exception.Message, ToastLength.Short).Show();
            }
        }

        private static List<CarResponse> GetMineOnly(string response)
        {
            var userId = int.Parse(LocalStorage.GetUser().Id);
            var carsResponse = JsonConvert.DeserializeObject<List<CarResponse>>(response);
            return carsResponse.Where(x => x.AppUserId == userId).ToList();

        }
    }
}
