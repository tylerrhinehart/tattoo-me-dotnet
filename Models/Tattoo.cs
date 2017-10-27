using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace tattoo_me_dotnet.Models
{
    public class Tattoo
    {
        public string Id { get; set; }
        public string ArtistName { get; set; }
        public DateTime Created { get; set; }
        public string Url { get; set; }
        public string HdUrl { get; set; }
        public List<TagName> Tags { get; set; }
        public float Price { get; set; }
        [Required]
        public string UserId { get; set; }
    }
}