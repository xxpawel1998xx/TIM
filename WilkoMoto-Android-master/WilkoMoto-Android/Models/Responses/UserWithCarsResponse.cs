using System.Collections.Generic;
using Newtonsoft.Json;

namespace WilkoMoto_Android.Models.Responses
{
    public class UserWithCarsResponse
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("cars")]
        public List<CarResponse> Cars { get; set; }
    }
}
