using System;
namespace WilkoMoto_Android.Models.Requests
{
    public class AddCarRequest
    {
        public string Car { get; set; }
        public string Brand { get; set; }
        public string FuelType { get; set; }
        public int Year { get; set; }
        public int Price { get; set; }
        public string CarPhotoUrl { get; set; }
        public int Mileage { get; set; }
        public byte[] File { get; set; }
    }
}
