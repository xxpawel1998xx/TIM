using System;
using System.Collections.Generic;
using Android.Views;
using Android.Widget;
using AndroidX.RecyclerView.Widget;
using WilkoMoto_Android.Helpers;
using WilkoMoto_Android.Models.Responses;
using WilkoMoto_Android.Presenters;

namespace WilkoMoto_Android.Adapters
{
    public class MyOrderAdapter : RecyclerView.Adapter
    {
        public event EventHandler<MyOrderAdapterEventArgs> ReactButtonClicked;
        public event EventHandler<MyOrderAdapterEventArgs> ItemLongClicked;
        private List<CarResponse> cars;
        private readonly RentCarPresenter presenter;
        //private readonly MyOrderPresenter presenter;

        public MyOrderAdapter(List<CarResponse> cars)
        {
            this.cars = cars;
            presenter = new RentCarPresenter();
        }

        public override int ItemCount => cars.Count;

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            var viewHolder = holder as MyOrderAdapterViewHolder;

            var item = cars[position];

            viewHolder.CarName.Text = $"{item.Car} {item.Brand}";
            viewHolder.FuelType.Text = $"Rodzaj paliwa: {item.FuelType}";
            viewHolder.Year.Text = $"Rok produkcji: {item.Year}";
            viewHolder.Mileage.Text = $"Przebieg: {item.Mileage} km";
            viewHolder.Price.Text = $"Cena: {item.Price} zł";


            ImageHelper.GetImageFromUrl(item.CarPhotoUrl, viewHolder.Image);

            viewHolder.Order.Click += async (s, e) =>
            {
                cars = await presenter.UnpickCar(item.Id);
                NotifyDataSetChanged();
            };

        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            var itemView = LayoutInflater.From(parent.Context).
                Inflate(Resource.Layout.item_car, parent, false);

            return new MyOrderAdapterViewHolder(itemView, OnLongClick);
        }

        void OnLongClick(MyOrderAdapterEventArgs args)
        {
            ItemLongClicked?.Invoke(this, args);
        }

        public class MyOrderAdapterViewHolder : RecyclerView.ViewHolder
        {
            public TextView CarName { get; set; }
            public TextView FuelType { get; set; }
            public TextView Year { get; set; }
            public TextView Mileage { get; set; }
            public TextView Price { get; set; }
            public ImageView Image { get; set; }
            public Button Order { get; set; }

            public MyOrderAdapterViewHolder(View itemView, Action<MyOrderAdapterEventArgs> clickListener) : base(itemView)
            {
                CarName = itemView.FindViewById<TextView>(Resource.Id.carName);
                FuelType = itemView.FindViewById<TextView>(Resource.Id.fuelType);
                Year = itemView.FindViewById<TextView>(Resource.Id.year);
                Mileage = itemView.FindViewById<TextView>(Resource.Id.mileage);
                Price = itemView.FindViewById<TextView>(Resource.Id.price);
                Image = itemView.FindViewById<ImageView>(Resource.Id.image);
                Order = itemView.FindViewById<Button>(Resource.Id.order);

                Order.Text = "Anuluj rezerwację";

                itemView.Click += (s, e) => clickListener(new MyOrderAdapterEventArgs { Position = AdapterPosition });
            }
        }

        public class MyOrderAdapterEventArgs : EventArgs
        {
            public int Position { get; set; }
        }
    }
}
