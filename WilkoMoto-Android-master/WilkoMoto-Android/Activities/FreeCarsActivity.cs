
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
    [Activity(Label = "Dostępne pojazdy")]
    public class FreeCarsActivity : AppCompatActivity
    {
        private FreeCarsPresenter presenter;
        public RecyclerView FreeCarsRecyclerView { get; private set; }
        public RentCarAdapter Adapter { get; set; }

        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_free_cars);
            InitalizeViews();
            presenter = await FreeCarsPresenter.CreateAsync(this);

        }

        private void InitalizeViews()
        {
            FreeCarsRecyclerView = FindViewById<RecyclerView>(Resource.Id.freeCarsRV);
            FreeCarsRecyclerView.SetLayoutManager(new LinearLayoutManager(FreeCarsRecyclerView.Context));

            //adapter = new RentCarAdapter(presenter.Requests);
            //userRV.SetAdapter(adapter);
        }
    }
}
