
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
    [Activity(Label = "Wszystkie pojazdy")]
    public class AllCarsActivity : AppCompatActivity
    {
        private AllCarsPresenter presenter;
        public RecyclerView AllCarsRecyclerView { get; private set; }
        public AdminCarAdapter Adapter { get; set; }

        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_free_cars);
            InitalizeViews();
            presenter = await AllCarsPresenter.CreateAsync(this);
        }

        private void InitalizeViews()
        {
            AllCarsRecyclerView = FindViewById<RecyclerView>(Resource.Id.freeCarsRV);
            AllCarsRecyclerView.SetLayoutManager(new LinearLayoutManager(AllCarsRecyclerView.Context));
        }
    }
}
