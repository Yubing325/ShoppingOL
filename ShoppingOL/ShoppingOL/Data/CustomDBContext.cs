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
            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasColumnType("decimal(18,2)");
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }

        

    }
}
