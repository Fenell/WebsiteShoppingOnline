﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ShoppingOnline.DAL.Database.AppDbContext;

#nullable disable

namespace ShoppingOnline.DAL.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ShoppingOnline.DAL.Entities.Brand", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("SeoTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdateAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdateBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Brand", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("313e7a81-9b89-4981-8389-477cb23cfabb"),
                            CreatedAt = new DateTime(2023, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedBy = "Le Xuan Minh Chien",
                            IsDeleted = false,
                            Name = "Adias",
                            Status = "ACTIVE",
                            UpdateAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("d80cd77c-a89b-4ff2-8f60-20bfe056c2ed"),
                            CreatedAt = new DateTime(2023, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedBy = "Le Xuan Minh Chien",
                            IsDeleted = false,
                            Name = "Nike",
                            Status = "ACTIVE",
                            UpdateAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("ShoppingOnline.DAL.Entities.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("SeoTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdateAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdateBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Category", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("5bd691e4-bd41-47c3-bb5b-e23319511841"),
                            CreatedAt = new DateTime(2023, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedBy = "Le Xuan Minh Chien",
                            IsDeleted = false,
                            Name = "Polo",
                            Status = "ACTIVE",
                            UpdateAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("30f958f6-f5b0-4651-8918-5d02f8cb6cee"),
                            CreatedAt = new DateTime(2023, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedBy = "Le Xuan Minh Chien",
                            IsDeleted = false,
                            Name = "T-Shirt",
                            Status = "ACTIVE",
                            UpdateAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("ShoppingOnline.DAL.Entities.Color", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdateAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdateBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Color", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("a0097f6c-3c63-4a8b-875a-80e0adfb4891"),
                            CreatedAt = new DateTime(2023, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedBy = "Le Xuan Minh Chien",
                            IsDeleted = false,
                            Name = "Đen",
                            Status = "ACTIVE",
                            UpdateAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("64718a33-4e12-4310-bfa6-459a3b03bac5"),
                            CreatedAt = new DateTime(2023, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedBy = "Le Xuan Minh Chien",
                            IsDeleted = false,
                            Name = "Trắng",
                            Status = "ACTIVE",
                            UpdateAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("ShoppingOnline.DAL.Entities.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OrderStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PaymentMethod")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.Property<Guid>("PromotionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(10,2)");

                    b.Property<DateTime>("UpdateAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdateBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PromotionId");

                    b.ToTable("Order", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("46b23fc3-bf12-4104-8785-d650360181ed"),
                            Address = "Thai Binh",
                            CreatedAt = new DateTime(2023, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedBy = "Le Xuan Minh Chien",
                            CustomerName = "Mai Tuan Dat",
                            IsDeleted = false,
                            Note = "Khach vip",
                            OrderStatus = "SUCCESS",
                            PhoneNumber = "1234567890",
                            PromotionId = new Guid("6dfb12e5-04bc-4680-b953-4b53e8e56cb5"),
                            Total = 259000m,
                            UpdateAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("ShoppingOnline.DAL.Entities.OrderItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("OrderStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(10,2)");

                    b.Property<Guid>("ProductItemId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdateAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdateBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductItemId");

                    b.ToTable("OrderItem", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("d2dda39f-b2a0-467f-970d-1f9ded874aa0"),
                            CreatedAt = new DateTime(2023, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedBy = "Le Xuan Minh Chien",
                            IsDeleted = false,
                            OrderId = new Guid("46b23fc3-bf12-4104-8785-d650360181ed"),
                            OrderStatus = "SUCCESS",
                            Price = 259000m,
                            ProductItemId = new Guid("18ec90bf-8932-4a59-bbb2-34de95ce9602"),
                            Quantity = 1,
                            UpdateAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("ShoppingOnline.DAL.Entities.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BrandId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DefaultImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Discount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(10,2)");

                    b.Property<string>("SeoTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdateAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdateBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Product", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("38e3f05f-f89a-4fb3-8cb7-9262110d7d16"),
                            BrandId = new Guid("313e7a81-9b89-4981-8389-477cb23cfabb"),
                            CategoryId = new Guid("5bd691e4-bd41-47c3-bb5b-e23319511841"),
                            CreatedAt = new DateTime(2023, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedBy = "Le Xuan Minh Chien",
                            Description = "- Được kiểm tra hàng trước khi nhận hàng- Đổi hàng trong vòng 30 ngày kể từ khi nhận hàng",
                            Discount = 275000m,
                            IsDeleted = false,
                            Name = "Regular.XL.2.3131",
                            Price = 259000m,
                            Status = "ACTIVE",
                            UpdateAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("4dccaddc-9dbc-4f6d-a6c8-244be05d735f"),
                            BrandId = new Guid("d80cd77c-a89b-4ff2-8f60-20bfe056c2ed"),
                            CategoryId = new Guid("30f958f6-f5b0-4651-8918-5d02f8cb6cee"),
                            CreatedAt = new DateTime(2023, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedBy = "Le Xuan Minh Chien",
                            Description = "- Được kiểm tra hàng trước khi nhận hàng- Đổi hàng trong vòng 30 ngày kể từ khi nhận hàng",
                            Discount = 275000m,
                            IsDeleted = false,
                            Name = "Regular L.3.2987",
                            Price = 339000m,
                            Status = "ACTIVE",
                            UpdateAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("ShoppingOnline.DAL.Entities.ProductImage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("Position")
                        .HasColumnType("int");

                    b.Property<Guid>("ProducItemtId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdateAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdateBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProducItemtId");

                    b.ToTable("ProductImage", (string)null);
                });

            modelBuilder.Entity("ShoppingOnline.DAL.Entities.ProductItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ColorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<Guid>("SizeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdateAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdateBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ColorId");

                    b.HasIndex("ProductId");

                    b.HasIndex("SizeId");

                    b.ToTable("ProductItem", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("18ec90bf-8932-4a59-bbb2-34de95ce9602"),
                            ColorId = new Guid("a0097f6c-3c63-4a8b-875a-80e0adfb4891"),
                            CreatedAt = new DateTime(2023, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedBy = "Le Xuan Minh Chien",
                            IsDeleted = false,
                            ProductId = new Guid("38e3f05f-f89a-4fb3-8cb7-9262110d7d16"),
                            Quantity = 1,
                            SizeId = new Guid("3f12e4d9-0e48-4c32-b788-7769d2be7b2c"),
                            Status = "ACTIVE",
                            UpdateAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("3c0915db-2bcf-47f9-be6e-f39bc127abca"),
                            ColorId = new Guid("a0097f6c-3c63-4a8b-875a-80e0adfb4891"),
                            CreatedAt = new DateTime(2023, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedBy = "Le Xuan Minh Chien",
                            IsDeleted = false,
                            ProductId = new Guid("4dccaddc-9dbc-4f6d-a6c8-244be05d735f"),
                            Quantity = 1,
                            SizeId = new Guid("3f12e4d9-0e48-4c32-b788-7769d2be7b2c"),
                            Status = "ACTIVE",
                            UpdateAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("ShoppingOnline.DAL.Entities.Promotion", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DiscountPercent")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("PromotionStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdateAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdateBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Promotion", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("6dfb12e5-04bc-4680-b953-4b53e8e56cb5"),
                            Code = "xxxx-noi-em-anh-chien-de-giam-10%",
                            CreatedAt = new DateTime(2023, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedBy = "Le Xuan Minh Chien",
                            DiscountPercent = 10,
                            IsDeleted = false,
                            PromotionStatus = "ACTIVE",
                            UpdateAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("ShoppingOnline.DAL.Entities.Ratiting", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("StartPoint")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdateAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdateBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("Ratiting", (string)null);
                });

            modelBuilder.Entity("ShoppingOnline.DAL.Entities.Size", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdateAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdateBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Size", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("3f12e4d9-0e48-4c32-b788-7769d2be7b2c"),
                            CreatedAt = new DateTime(2023, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedBy = "Le Xuan Minh Chien",
                            IsDeleted = false,
                            Name = "XL",
                            Status = "ACTIVE",
                            UpdateAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("468a7e91-42a7-4e09-9834-d3bc0ce2c2f5"),
                            CreatedAt = new DateTime(2023, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedBy = "Le Xuan Minh Chien",
                            IsDeleted = false,
                            Name = "M",
                            Status = "ACTIVE",
                            UpdateAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("ShoppingOnline.DAL.Entities.SlideShow", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LinkDetail")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("Position")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdateAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdateBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("SlideShow", (string)null);
                });

            modelBuilder.Entity("ShoppingOnline.DAL.Entities.Order", b =>
                {
                    b.HasOne("ShoppingOnline.DAL.Entities.Promotion", "Promotion")
                        .WithMany("Orders")
                        .HasForeignKey("PromotionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Promotion");
                });

            modelBuilder.Entity("ShoppingOnline.DAL.Entities.OrderItem", b =>
                {
                    b.HasOne("ShoppingOnline.DAL.Entities.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ShoppingOnline.DAL.Entities.ProductItem", "ProductItem")
                        .WithMany("OrderItems")
                        .HasForeignKey("ProductItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("ProductItem");
                });

            modelBuilder.Entity("ShoppingOnline.DAL.Entities.Product", b =>
                {
                    b.HasOne("ShoppingOnline.DAL.Entities.Brand", "Brand")
                        .WithMany("Products")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ShoppingOnline.DAL.Entities.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("ShoppingOnline.DAL.Entities.ProductImage", b =>
                {
                    b.HasOne("ShoppingOnline.DAL.Entities.ProductItem", "ProductItem")
                        .WithMany("ProductImages")
                        .HasForeignKey("ProducItemtId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProductItem");
                });

            modelBuilder.Entity("ShoppingOnline.DAL.Entities.ProductItem", b =>
                {
                    b.HasOne("ShoppingOnline.DAL.Entities.Color", "Color")
                        .WithMany("ProductItems")
                        .HasForeignKey("ColorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ShoppingOnline.DAL.Entities.Product", "Product")
                        .WithMany("ProductItems")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ShoppingOnline.DAL.Entities.Size", "Size")
                        .WithMany("ProductItems")
                        .HasForeignKey("SizeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Color");

                    b.Navigation("Product");

                    b.Navigation("Size");
                });

            modelBuilder.Entity("ShoppingOnline.DAL.Entities.Ratiting", b =>
                {
                    b.HasOne("ShoppingOnline.DAL.Entities.Product", "Product")
                        .WithMany("Ratitings")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("ShoppingOnline.DAL.Entities.Brand", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("ShoppingOnline.DAL.Entities.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("ShoppingOnline.DAL.Entities.Color", b =>
                {
                    b.Navigation("ProductItems");
                });

            modelBuilder.Entity("ShoppingOnline.DAL.Entities.Order", b =>
                {
                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("ShoppingOnline.DAL.Entities.Product", b =>
                {
                    b.Navigation("ProductItems");

                    b.Navigation("Ratitings");
                });

            modelBuilder.Entity("ShoppingOnline.DAL.Entities.ProductItem", b =>
                {
                    b.Navigation("OrderItems");

                    b.Navigation("ProductImages");
                });

            modelBuilder.Entity("ShoppingOnline.DAL.Entities.Promotion", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("ShoppingOnline.DAL.Entities.Size", b =>
                {
                    b.Navigation("ProductItems");
                });
#pragma warning restore 612, 618
        }
    }
}
