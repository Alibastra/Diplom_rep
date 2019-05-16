﻿// <auto-generated />
using System;
using Hotel.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Hotel.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20190516131407_suooly")]
    partial class suooly
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Hotel.Models.CheckIn", b =>
                {
                    b.Property<int>("CheckInID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Arrival");

                    b.Property<int>("CustomerID");

                    b.Property<DateTime>("Department");

                    b.Property<string>("LastName");

                    b.Property<int>("RoomID");

                    b.HasKey("CheckInID");

                    b.ToTable("CheckIns");
                });

            modelBuilder.Entity("Hotel.Models.Customer", b =>
                {
                    b.Property<int>("CustomerID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("BithDate");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<string>("PhoneNumber")
                        .IsRequired();

                    b.HasKey("CustomerID");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Hotel.Models.Room", b =>
                {
                    b.Property<int>("RoomID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Category")
                        .IsRequired();

                    b.Property<string>("Comments");

                    b.Property<decimal>("Price");

                    b.Property<int>("Quantity");

                    b.Property<bool>("State");

                    b.HasKey("RoomID");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("Hotel.Models.Service", b =>
                {
                    b.Property<int>("ServiceID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Category")
                        .IsRequired();

                    b.Property<string>("Comments");

                    b.Property<decimal>("Price");

                    b.Property<string>("ServiceName")
                        .IsRequired();

                    b.Property<bool>("State");

                    b.HasKey("ServiceID");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("Hotel.Models.Supply", b =>
                {
                    b.Property<int>("SupplyID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Quantity");

                    b.Property<int>("ServiceID");

                    b.Property<DateTime>("SupplyDate");

                    b.HasKey("SupplyID");

                    b.ToTable("Supplys");
                });
#pragma warning restore 612, 618
        }
    }
}
