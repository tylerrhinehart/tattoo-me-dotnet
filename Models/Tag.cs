using System.Collections.Generic;
using System.ComponentModel;

namespace tattoo_me_dotnet.Models
{
    public class Tag
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<Tattoo> Tattoos { get; set; }
    }
}