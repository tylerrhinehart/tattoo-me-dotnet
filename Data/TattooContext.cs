using tattoo_me_dotnet.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace tattoo_me_dotnet
{
    public class TattooContext : IdentityDbContext<User>
    {
        // DONT FORGET TO REGISTER YOUR MODELS TO THE DATABASE
        new DbSet<User> Users { get; set; }
        public DbSet<Tattoo> Tattoos { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<TagName> TagNames { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=./Tattoome.db");
        }
        public TattooContext(DbContextOptions<TattooContext> options) : base(options)
        {
            // Database.EnsureCreated();
            // Database.Migrate();
        }
    }
}
