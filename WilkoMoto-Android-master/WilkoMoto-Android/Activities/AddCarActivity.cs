
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using AndroidX.AppCompat.Widget;
using Google.Android.Material.Button;
using WilkoMoto_Android.Presenters;

namespace WilkoMoto_Android.Activities
{
    [Activity(Label = "Dodaj nowy pojazd")]
    public class AddCarActivity : AppCompatActivity
    {
        public AppCompatEditText Car;
        public AppCompatEditText Model;
        public AppCompatEditText Mileage;
        public AppCompatEditText FuelType;
        public AppCompatEditText Year;
        public AppCompatEditText Price;
        public ImageView Attached;
        public MaterialButton AddBtn;
        private AddCarPresenter presenter;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_add_car);
            InitalizeViews();
            presenter = new AddCarPresenter(this);
        }

        private void InitalizeViews()
        {
            Car = FindViewById<AppCompatEditText>(Resource.Id.car);
            Model = FindViewById<AppCompatEditText>(Resource.Id.model);
            Mileage = FindViewById<AppCompatEditText>(Resource.Id.mileage);
            FuelType = FindViewById<AppCompatEditText>(Resource.Id.fuelType);
            Year = FindViewById<AppCompatEditText>(Resource.Id.year);
            Price = FindViewById<AppCompatEditText>(Resource.Id.price);
            Attached = FindViewById<ImageView>(Resource.Id.attached);
            AddBtn = FindViewById<MaterialButton>(Resource.Id.addBtn);
        }
    }
}
