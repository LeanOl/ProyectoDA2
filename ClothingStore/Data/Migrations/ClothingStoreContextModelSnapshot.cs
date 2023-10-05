﻿// <auto-generated />
using System;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Data.Migrations
{
    [DbContext(typeof(ClothingStoreContext))]
    partial class ClothingStoreContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Domain.ProductColor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductColors");
                });

            modelBuilder.Entity("Domain.Promotion", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Promotions");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Promotion");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Domain.PromotionCondition", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductPropertyCondition")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("PromotionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("QuantityCondition")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PromotionId");

                    b.ToTable("PromotionConditions");

                    b.HasDiscriminator<string>("Discriminator").HasValue("PromotionCondition");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Domain.Role", b =>
                {
                    b.Property<Guid>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoleId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Domain.Session", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<Guid>("AuthToken")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Session");
                });

            modelBuilder.Entity("Domain.ShoppingCart", b =>
                {
                    b.Property<Guid>("IdCart")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AppliedPromotionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("IdCart");

                    b.HasIndex("AppliedPromotionId");

                    b.ToTable("ShoppingCarts");
                });

            modelBuilder.Entity("Domain.ShoppingCartProducts", b =>
                {
                    b.Property<Guid>("ShoppingCartId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<Guid>("ShoppingCartIdCart")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ShoppingCartId");

                    b.HasIndex("ProductId");

                    b.HasIndex("ShoppingCartIdCart");

                    b.ToTable("ShoppingCartProducts");
                });

            modelBuilder.Entity("Domain.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DeliveryAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Domain.DiscountPromotion", b =>
                {
                    b.HasBaseType("Domain.Promotion");

                    b.Property<double>("DiscountPercentage")
                        .HasColumnType("float");

                    b.HasDiscriminator().HasValue("DiscountPromotion");
                });

            modelBuilder.Entity("Domain.FreeProductPromotion", b =>
                {
                    b.HasBaseType("Domain.Promotion");

                    b.Property<int>("FreeProductCount")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("FreeProductPromotion");
                });

            modelBuilder.Entity("Domain.CollectionPromotionCondition", b =>
                {
                    b.HasBaseType("Domain.PromotionCondition");

                    b.HasDiscriminator().HasValue("CollectionPromotionCondition");
                });

            modelBuilder.Entity("Domain.SingularPromotionCondition", b =>
                {
                    b.HasBaseType("Domain.PromotionCondition");

                    b.HasDiscriminator().HasValue("SingularPromotionCondition");
                });

            modelBuilder.Entity("Domain.ProductColor", b =>
                {
                    b.HasOne("Domain.Product", "Product")
                        .WithMany("Colors")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Domain.PromotionCondition", b =>
                {
                    b.HasOne("Domain.Promotion", null)
                        .WithMany("PromotionConditions")
                        .HasForeignKey("PromotionId");
                });

            modelBuilder.Entity("Domain.Session", b =>
                {
                    b.HasOne("Domain.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.ShoppingCart", b =>
                {
                    b.HasOne("Domain.Promotion", "AppliedPromotion")
                        .WithMany()
                        .HasForeignKey("AppliedPromotionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppliedPromotion");
                });

            modelBuilder.Entity("Domain.ShoppingCartProducts", b =>
                {
                    b.HasOne("Domain.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.ShoppingCart", "ShoppingCart")
                        .WithMany("ShoppingCartProducts")
                        .HasForeignKey("ShoppingCartIdCart")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("ShoppingCart");
                });

            modelBuilder.Entity("Domain.Product", b =>
                {
                    b.Navigation("Colors");
                });

            modelBuilder.Entity("Domain.Promotion", b =>
                {
                    b.Navigation("PromotionConditions");
                });

            modelBuilder.Entity("Domain.ShoppingCart", b =>
                {
                    b.Navigation("ShoppingCartProducts");
                });
#pragma warning restore 612, 618
        }
    }
}
