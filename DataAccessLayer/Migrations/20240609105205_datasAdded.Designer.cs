﻿// <auto-generated />
using System;
using DataAccessLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccessLayer.Migrations
{
    [DbContext(typeof(signalRContext))]
    [Migration("20240609105205_datasAdded")]
    partial class datasAdded
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EntityLayer.Entities.About", b =>
                {
                    b.Property<int>("AboutId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AboutId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImgUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AboutId");

                    b.ToTable("Abouts");

                    b.HasData(
                        new
                        {
                            AboutId = 1,
                            Description = "About sayfası için description",
                            ImgUrl = "test",
                            Title = "Restorantımıza hoşgeldiniz..."
                        });
                });

            modelBuilder.Entity("EntityLayer.Entities.Booking", b =>
                {
                    b.Property<int>("BookingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookingId"));

                    b.Property<DateTime>("BookingDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("numberOfCustomers")
                        .HasColumnType("int");

                    b.HasKey("BookingId");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("EntityLayer.Entities.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"));

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("CategoryId");

                    b.ToTable("Categorys");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            CategoryName = "Hamburger",
                            Status = true
                        },
                        new
                        {
                            CategoryId = 2,
                            CategoryName = "Makarna",
                            Status = true
                        },
                        new
                        {
                            CategoryId = 3,
                            CategoryName = "İçecek",
                            Status = true
                        },
                        new
                        {
                            CategoryId = 4,
                            CategoryName = "Salata",
                            Status = true
                        },
                        new
                        {
                            CategoryId = 5,
                            CategoryName = "Sos",
                            Status = true
                        },
                        new
                        {
                            CategoryId = 6,
                            CategoryName = "Pizza",
                            Status = true
                        });
                });

            modelBuilder.Entity("EntityLayer.Entities.Contact", b =>
                {
                    b.Property<int>("ContactId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ContactId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ContactId");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("EntityLayer.Entities.DiscountedProduct", b =>
                {
                    b.Property<int>("DiscountedProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DiscountedProductId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DiscountRate")
                        .HasColumnType("int");

                    b.Property<string>("ImgUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DiscountedProductId");

                    b.ToTable("DiscountedProducts");
                });

            modelBuilder.Entity("EntityLayer.Entities.Feature", b =>
                {
                    b.Property<int>("FeatureId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FeatureId"));

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FeatureId");

                    b.ToTable("Features");
                });

            modelBuilder.Entity("EntityLayer.Entities.FooterInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("FooterInfos");
                });

            modelBuilder.Entity("EntityLayer.Entities.OpenHour", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClosingHour")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OpenDays")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OpeningHour")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("OpenHours");
                });

            modelBuilder.Entity("EntityLayer.Entities.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("TableNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("OrderId");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            OrderId = 1,
                            Description = "Salon 01 için order",
                            OrderDate = new DateTime(2024, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TableNumber = "Salon 01",
                            TotalPrice = 0m
                        },
                        new
                        {
                            OrderId = 2,
                            Description = "Salon 02 için order",
                            OrderDate = new DateTime(2024, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TableNumber = "Salon 02",
                            TotalPrice = 0m
                        },
                        new
                        {
                            OrderId = 3,
                            Description = "Salon 03 için order",
                            OrderDate = new DateTime(2024, 6, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TableNumber = "Salon 03",
                            TotalPrice = 0m
                        },
                        new
                        {
                            OrderId = 4,
                            Description = "Bahçe 01 için order",
                            OrderDate = new DateTime(2024, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TableNumber = "Bahçe 01",
                            TotalPrice = 0m
                        });
                });

            modelBuilder.Entity("EntityLayer.Entities.OrderDetail", b =>
                {
                    b.Property<int>("OrderDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderDetailId"));

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("ProductCount")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<decimal>("ProductPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("OrderDetailId");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderDetails");

                    b.HasData(
                        new
                        {
                            OrderDetailId = 1,
                            OrderId = 1,
                            ProductCount = 2,
                            ProductId = 1,
                            ProductPrice = 5m,
                            TotalPrice = 10m
                        },
                        new
                        {
                            OrderDetailId = 2,
                            OrderId = 1,
                            ProductCount = 1,
                            ProductId = 2,
                            ProductPrice = 7m,
                            TotalPrice = 7m
                        },
                        new
                        {
                            OrderDetailId = 3,
                            OrderId = 2,
                            ProductCount = 3,
                            ProductId = 4,
                            ProductPrice = 12m,
                            TotalPrice = 36m
                        });
                });

            modelBuilder.Entity("EntityLayer.Entities.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImgUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("ProductStatus")
                        .HasColumnType("bit");

                    b.HasKey("ProductId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            CategoryId = 2,
                            Description = "Spagetti lezzeti",
                            ImgUrl = "test",
                            Price = 60m,
                            ProductName = "Spagetti",
                            ProductStatus = true
                        },
                        new
                        {
                            ProductId = 2,
                            CategoryId = 3,
                            Description = "Türk markası  kola tercihimiz",
                            ImgUrl = "test",
                            Price = 15m,
                            ProductName = "Cola Turka",
                            ProductStatus = true
                        },
                        new
                        {
                            ProductId = 3,
                            CategoryId = 3,
                            Description = "Doğa su",
                            ImgUrl = "test",
                            Price = 2m,
                            ProductName = "Su",
                            ProductStatus = true
                        },
                        new
                        {
                            ProductId = 4,
                            CategoryId = 4,
                            Description = "Akdeniz lezzetlerinin buluştuğu salata",
                            ImgUrl = "test",
                            Price = 12m,
                            ProductName = "Akdeniz Salatası",
                            ProductStatus = true
                        },
                        new
                        {
                            ProductId = 5,
                            CategoryId = 6,
                            Description = "Nefis 5 farklı çeşit peynirle donanmış pizza",
                            ImgUrl = "test",
                            Price = 85m,
                            ProductName = "Peynirli Pizza",
                            ProductStatus = true
                        },
                        new
                        {
                            ProductId = 6,
                            CategoryId = 6,
                            Description = "Her lezzet dilimin ucunda olsun diyenlere",
                            ImgUrl = "test",
                            Price = 80m,
                            ProductName = "Karışık Pizza",
                            ProductStatus = true
                        },
                        new
                        {
                            ProductId = 7,
                            CategoryId = 6,
                            Description = "Sucuk ve pizzanın muhteşem tadına bayılacaksınız",
                            ImgUrl = "test",
                            Price = 90m,
                            ProductName = "Sucuklu Pizza",
                            ProductStatus = true
                        },
                        new
                        {
                            ProductId = 8,
                            CategoryId = 1,
                            Description = "Doyuracak bir hamburger isteyenlere",
                            ImgUrl = "test",
                            Price = 70m,
                            ProductName = "Whooper Menü",
                            ProductStatus = true
                        },
                        new
                        {
                            ProductId = 9,
                            CategoryId = 1,
                            Description = "Ben birazcık fazla mı yesem diyenlere",
                            ImgUrl = "test",
                            Price = 100m,
                            ProductName = "Double Hamburger",
                            ProductStatus = true
                        },
                        new
                        {
                            ProductId = 10,
                            CategoryId = 1,
                            Description = "Ben doyamam büyük sar abi diyenlere",
                            ImgUrl = "test",
                            Price = 120m,
                            ProductName = "Triple Hamburger",
                            ProductStatus = true
                        });
                });

            modelBuilder.Entity("EntityLayer.Entities.SocialMedia", b =>
                {
                    b.Property<int>("SocialMediaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SocialMediaId"));

                    b.Property<string>("Icon")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Platform")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("siteUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SocialMediaId");

                    b.ToTable("SocialMedias");
                });

            modelBuilder.Entity("EntityLayer.Entities.Testimonial", b =>
                {
                    b.Property<int>("TestimonialId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TestimonialId"));

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImgUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WriterName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TestimonialId");

                    b.ToTable("Testimonials");
                });

            modelBuilder.Entity("EntityLayer.Entities.OrderDetail", b =>
                {
                    b.HasOne("EntityLayer.Entities.Order", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EntityLayer.Entities.Product", "Product")
                        .WithMany("OrderDetails")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("EntityLayer.Entities.Product", b =>
                {
                    b.HasOne("EntityLayer.Entities.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("EntityLayer.Entities.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("EntityLayer.Entities.Order", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("EntityLayer.Entities.Product", b =>
                {
                    b.Navigation("OrderDetails");
                });
#pragma warning restore 612, 618
        }
    }
}