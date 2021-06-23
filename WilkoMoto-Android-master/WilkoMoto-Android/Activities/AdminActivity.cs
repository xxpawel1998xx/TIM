
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
using Google.Android.Material.Button;
using WilkoMoto_Android.Helpers;

namespace WilkoMoto_Android.Activities
{
    [Activity(Label = "Panel administratora")]
    public class AdminActivity : Activity
    {
        private MaterialButton allCarsBtn;
        private MaterialButton addNewCarBtn;
        private MaterialButton takenCarsBtn;
        private MaterialButton logoutBtn;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_admin);

            allCarsBtn = FindViewById<MaterialButton>(Resource.Id.allCarsBtn);
            addNewCarBtn = FindViewById<MaterialButton>(Resource.Id.addNewCarBtn);
            takenCarsBtn = FindViewById<MaterialButton>(Resource.Id.takenCarsBtn);
            logoutBtn = FindViewById<MaterialButton>(Resource.Id.logoutBtn);

            allCarsBtn.Click += (s, e) => StartActivity(typeof(AllCarsActivity));
            addNewCarBtn.Click += (s, e) => StartActivity(typeof(AddCarActivity));
            takenCarsBtn.Click += (s, e) => StartActivity(typeof(TakenCarsActivity));
            logoutBtn.Click += (s, e) =>
            {
                LocalStorage.ClearPreferences();
                FinishAffinity();
                StartActivity(typeof(LoginActivity));
            };
        }
    }
}
