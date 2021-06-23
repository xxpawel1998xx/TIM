
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
    [Activity(Label = "Moje zamówienia")]
    public class MyOrdersActivity : AppCompatActivity
    {
        private MyOrdersPresenter presenter;
        public RecyclerView MyOrdersRecyclerView { get; private set; }
        public MyOrderAdapter Adapter { get; set; }

        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_free_cars);
            InitalizeViews();
            presenter = await MyOrdersPresenter.CreateAsync(this);
            // Create your application here
        }

        private void InitalizeViews()
        {
            MyOrdersRecyclerView = FindViewById<RecyclerView>(Resource.Id.freeCarsRV);
            MyOrdersRecyclerView.SetLayoutManager(new LinearLayoutManager(MyOrdersRecyclerView.Context));

            //adapter = new RentCarAdapter(presenter.Requests);
            //userRV.SetAdapter(adapter);
        }
    }
}
