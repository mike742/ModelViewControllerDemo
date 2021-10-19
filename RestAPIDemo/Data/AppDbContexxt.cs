using Microsoft.EntityFrameworkCore;
using RestAPIDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestAPIDemo.Data
{
    public class AppDbContexxt : DbContext
    {
        public AppDbContexxt(DbContextOptions<AppDbContexxt> options)
            : base(options) { }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<OrderProducts> OrderProducts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Boiled water", Price = 5.22 }
                );
            modelBuilder.Entity<Order>().HasData(
                 new Order { Id = 1, Name = "Mark's", Date = DateTime.Now }
                );
            modelBuilder.Entity<OrderProducts>().HasData(
                new OrderProducts { Id = 1, OrderId = 1, ProductId = 1 }
                );


        }
    }
}
