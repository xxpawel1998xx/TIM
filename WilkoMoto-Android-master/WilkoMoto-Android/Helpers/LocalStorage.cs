using System;
using Android.App;
using Android.Content;
using Newtonsoft.Json;
using WilkoMoto_Android.Models.Responses;

namespace WilkoMoto_Android.Helpers
{
    public class LocalStorage
    {
        private static readonly ISharedPreferences _preferences = Application
           .Context
           .GetSharedPreferences("userinfo", FileCreationMode.Private);

        private static ISharedPreferencesEditor _editor;

        public static void SaveToken(string token)
        {
            _editor = _preferences.Edit();
            _editor.PutString("token", token);
            _editor.Apply();
        }

        public static void SaveUser(LoginResponse user)
        {
            _editor = _preferences.Edit();
            var serialized = JsonConvert.SerializeObject(user);

            _editor.PutString("user", serialized);
            _editor.Apply();
        }

        public static string GetToken()
        {
            var token = _preferences.GetString("token", "");

            return token;
        }

        public static LoginResponse GetUser()
        {
            var user = JsonConvert
                .DeserializeObject<LoginResponse>(_preferences.GetString("user", ""));

            return user;
        }

        public static void ClearPreferences()
        {
            _editor = _preferences.Edit();
            _editor.Clear();
            _editor.Apply();
        }
    }
}
