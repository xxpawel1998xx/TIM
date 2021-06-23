using System;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Views;
using AndroidX.AppCompat.Widget;
using AndroidX.AppCompat.App;
using Google.Android.Material.FloatingActionButton;
using Google.Android.Material.Snackbar;
using Google.Android.Material.Button;
using WilkoMoto_Android.Presenters;

namespace WilkoMoto_Android.Activities
{
    [Activity(Label = "WilkoMoto", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class LoginActivity : AppCompatActivity
    {
        private AppCompatEditText usernameInput;
        private AppCompatEditText passwordInput;
        private MaterialButton loginBtn;
        private LoginPresenter loginPresenter;

        public AppCompatEditText UsernameInput { get => usernameInput; set => usernameInput = value; }
        public AppCompatEditText PasswordInput { get => passwordInput; set => passwordInput = value; }
        public MaterialButton LoginBtn { get => loginBtn; set => loginBtn = value; }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
            InitializeViews();
            loginPresenter = new LoginPresenter(this);
        }

        private void InitializeViews()
        {
            UsernameInput = (AppCompatEditText)FindViewById(Resource.Id.usernameInput);
            PasswordInput = (AppCompatEditText)FindViewById(Resource.Id.passwordInput);
            LoginBtn = (MaterialButton)FindViewById(Resource.Id.loginBtn);
        }


        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}
