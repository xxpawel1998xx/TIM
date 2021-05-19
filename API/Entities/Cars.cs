using System;

namespace API.Entities
{
    public class Cars
    {
        public int Id { get; set; }
        public string Car { get; set; }
        public string Brand { get; set; }
        public string FuelType { get; set; }
        public long Price { get; set; }
        public long Year { get; set; } 
        public long Mileage { get; set; }

        public string CarPhotoUrl { get; set; }
        public string PublicId { get; set; }
        public AppUser AppUser { get; set; }
        public int AppUserId { get; set; }
        public bool isTaken { get; set; }
    }
}