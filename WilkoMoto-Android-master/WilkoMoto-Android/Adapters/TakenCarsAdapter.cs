using System;
using System.Collections.Generic;
using Android.Views;
using Android.Widget;
using AndroidX.RecyclerView.Widget;
using WilkoMoto_Android.Helpers;
using WilkoMoto_Android.Models.Responses;

namespace WilkoMoto_Android.Adapters
{
    public class TakenCarAdapter : RecyclerView.Adapter
    {
        public event EventHandler<TakenCarAdapterEventArgs> ReactButtonClicked;
        public event EventHandler<TakenCarAdapterEventArgs> ItemLongClicked;
        private readonly List<UserWithCarsResponse> cars;
        //private readonly TakenCarPresenter presenter;

        public TakenCarAdapter(List<UserWithCarsResponse> cars)
        {
            this.cars = cars;
            //presenter = new TakenCarPresenter();
        }

        public override int ItemCount => cars.Count;

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            var viewHolder = holder as TakenCarAdapterViewHolder;

            var itemCar = cars[position].Cars[0];
            var item = cars[position];

            viewHolder.CarName.Text = $"{itemCar.Car} {itemCar.Brand}";
            viewHolder.FuelType.Text = $"Rodzaj paliwa: {itemCar.FuelType}";
            viewHolder.Year.Text = $"Rok produkcji: {itemCar.Year}";
            viewHolder.Mileage.Text = $"Przebieg: {itemCar.Mileage} km";
            viewHolder.Price.Text = $"Cena: {itemCar.Price} zł";
            viewHolder.Buyer.Text = $"Wypożyczone przez: {item.Username}";
            viewHolder.From.Text = $"Z miasta: {item.City}";
            ImageHelper.GetImageFromUrl(itemCar.CarPhotoUrl, viewHolder.Image);

        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            var itemView = LayoutInflater.From(parent.Context).
                Inflate(Resource.Layout.item_taken_car, parent, false);

            return new TakenCarAdapterViewHolder(itemView, OnLongClick);
        }

        void OnLongClick(TakenCarAdapterEventArgs args)
        {
            ItemLongClicked?.Invoke(this, args);
        }

        public class TakenCarAdapterViewHolder : RecyclerView.ViewHolder
        {
            public TextView CarName { get; set; }
            public TextView FuelType { get; set; }
            public TextView Year { get; set; }
            public TextView Mileage { get; set; }
            public TextView Price { get; set; }
            public TextView Buyer { get; set; }
            public TextView From { get; set; }
            public ImageView Image { get; set; }

            public TakenCarAdapterViewHolder(View itemView, Action<TakenCarAdapterEventArgs> clickListener) : base(itemView)
            {
                CarName = itemView.FindViewById<TextView>(Resource.Id.carName);
                FuelType = itemView.FindViewById<TextView>(Resource.Id.fuelType);
                Year = itemView.FindViewById<TextView>(Resource.Id.year);
                Mileage = itemView.FindViewById<TextView>(Resource.Id.mileage);
                Price = itemView.FindViewById<TextView>(Resource.Id.price);
                Image = itemView.FindViewById<ImageView>(Resource.Id.image);
                Buyer = itemView.FindViewById<TextView>(Resource.Id.buyer);
                From = itemView.FindViewById<TextView>(Resource.Id.from);

                itemView.Click += (s, e) => clickListener(new TakenCarAdapterEventArgs { Position = AdapterPosition });
            }
        }

        public class TakenCarAdapterEventArgs : EventArgs
        {
            public int Position { get; set; }
        }
    }
}