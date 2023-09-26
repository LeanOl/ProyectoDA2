using System;
using System.IO;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore.SqlServer;
using System.Data;

namespace Data
{
	public class ClothingStoreContext : DbContext
	{
        public ClothingStoreContext() { }
        public ClothingStoreContext(DbContextOptions options) : base(options) { }

        public virtual DbSet<User>? Users { get; set; }
        public virtual DbSet<Product>? Products { get; set; }
        public virtual DbSet<Role>? Roles { get; set; } //el ? le permite ser null 

        protected override void OnModelCreating(ModelBuilder modelBuilder) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string directory = Directory.GetCurrentDirectory();

                IConfigurationRoot configuration = new ConfigurationBuilder()
                         .SetBasePath(directory)
                         .AddJsonFile("appsettings.json")
                         .Build();

                var connectionString = configuration.GetConnectionString(@"clothingStoreDB");

                optionsBuilder.UseSqlServer(connectionString);
            }
        }
    }
}

