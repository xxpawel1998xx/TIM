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
    public class TakenCarsPresenter
    {
        private readonly AdminService adminService;
        private readonly TakenCarsActivity activity;

        public static async Task<TakenCarsPresenter> CreateAsync(TakenCarsActivity activity)
        {
            var presenter = new TakenCarsPresenter(activity);
            await presenter.GetTakenCarsAsync();
            return presenter;
        }

        public TakenCarsPresenter(TakenCarsActivity activity)
        {
            this.adminService = new AdminService();
            this.activity = activity;
        }

        private async Task GetTakenCarsAsync()
        {
            try
            {
                var response = await adminService.GetUsersWithCars();

                if (response != null)
                {
                    List<UserWithCarsResponse> takenCars = GetTakenOnly(response);
                    activity.Adapter = new TakenCarAdapter(takenCars);
                    activity.TakenCarsRecyclerView.SetAdapter(activity.Adapter);
                }

            }
            catch (Exception exception)
            {
                Toast.MakeText(activity, exception.Message, ToastLength.Short).Show();
            }
        }

        private static List<UserWithCarsResponse> GetTakenOnly(string response)
        {
            var loginResponse = JsonConvert.DeserializeObject<List<UserWithCarsResponse>>(response);
            var takenCars = loginResponse.Where(x => x.Cars.Count > 0).ToList();
            takenCars.Remove(takenCars.FirstOrDefault(x => x.Id == "4"));
            return takenCars;
        }
    }
}
