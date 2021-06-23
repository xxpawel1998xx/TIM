using System;
using System.Threading.Tasks;
using Android.Widget;
using Newtonsoft.Json;
using WilkoMoto_Android.Activities;
using WilkoMoto_Android.APIServices.Services;
using WilkoMoto_Android.Helpers;
using WilkoMoto_Android.Models.Requests;
using WilkoMoto_Android.Models.Responses;

namespace WilkoMoto_Android.Presenters
{
    public class LoginPresenter
    {
        private readonly LoginActivity activity;
        private readonly AccountService accountService;

        public LoginPresenter(LoginActivity activity)
        {
            this.activity = activity;
            accountService = new AccountService();
            Initalize();
        }

        public string Username { get; set; }
        public string Password { get; set; }


        private void Initalize()
        {
            activity.UsernameInput.TextChanged += (s, e) =>
            {
                Username = activity.UsernameInput.Text;
            };

            activity.PasswordInput.TextChanged += (s, e) =>
            {
                Password = activity.PasswordInput.Text;
            };

            activity.LoginBtn.Click += async (s, e) =>
            {
                await LoginUserAsync();
            };
        }

        private async Task LoginUserAsync()
        {
            try
            {
                var request = new LoginRequest
                {
                    Username = Username,
                    Password = "Pa$$w0rd"
                };

                var response = await accountService.LoginAsync(request);

                if (response != null)
                {
                    var loginResponse = JsonConvert.DeserializeObject<LoginResponse>(response);
                    LocalStorage.SaveUser(loginResponse);
                    LocalStorage.SaveToken(loginResponse.Token);

                    if (loginResponse.Username == "admin")
                    {
                        Toast.MakeText(activity, "Witaj administratorze.", ToastLength.Short).Show();
                        activity.StartActivity(typeof(AdminActivity));
                        activity.FinishAffinity();
                    }
                    else
                    {
                        Toast.MakeText(activity, $"Witaj {loginResponse.Username}.", ToastLength.Short).Show();
                        activity.StartActivity(typeof(UserActivity));
                        activity.FinishAffinity();
                    }
                }

            }
            catch (Exception exception)
            {
                Toast.MakeText(activity, exception.Message, ToastLength.Short).Show();
            }
        }
    }
}
