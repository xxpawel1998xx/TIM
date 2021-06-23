using System;
using Newtonsoft.Json;

namespace WilkoMoto_Android.Models.Requests
{
    public class EditCarRequest
    {
        [JsonProperty("car")]
        public string Car { get; set; }

        [JsonProperty("brand")]
        public string Brand { get; set; }

        [JsonProperty("fuelType")]
        public string FuelType { get; set; }

        [JsonProperty("year")]
        public int Year { get; set; }

        [JsonProperty("price")]
        public int Price { get; set; }

        [JsonProperty("carPhotoUrl")]
        public string CarPhotoUrl { get; set; }

        [JsonProperty("mileage")]
        public int Mileage { get; set; }
    }
}
