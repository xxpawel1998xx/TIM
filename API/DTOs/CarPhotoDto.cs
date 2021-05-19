using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace API.DTOs
{
    public class CarPhotoDto
    {
        
        public string Car { get; set; }
       
        public string Brand { get; set; }
        
        public string FuelType { get; set; }
       
        public long Year { get; set; } 
       
        public long Price { get; set; }
        
        public string CarPhotoUrl { get; set; }

        public long Mileage { get; set; }

        public IFormFile File { get; set;}

    }
}