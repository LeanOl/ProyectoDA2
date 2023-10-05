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
        public DbSet<Promotion> Promotions { get; set; }
        public DbSet<PromotionCondition> PromotionConditions { get; set; }
        public virtual DbSet<Product>? Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Promotion>()
                .HasMany(p => p.PromotionConditions);
            modelBuilder.Entity<FreeProductPromotion>();
            modelBuilder.Entity<DiscountPromotion>();
            modelBuilder.Entity<SingularPromotionCondition>();
            modelBuilder.Entity<CollectionPromotionCondition>();
            modelBuilder.Entity<User>();
            modelBuilder.Entity<Session>();
            modelBuilder.Entity<ShoppingCart>();
            modelBuilder.Entity<ShoppingCartProducts>();
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

