using System.Collections.Generic;
using API.Entities;

namespace API.DTOs
{
    public class ClientDto
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string City { get; set; }
        
        public ICollection<Cars> Cars { get; set; } 
    }
}