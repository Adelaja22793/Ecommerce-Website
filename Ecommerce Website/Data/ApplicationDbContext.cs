using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce_Website.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Colour> Colours { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductColour> ProductColours { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<MainCategory> MainCategories { get; set; }
        public DbSet<Image> Images { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            // seeding the database
            var roles = new List<IdentityRole>()
            {
                new IdentityRole{Name="Customer", NormalizedName="CUSTOMER" },
                 new IdentityRole{Name="Staff", NormalizedName="STAFF" }

            };


            // populate the database i.e identity role table :: database seeding
            builder.Entity<IdentityRole>().HasData(roles);

            base.OnModelCreating(builder);
        }
    }
}
