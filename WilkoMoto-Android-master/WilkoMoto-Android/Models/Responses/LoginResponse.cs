using System;
using Newtonsoft.Json;

namespace WilkoMoto_Android.Models.Responses
{
    public class LoginResponse
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("token")]
        public string Token { get; set; }
    }
}
