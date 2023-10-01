﻿using System;
using System.IO;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore.SqlServer;
namespace Data
{
	public class ClothingStoreContext : DbContext
	{
        public ClothingStoreContext() { }
        public ClothingStoreContext(DbContextOptions options) : base(options) { }

        public virtual DbSet<User>? Users { get; set; }
        public DbSet<Promotion> Promotions { get; set; }
        public DbSet<PromotionCondition> PromotionConditions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Promotion>()
                .HasMany(p => p.PromotionConditions);
            modelBuilder.Entity<FreeProductPromotion>();
            modelBuilder.Entity<DiscountPromotion>();
            modelBuilder.Entity<SingularPromotionCondition>();
            modelBuilder.Entity<CollectionPromotionCondition>();
            //modelBuilder.Entity<User>();

        }

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

