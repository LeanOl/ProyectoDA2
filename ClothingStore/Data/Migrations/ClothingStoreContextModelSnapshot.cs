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
                .HasAnnotation("ProductVersion", "6.0.22")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

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

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Domain.CollectionPromotionCondition", b =>
                {
                    b.HasBaseType("Domain.PromotionCondition");

                    b.HasDiscriminator().HasValue("CollectionPromotionCondition");
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

            modelBuilder.Entity("Domain.SingularPromotionCondition", b =>
                {
                    b.HasBaseType("Domain.PromotionCondition");

                    b.HasDiscriminator().HasValue("SingularPromotionCondition");
                });

            modelBuilder.Entity("Domain.PromotionCondition", b =>
                {
                    b.HasOne("Domain.Promotion", null)
                        .WithMany("PromotionConditions")
                        .HasForeignKey("PromotionId");
                });

            modelBuilder.Entity("Domain.Promotion", b =>
                {
                    b.Navigation("PromotionConditions");
                });
#pragma warning restore 612, 618
        }
    }
}
