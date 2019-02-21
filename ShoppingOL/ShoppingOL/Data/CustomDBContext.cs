using ShoppingOL.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingOL.Data
{
    public class CustomDBContext:DbContext
    {
        public CustomDBContext(DbContextOptions<CustomDBContext> options)
            :base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Order>()
                .HasData(new Order()
                {
                    Id=1,
                    OrderDate = DateTime.UtcNow,
                    OrderNumber = "12345"
                });
               
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }

       

    }
}
