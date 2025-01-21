using Gut_Cleanse.Data.Tables;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Reflection;
using System.Security.Authentication.ExtendedProtection;
using System.Xml;
using System.Xml.Linq;

namespace Gut_Cleanse.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        //public ApplicationDbContext()
        //{

        //}
        public DbSet<User> Users { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<PaymentType> PaymentTypes { get; set; }
        public DbSet<Payment> Payments { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Country>().HasData(
                   new() { Id = 1, Name = "India" },
                   new() { Id = 2, Name = "Australia" },
                    new() { Id = 3, Name = "USA" }
            );
            //Seeding State Master Data using HasData method
            builder.Entity<State>().HasData(
                new() { Id = 1, Name = "Punjab", CountryId = 1 },
                 new() { Id = 2, Name = "Himachal", CountryId = 1 }
            );
            //Seeding City Master Data using HasData method
            builder.Entity<City>().HasData(
                new() { Id = 1, Name = "Mohali", StateId = 1 },
                new() { Id = 2, Name = "Jalandhar", StateId = 1 },
                 new() { Id = 3, Name = "Ludhiana", StateId = 1 },
                  new() { Id = 4, Name = "Shimla", StateId = 2 },
                new() { Id = 5, Name = "Dharamshala", StateId = 2 },
                 new() { Id = 6, Name = "Mandi", StateId = 2 }
             );
            builder.Entity<IdentityRole>().HasData(
                 new IdentityRole() { Id = "F2362EB6-4C91-4E31-B822-A62032A68678", Name = "Admin", NormalizedName = "ADMIN" }
            );
            builder.Entity<PaymentType>().HasData(
                 new PaymentType() { Id = 1, Name = "Gut Reset Revolution", Amount = 45000, Description = "Gut Reset Revolution" },
                 new PaymentType() { Id = 2, Name = "Gut & Glory", Amount = 6300, Description = "Gut & Glory" },
                 new PaymentType() { Id = 3, Name = "Gut Intelligence Workshop", Amount = 299, Description = "Gut Intelligence Workshop" },
                 new PaymentType() { Id = 4, Name = "21 Day Challenge", Amount = 5000, Description = "21 Day Challenge" }
            );

        }
    }
}
