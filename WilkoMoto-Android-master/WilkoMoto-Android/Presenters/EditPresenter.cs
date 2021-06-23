using System;
using System.Threading.Tasks;
using Android.Widget;
using WilkoMoto_Android.APIServices.Services;
using WilkoMoto_Android.Fragments;
using WilkoMoto_Android.Models.Requests;

namespace WilkoMoto_Android.Presenters
{
    public class EditPresenter
    {
        private readonly CarService carService;
        private readonly EditFragment fragment;
        private readonly EditCarRequest editCarRequest;

        public EditPresenter(EditFragment fragment)
        {
            this.fragment = fragment;
            editCarRequest = new EditCarRequest
            {
                Car = fragment.Car.Text,
                Brand = fragment.Model.Text,
                Mileage = int.Parse(fragment.Mileage.Text),
                Price = int.Parse(fragment.Price.Text),
                Year = int.Parse(fragment.Year.Text),
                FuelType = fragment.FuelType.Text,
                CarPhotoUrl = fragment.CarResponse.CarPhotoUrl
            };
            carService = new CarService();
            Initalize();
        }

        private void Initalize()
        {
            fragment.Car.TextChanged += (s, e) => editCarRequest.Car = fragment.Car.Text;
            fragment.Model.TextChanged += (s, e) => editCarRequest.Brand = fragment.Model.Text;
            fragment.Mileage.TextChanged += (s, e) => editCarRequest.Mileage = int.Parse(fragment.Mileage.Text);
            fragment.Year.TextChanged += (s, e) => editCarRequest.Year = int.Parse(fragment.Year.Text);
            fragment.Price.TextChanged += (s, e) => editCarRequest.Price = int.Parse(fragment.Price.Text);
            fragment.FuelType.TextChanged += (s, e) => editCarRequest.FuelType = fragment.FuelType.Text;
            fragment.AddBtn.Click += async (s, e) => await EditCarAsync();
        }

        private async Task EditCarAsync()
        {
            try
            {
                var response = await carService.EditCar(editCarRequest, fragment.CarResponse.Id);

                if (response != null)
                {
                    Toast.MakeText(fragment.Context, "Zaktualizowano.", ToastLength.Long).Show();
                    fragment.InvokeEdited();
                }

            }
            catch (Exception exception)
            {
                Toast.MakeText(fragment.Context, exception.Message, ToastLength.Short).Show();
            }
        }
    }
}
