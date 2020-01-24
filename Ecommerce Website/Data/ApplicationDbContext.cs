using System;
using System.Collections.Generic;
using System.Text;
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
    }
}
