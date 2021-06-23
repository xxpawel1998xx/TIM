using System;
using System.Threading.Tasks;
using Android.Graphics;
using Android.Widget;
using WilkoMoto_Android.Activities;
using WilkoMoto_Android.APIServices.Services;
using WilkoMoto_Android.Helpers;
using WilkoMoto_Android.Models.Requests;

namespace WilkoMoto_Android.Presenters
{
    public class AddCarPresenter
    {
        private readonly CarService carService;
        private readonly AddCarActivity activity;

        public AddCarPresenter(AddCarActivity activity)
        {
            this.activity = activity;
            carService = new CarService();
            Initialize();
        }

        private byte[] file;
        private string car;
        private string brand;
        private string fuelType;
        private string year;
        private string mileage;
        private string price;

        private void Initialize()
        {
            activity.Attached.Click += async (s, e) =>
            {
                try
                {
                    file = await ImageHelper.SelectPhotoAsync();
                    Bitmap bmp = await BitmapFactory.DecodeByteArrayAsync(file, 0, file.Length);
                    activity.Attached.SetImageBitmap(Bitmap.CreateScaledBitmap(bmp,
                        activity.Attached.Width,
                        activity.Attached.Height, false));
                }
                catch(Exception exc)
                {
                    Toast.MakeText(activity, exc.Message, ToastLength.Long).Show();
                }
                
            };

            activity.Car.TextChanged += (s, e) => car = activity.Car.Text;
            activity.Model.TextChanged += (s, e) => brand = activity.Model.Text;
            activity.FuelType.TextChanged += (s, e) => fuelType = activity.FuelType.Text;
            activity.Year.TextChanged += (s, e) => year = activity.Year.Text;
            activity.Mileage.TextChanged += (s, e) => mileage = activity.Mileage.Text;
            activity.Price.TextChanged += (s, e) => price = activity.Price.Text;
            activity.AddBtn.Click += async (s, e) => await AddAsync();
        }

        private async Task AddAsync()
        {
            try
            {
                if (file == null) throw new Exception("Dodaj zdjecie");

                var request = new AddCarRequest
                {
                    File = file,
                    Brand = brand,
                    Year = int.Parse(year),
                    Car = car,
                    FuelType = fuelType,
                    Price = int.Parse(price),
                    Mileage = int.Parse(mileage),
                    CarPhotoUrl = string.Empty
                };

                var response = await carService.AddCar(request);

                if (response != null)
                {
                    Toast.MakeText(activity, "Dodano.", ToastLength.Short).Show();
                }

            }
            catch (Exception exception)
            {
                Toast.MakeText(activity, exception.Message, ToastLength.Short).Show();
            }
        }
    }
}
