﻿using System;
using Newtonsoft.Json;

namespace WilkoMoto_Android.Models.Requests
{
    public class LoginRequest
    {
        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }
    }
}
