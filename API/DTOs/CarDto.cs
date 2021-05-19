using System.ComponentModel.DataAnnotations;
using API.Entities;

namespace API.DTOs
{
    public class CarDto
    {
        public int Id { get; set; }
       
        public string Car { get; set; }
      
        public string Brand { get; set; }
    
        public string FuelType { get; set; }
        
        public long Year { get; set; } 
       
        public long Price { get; set; }
        
        public string CarPhotoUrl { get; set; }

        public long Mileage { get; set; }
        public bool isTaken { get; set; }

         public int AppUserId { get; set; }
    }
}