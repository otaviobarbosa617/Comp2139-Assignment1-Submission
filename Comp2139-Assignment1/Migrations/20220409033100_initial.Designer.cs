﻿// <auto-generated />
using System;
using GBCSporting_OJO.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GBCSporting_OJO.Migrations
{
    [DbContext(typeof(GBCSporting_OJOContext))]
    [Migration("20220409033100_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("GBCSporting_OJO.Models.Customers", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerId"), 1L, 1);

                    b.Property<string>("CustomerAddress")
                        .IsRequired()
                        .HasMaxLength(51)
                        .HasColumnType("nvarchar(51)");

                    b.Property<string>("CustomerCity")
                        .IsRequired()
                        .HasMaxLength(51)
                        .HasColumnType("nvarchar(51)");

                    b.Property<string>("CustomerCountry")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerEmail")
                        .IsRequired()
                        .HasMaxLength(51)
                        .HasColumnType("nvarchar(51)");

                    b.Property<string>("CustomerFirstName")
                        .IsRequired()
                        .HasMaxLength(51)
                        .HasColumnType("nvarchar(51)");

                    b.Property<string>("CustomerLastName")
                        .IsRequired()
                        .HasMaxLength(51)
                        .HasColumnType("nvarchar(51)");

                    b.Property<string>("CustomerPhone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerState")
                        .IsRequired()
                        .HasMaxLength(51)
                        .HasColumnType("nvarchar(51)");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            CustomerId = 1,
                            CustomerAddress = "Test Street",
                            CustomerCity = "Toronto",
                            CustomerCountry = "Canada",
                            CustomerEmail = "janine.maeusana@georgebrown.ca",
                            CustomerFirstName = "Janine",
                            CustomerLastName = "Usana",
                            CustomerPhone = "666-666-6666",
                            CustomerState = "Ontario"
                        },
                        new
                        {
                            CustomerId = 2,
                            CustomerAddress = "Test Avenue",
                            CustomerCity = "New York",
                            CustomerCountry = "USA",
                            CustomerEmail = "omar.nabi@georgebrown.ca",
                            CustomerFirstName = "Omar",
                            CustomerLastName = "Nabi",
                            CustomerPhone = "666-666-6666",
                            CustomerState = "NY"
                        });
                });

            modelBuilder.Entity("GBCSporting_OJO.Models.Incident", b =>
                {
                    b.Property<int>("IncidentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IncidentId"), 1L, 1);

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("IncidentDateClosed")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("IncidentDateOpened")
                        .HasColumnType("datetime2");

                    b.Property<string>("IncidentDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IncidentTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("TechnicianId")
                        .HasColumnType("int");

                    b.HasKey("IncidentId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("ProductId");

                    b.HasIndex("TechnicianId");

                    b.ToTable("Incidents");

                    b.HasData(
                        new
                        {
                            IncidentId = 1,
                            CustomerId = 1,
                            IncidentDateClosed = new DateTime(2022, 4, 8, 0, 0, 0, 0, DateTimeKind.Local),
                            IncidentDateOpened = new DateTime(2022, 4, 8, 0, 0, 0, 0, DateTimeKind.Local),
                            IncidentDescription = "Create separated logins for users and admins",
                            IncidentTitle = "Fix Login",
                            ProductId = 1,
                            TechnicianId = 1
                        },
                        new
                        {
                            IncidentId = 2,
                            CustomerId = 2,
                            IncidentDateOpened = new DateTime(2022, 4, 8, 0, 0, 0, 0, DateTimeKind.Local),
                            IncidentDescription = "Updated the whole visual",
                            IncidentTitle = "Change overall theme",
                            ProductId = 1,
                            TechnicianId = 2
                        });
                });

            modelBuilder.Entity("GBCSporting_OJO.Models.Products", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"), 1L, 1);

                    b.Property<string>("ProductCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductPrice")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ProductReleaseDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ProductId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            ProductCode = "1Sport",
                            ProductName = "Sport One - Team Management",
                            ProductPrice = "29.99",
                            ProductReleaseDate = new DateTime(2022, 4, 8, 0, 0, 0, 0, DateTimeKind.Local)
                        });
                });

            modelBuilder.Entity("GBCSporting_OJO.Models.Technicians", b =>
                {
                    b.Property<int>("TechnicianId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TechnicianId"), 1L, 1);

                    b.Property<string>("TechnicianEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TechnicianName")
                        .IsRequired()
                        .HasMaxLength(51)
                        .HasColumnType("nvarchar(51)");

                    b.Property<string>("TechnicianPhone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TechnicianId");

                    b.ToTable("Technicians");

                    b.HasData(
                        new
                        {
                            TechnicianId = 1,
                            TechnicianEmail = "otavio.pereirabarbosa@georgebrown.ca",
                            TechnicianName = "Otavio Barbosa",
                            TechnicianPhone = "647-562-3407"
                        },
                        new
                        {
                            TechnicianId = 2,
                            TechnicianEmail = "test@test.com",
                            TechnicianName = "Roger Gracie",
                            TechnicianPhone = "647-562-3407"
                        });
                });

            modelBuilder.Entity("GBCSporting_OJO.Models.Incident", b =>
                {
                    b.HasOne("GBCSporting_OJO.Models.Customers", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GBCSporting_OJO.Models.Products", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GBCSporting_OJO.Models.Technicians", "Technician")
                        .WithMany()
                        .HasForeignKey("TechnicianId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Product");

                    b.Navigation("Technician");
                });
#pragma warning restore 612, 618
        }
    }
}
