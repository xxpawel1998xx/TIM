using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace API.Entities
{
    public class AppUser : IdentityUser<int>
    {
        public string City { get; set; }
        public ICollection<AppUserRole> UserRoles { get; set; }
        
        public ICollection<Cars> Cars { get; set; } 
    }
}