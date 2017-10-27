using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace tattoo_me_dotnet.Models
{
    public class User : IdentityUser
    {
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public string AccountType { get; set; }
        public List<Tattoo> Favorites { get; set; }
        // public List<Tattoo> Purchased { get; set; }
        public string ProfileImgUrl { get; set; }

    }
}