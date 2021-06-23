
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
using AndroidX.RecyclerView.Widget;
using WilkoMoto_Android.Adapters;
using WilkoMoto_Android.Presenters;

namespace WilkoMoto_Android.Activities
{
    [Activity(Label = "Zajęte pojazdy")]
    public class TakenCarsActivity : AppCompatActivity
    {

        private TakenCarsPresenter presenter;
        public RecyclerView TakenCarsRecyclerView { get; private set; }
        public TakenCarAdapter Adapter { get; set; }

        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_free_cars);
            InitalizeViews();
            presenter = await TakenCarsPresenter.CreateAsync(this);
            // Create your application here
        }

        private void InitalizeViews()
        {
            TakenCarsRecyclerView = FindViewById<RecyclerView>(Resource.Id.freeCarsRV);
            TakenCarsRecyclerView.SetLayoutManager(new LinearLayoutManager(TakenCarsRecyclerView.Context));

            //adapter = new RentCarAdapter(presenter.Requests);
            //userRV.SetAdapter(adapter);
        }
    }
}
