using System;
using System.Collections.Generic;
using Android.App;
using Android.Views;
using Android.Widget;
using AndroidX.RecyclerView.Widget;
using WilkoMoto_Android.Activities;
using WilkoMoto_Android.Fragments;
using WilkoMoto_Android.Helpers;
using WilkoMoto_Android.Models.Responses;
using WilkoMoto_Android.Presenters;

namespace WilkoMoto_Android.Adapters
{
    public class AdminCarAdapter : RecyclerView.Adapter
    {
        public event EventHandler<AdminCarAdapterEventArgs> ReactButtonClicked;
        public event EventHandler<AdminCarAdapterEventArgs> ItemLongClicked;
        private List<CarResponse> cars;
        private readonly AdminCarPresenter presenter;
        private readonly AllCarsActivity activity;

        public AdminCarAdapter(List<CarResponse> cars, AllCarsActivity activity)
        {
            this.cars = cars;
            this.activity = activity;
            presenter = new AdminCarPresenter();
        }

        public override int ItemCount => cars.Count;

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            var viewHolder = holder as AdminCarAdapterViewHolder;

            var item = cars[position];

            viewHolder.CarName.Text = $"{item.Car} {item.Brand}";
            viewHolder.FuelType.Text = $"Rodzaj paliwa: {item.FuelType}";
            viewHolder.Year.Text = $"Rok produkcji: {item.Year}";
            viewHolder.Mileage.Text = $"Przebieg: {item.Mileage} km";
            viewHolder.Price.Text = $"Cena: {item.Price} zł";


            ImageHelper.GetImageFromUrl(item.CarPhotoUrl, viewHolder.Image);

            viewHolder.Delete.Click += (s, e) =>
            {
                ViewHelper.ShowDialog(activity, async () =>
                {
                    cars = await presenter.RemoveAndGetAllAsync(item.Id);
                    NotifyDataSetChanged();
                },
                () => { },
                "Czy chcesz usunąć ten pojazd?",
                "Tak", "Nie");
            };

            viewHolder.Edit.Click += (s, e) =>
            {
                var fragment = new EditFragment(item);
                var trans = activity.SupportFragmentManager.BeginTransaction();
                fragment.Cancelable = true;
                fragment.Show(trans, "editCar");
                fragment.Edited += async (s, e) =>
                {
                    cars = await presenter.GetCarsAsync();
                    NotifyDataSetChanged();
                };
            };

        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            var itemView = LayoutInflater.From(parent.Context).
                Inflate(Resource.Layout.item_admin_car, parent, false);

            return new AdminCarAdapterViewHolder(itemView, OnLongClick);
        }

        void OnLongClick(AdminCarAdapterEventArgs args)
        {
            ItemLongClicked?.Invoke(this, args);
        }

        public class AdminCarAdapterViewHolder : RecyclerView.ViewHolder
        {
            public TextView CarName { get; set; }
            public TextView FuelType { get; set; }
            public TextView Year { get; set; }
            public TextView Mileage { get; set; }
            public TextView Price { get; set; }
            public ImageView Image { get; set; }
            public Button Edit { get; set; }
            public Button Delete { get; set; }

            public AdminCarAdapterViewHolder(View itemView, Action<AdminCarAdapterEventArgs> clickListener) : base(itemView)
            {
                CarName = itemView.FindViewById<TextView>(Resource.Id.carName);
                FuelType = itemView.FindViewById<TextView>(Resource.Id.fuelType);
                Year = itemView.FindViewById<TextView>(Resource.Id.year);
                Mileage = itemView.FindViewById<TextView>(Resource.Id.mileage);
                Price = itemView.FindViewById<TextView>(Resource.Id.price);
                Image = itemView.FindViewById<ImageView>(Resource.Id.image);
                Edit = itemView.FindViewById<Button>(Resource.Id.edit);
                Delete = itemView.FindViewById<Button>(Resource.Id.delete);

                itemView.Click += (s, e) => clickListener(new AdminCarAdapterEventArgs { Position = AdapterPosition });
            }
        }

        public class AdminCarAdapterEventArgs : EventArgs
        {
            public int Position { get; set; }
        }
    }
}
