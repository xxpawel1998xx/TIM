using System;
using Newtonsoft.Json;

namespace WilkoMoto_Android.Models.Responses
{
    public class CarResponse
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("car")]
        public string Car { get; set; }

        [JsonProperty("brand")]
        public string Brand { get; set; }

        [JsonProperty("fuelType")]
        public string FuelType { get; set; }

        [JsonProperty("price")]
        public int Price { get; set; }

        [JsonProperty("year")]
        public int Year { get; set; }

        [JsonProperty("mileage")]
        public int Mileage { get; set; }

        [JsonProperty("carPhotoUrl")]
        public string CarPhotoUrl { get; set; }

        [JsonProperty("publicId")]
        public string PublicId { get; set; }

        [JsonProperty("appUser")]
        public object AppUser { get; set; }

        [JsonProperty("appUserId")]
        public int AppUserId { get; set; }

        [JsonProperty("isTaken")]
        public bool IsTaken { get; set; }
    }
}
