using System;
using Android.Graphics;
using Android.OS;
using Android.Views;
using AndroidX.AppCompat.Widget;
using AndroidX.Fragment.App;
using Google.Android.Material.Button;
using WilkoMoto_Android.Models.Responses;
using WilkoMoto_Android.Presenters;

namespace WilkoMoto_Android.Fragments
{
    public class EditFragment : DialogFragment
    {
        private EditPresenter presenter;
        public event EventHandler Edited;
        public CarResponse CarResponse { get; private set; }
        public AppCompatEditText Car { get; private set; }
        public AppCompatEditText Model { get; private set; }
        public AppCompatEditText Mileage { get; private set; }
        public AppCompatEditText FuelType { get; private set; }
        public AppCompatEditText Year { get; private set; }
        public AppCompatEditText Price { get; private set; }
        public MaterialButton AddBtn { get; private set; }

        public EditFragment(CarResponse carResponse)
        {
            this.CarResponse = carResponse;
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            Dialog.Window.SetBackgroundDrawable(new Android.Graphics.Drawables.ColorDrawable(Color.DarkGray));

            var view = inflater.Inflate(Resource.Layout.edit_fragment, container, false);
            ConnectionViews(view);
            presenter = new EditPresenter(this);
            return view;
        }

        public void InvokeEdited()
        {
            Edited?.Invoke(this, EventArgs.Empty);
            Dismiss();
        }

        private void ConnectionViews(View view)
        {
            Car = view.FindViewById<AppCompatEditText>(Resource.Id.car);
            Model = view.FindViewById<AppCompatEditText>(Resource.Id.model);
            Mileage = view.FindViewById<AppCompatEditText>(Resource.Id.mileage);
            FuelType = view.FindViewById<AppCompatEditText>(Resource.Id.fuelType);
            Year = view.FindViewById<AppCompatEditText>(Resource.Id.year);
            Price = view.FindViewById<AppCompatEditText>(Resource.Id.price);
            AddBtn = view.FindViewById<MaterialButton>(Resource.Id.addBtn);

            Car.Text = CarResponse.Car;
            Model.Text = CarResponse.Brand;
            Mileage.Text = CarResponse.Mileage.ToString();
            FuelType.Text = CarResponse.FuelType;
            Year.Text = CarResponse.Year.ToString();
            Price.Text = CarResponse.Price.ToString();
        }
    }
}
