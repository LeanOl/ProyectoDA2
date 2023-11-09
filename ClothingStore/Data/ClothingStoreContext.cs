using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Data
{
	public class ClothingStoreContext : DbContext
	{
        public ClothingStoreContext() { }
        public ClothingStoreContext(DbContextOptions options) : base(options) { }

        public virtual DbSet<User>? Users { get; set; }
        public virtual DbSet<Role>? Roles { get; set; } 
        public virtual DbSet<ShoppingCart>? ShoppingCarts { get; set; }
        public virtual DbSet<ShoppingCartProducts>? ShoppingCartProducts { get; set; }
        public virtual DbSet<ProductColor>? ProductColors { get; set; }
        public virtual DbSet<Product>? Products { get; set; }
        public virtual DbSet<Purchase>? Purchases { get; set; }
        public virtual DbSet<PurchaseProduct>? PurchaseProducts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<User>();
            modelBuilder.Entity<Session>();
            modelBuilder.Entity<ShoppingCart>();
            modelBuilder.Entity<ShoppingCartProducts>().HasKey(sp => new{ sp.ProductId, sp.ShoppingCartId});
            modelBuilder.Entity<PurchaseProduct>().HasKey(pp => new { pp.ProductId, pp.PurchaseId });
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

