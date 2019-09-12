using System;
using Microsoft.EntityFrameworkCore;

using inventoryapi.Domain.Models;

namespace inventoryapi.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<Price> Prices { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Tag> Tags { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Price>().ToTable("Prices");
            modelBuilder.Entity<Price>().HasKey(p => p.Id);

            modelBuilder.Entity<Address>().ToTable("Addresses");
            modelBuilder.Entity<Address>().HasKey(a => a.Id);

            modelBuilder.Entity<Tag>().ToTable("Tags");
            modelBuilder.Entity<Tag>().HasKey(t => t.Id);

            modelBuilder.Entity<Category>().ToTable("Categories");
            modelBuilder.Entity<Category>().HasKey(c => c.Id);
            modelBuilder.Entity<Category>().Property(c => c.Id).IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<Category>().Property(c => c.Name).IsRequired().HasMaxLength(128);

            modelBuilder.Entity<Product>().ToTable("Products");
            modelBuilder.Entity<Product>().HasKey(p => p.Id);
            modelBuilder.Entity<Product>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<Product>().Property(p => p.Name).IsRequired().HasMaxLength(128);

            modelBuilder.Entity<ProductCategory>().HasKey(pc => new { pc.ProductId, pc.CategoryId });

            //modelBuilder.Entity<Property>().ToTable("Properties");
            //modelBuilder.Entity<Property>().HasKey(p => p.Id);
            //modelBuilder.Entity<Property>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            //modelBuilder.Entity<Property>().Property(p => p.Title).IsRequired().HasMaxLength(128);

            // Generate data
            modelBuilder.Entity<Category>().HasData
            (
                new Category { Id = 100, Name = "House for Rent" },
                new Category { Id = 101, Name = "Products for Sale" }
            );

            modelBuilder.Entity<Product>().HasData
            (
                new Product { Id = 100, Name = "Digital Product", QuantityInStock = null, QuantityInPack = null },
                new Product { Id = 101, Name = "6 Pack of Razors", QuantityInStock = 3, QuantityInPack = 6 },
                new Product { Id = 102, Name = "Normal Stock Product", QuantityInStock = 10, QuantityInPack = null },
                new Product { Id = 103, Name = "Another Stock Product", QuantityInStock = 5, QuantityInPack = null }
            );

            modelBuilder.Entity<ProductCategory>().HasData
            (
                new ProductCategory { ProductId = 100, CategoryId = 101 },
                new ProductCategory { ProductId = 101, CategoryId = 101 },
                new ProductCategory { ProductId = 102, CategoryId = 101 },
                new ProductCategory { ProductId = 103, CategoryId = 101 }
            );

            modelBuilder.Entity<Address>().HasData
            (
                new Address { Id = 100, Line1 = "123 Some Street", City = "Vancouver" },
                new Address { Id = 101, Line1 = "243 Johnson Road", City = "Vancouver" },
                new Address { Id = 102, Line1 = "5675 Empire Blvd", City = "Victoria" },
                new Address { Id = 103, Line1 = "920 Highlands Way", City = "Victoria" }
            );

            modelBuilder.Entity<Property>().HasData
            (
                new Property { Id = 100, Title = "Van Property #1", AddressId = 100 },
                new Property { Id = 101, Title = "Van Property #2", AddressId = 101 },
                new Property { Id = 102, Title = "Vic Property #1", AddressId = 102 },
                new Property { Id = 103, Title = "Vic Property #2", AddressId = 103 }
            );

            modelBuilder.Entity<Price>().HasData
            (
                new Price { Id = 100, Amount = 1280.00, Name = "Van Property #1 Price", PropertyId = 100 },
                new Price { Id = 101, Amount = 2250.00, Name = "Van Property #2 Price", PropertyId = 101 },
                new Price { Id = 102, Amount = 250.00, Name = "Product #1 Price", ProductId = 100 },
                new Price { Id = 103, Amount = 89.50, Name = "Product #2 Price", ProductId = 101 }
            );

            modelBuilder.Entity<Tag>().HasData
            (
                new Tag { Id = 100, Name = "Featured" },
                new Tag { Id = 101, Name = "Special" }
            );   
        }
    }
}
