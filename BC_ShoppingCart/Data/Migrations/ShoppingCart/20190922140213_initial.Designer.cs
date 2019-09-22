﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ShoppingCart.Data;

namespace ShoppingCart.Data.Migrations.ShoppingCart
{
    [DbContext(typeof(ShoppingCartContext))]
    [Migration("20190922140213_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("ShoppingCart")
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ShoppingCart.Domain.CartItem", b =>
                {
                    b.Property<int>("CartItemId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CartCookie");

                    b.Property<int>("CartId");

                    b.Property<decimal>("CurrentPrice");

                    b.Property<int>("ProductId");

                    b.Property<int>("Quantity");

                    b.Property<DateTime>("SelectedDateTime");

                    b.Property<int>("State");

                    b.HasKey("CartItemId");

                    b.HasIndex("CartId");

                    b.ToTable("CartItems");
                });

            modelBuilder.Entity("ShoppingCart.Domain.NewCart", b =>
                {
                    b.Property<int>("CartId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CartCookie");

                    b.Property<string>("CustomerCookie");

                    b.Property<int>("CustomerId");

                    b.Property<DateTime>("Expires");

                    b.Property<DateTime>("Initialized");

                    b.Property<string>("SourceUrl");

                    b.HasKey("CartId");

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("ShoppingCart.Domain.CartItem", b =>
                {
                    b.HasOne("ShoppingCart.Domain.NewCart")
                        .WithMany("CartItems")
                        .HasForeignKey("CartId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
