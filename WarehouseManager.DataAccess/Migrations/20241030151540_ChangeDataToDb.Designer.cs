﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using WarehouseManager.DataAccess;

#nullable disable

namespace WarehouseManager.DataAccess.Migrations
{
    [DbContext(typeof(WarehouseDbContext))]
    [Migration("20241030151540_ChangeDataToDb")]
    partial class ChangeDataToDb
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("IsCompleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            Id = new Guid("44444444-4444-4444-4444-444444444444"),
                            IsCompleted = false,
                            OrderDate = new DateTime(2024, 10, 27, 17, 15, 40, 167, DateTimeKind.Utc).AddTicks(8406)
                        },
                        new
                        {
                            Id = new Guid("55555555-5555-5555-5555-555555555555"),
                            IsCompleted = true,
                            OrderDate = new DateTime(2024, 10, 29, 17, 15, 40, 167, DateTimeKind.Utc).AddTicks(8454)
                        });
                });

            modelBuilder.Entity("WarehouseManager.DataAccess.Models.OrderItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uuid");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderItems");

                    b.HasData(
                        new
                        {
                            Id = new Guid("66666666-6666-6666-6666-666666666666"),
                            OrderId = new Guid("44444444-4444-4444-4444-444444444444"),
                            ProductId = new Guid("11111111-1111-1111-1111-111111111111"),
                            Quantity = 2
                        },
                        new
                        {
                            Id = new Guid("77777777-7777-7777-7777-777777777777"),
                            OrderId = new Guid("44444444-4444-4444-4444-444444444444"),
                            ProductId = new Guid("22222222-2222-2222-2222-222222222222"),
                            Quantity = 1
                        },
                        new
                        {
                            Id = new Guid("88888888-8888-8888-8888-888888888888"),
                            OrderId = new Guid("55555555-5555-5555-5555-555555555555"),
                            ProductId = new Guid("33333333-3333-3333-3333-333333333333"),
                            Quantity = 3
                        });
                });

            modelBuilder.Entity("WarehouseManager.DataAccess.Models.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("IsInPurchaseQueue")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<int>("Stock")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = new Guid("11111111-1111-1111-1111-111111111111"),
                            IsInPurchaseQueue = false,
                            Name = "Laptop",
                            Price = 999.99m,
                            Stock = 10
                        },
                        new
                        {
                            Id = new Guid("22222222-2222-2222-2222-222222222222"),
                            IsInPurchaseQueue = true,
                            Name = "Smartphone",
                            Price = 699.99m,
                            Stock = 5
                        },
                        new
                        {
                            Id = new Guid("33333333-3333-3333-3333-333333333333"),
                            IsInPurchaseQueue = true,
                            Name = "Headphones",
                            Price = 199.99m,
                            Stock = 0
                        });
                });

            modelBuilder.Entity("WarehouseManager.DataAccess.Models.PurchaseQueue", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uuid");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("PurchaseQueues");

                    b.HasData(
                        new
                        {
                            Id = new Guid("99999999-9999-9999-9999-999999999999"),
                            ProductId = new Guid("33333333-3333-3333-3333-333333333333"),
                            Quantity = 10
                        });
                });

            modelBuilder.Entity("WarehouseManager.DataAccess.Models.OrderItem", b =>
                {
                    b.HasOne("Order", "Order")
                        .WithMany("Items")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WarehouseManager.DataAccess.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("WarehouseManager.DataAccess.Models.PurchaseQueue", b =>
                {
                    b.HasOne("WarehouseManager.DataAccess.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Order", b =>
                {
                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}
