using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StreamSharp.Api.Models;

namespace StreamSharp.Api.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 1,
                Name = "Curso de C#",
                Price = 1999.99M,
                Quantity = 1
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 2,
                Name = "Curso de Golang",
                Price = 3999.99M,
                Quantity = 2
            });
        }
    }
}