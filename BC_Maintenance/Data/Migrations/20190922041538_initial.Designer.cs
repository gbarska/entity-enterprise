﻿// <auto-generated />
using System;
using Maintenance.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Maintenance.Data.Migrations
{
    [DbContext(typeof(MaintenanceContext))]
    [Migration("20190922041538_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("Maintenance")
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Maintenance.Domain.Address", b =>
                {
                    b.Property<int>("AddressId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AddressType");

                    b.Property<string>("City");

                    b.Property<int>("CustomerId");

                    b.Property<string>("PostalCode");

                    b.Property<string>("StateProvince");

                    b.Property<string>("Street");

                    b.HasKey("AddressId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("Maintenance.Domain.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("CategoryId");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("Maintenance.Domain.ContactDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CustomerId");

                    b.Property<string>("Facebook");

                    b.Property<string>("HomePhone");

                    b.Property<string>("LinkedIn");

                    b.Property<string>("Messenger");

                    b.Property<string>("MobilePhone");

                    b.Property<string>("OfficePhone");

                    b.Property<string>("Skype");

                    b.Property<string>("TwitterAlias");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId")
                        .IsUnique();

                    b.ToTable("ContactDetail");
                });

            modelBuilder.Entity("Maintenance.Domain.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CustomerCookie");

                    b.Property<DateTime>("DateOfBirth");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Maintenance.Domain.LineItem", b =>
                {
                    b.Property<int>("LineItemId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("OrderId");

                    b.Property<int>("ProductId");

                    b.Property<int>("Quantity");

                    b.HasKey("LineItemId");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("LineItem");
                });

            modelBuilder.Entity("Maintenance.Domain.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CustomerId");

                    b.Property<DateTime>("OrderDate");

                    b.Property<int>("OrderSource");

                    b.HasKey("OrderId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("Maintenance.Domain.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CategoryId");

                    b.Property<decimal>("CurrentPrice");

                    b.Property<string>("Description");

                    b.Property<bool>("IsAvailable");

                    b.Property<int>("MaxQuantity");

                    b.Property<string>("Name");

                    b.Property<DateTime>("ProductionStart");

                    b.HasKey("ProductId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Maintenance.Domain.Address", b =>
                {
                    b.HasOne("Maintenance.Domain.Customer", "Customer")
                        .WithMany("Addresses")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Maintenance.Domain.ContactDetail", b =>
                {
                    b.HasOne("Maintenance.Domain.Customer")
                        .WithOne("ContactDetail")
                        .HasForeignKey("Maintenance.Domain.ContactDetail", "CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Maintenance.Domain.LineItem", b =>
                {
                    b.HasOne("Maintenance.Domain.Order", "Order")
                        .WithMany("LineItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Maintenance.Domain.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Maintenance.Domain.Order", b =>
                {
                    b.HasOne("Maintenance.Domain.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Maintenance.Domain.Product", b =>
                {
                    b.HasOne("Maintenance.Domain.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
