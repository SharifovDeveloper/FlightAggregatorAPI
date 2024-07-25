﻿// <auto-generated />
using System;
using FlightAggregatorAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FlightAggregatorAPI.Migrations
{
    [DbContext(typeof(FlightContext))]
    [Migration("20240725072330_added_new_TicketsAvailable_row")]
    partial class added_new_TicketsAvailable_row
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Booking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FlightNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PassengerEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PassengerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("FlightAggregatorAPI.Models.FlightInfo", b =>
                {
                    b.Property<string>("FlightNumber")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Airline")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ArrivalTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DepartureTime")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Stops")
                        .HasColumnType("int");

                    b.Property<int>("TicketsAvailable")
                        .HasColumnType("int");

                    b.HasKey("FlightNumber");

                    b.ToTable("Flights");

                    b.HasData(
                        new
                        {
                            FlightNumber = "MF123",
                            Airline = "MockAirline1",
                            ArrivalTime = new DateTime(2024, 7, 25, 18, 23, 29, 886, DateTimeKind.Local).AddTicks(505),
                            DepartureTime = new DateTime(2024, 7, 25, 15, 23, 29, 886, DateTimeKind.Local).AddTicks(474),
                            Price = 100m,
                            Stops = 0,
                            TicketsAvailable = 30
                        },
                        new
                        {
                            FlightNumber = "MF100",
                            Airline = "AirBus",
                            ArrivalTime = new DateTime(2024, 7, 26, 0, 23, 29, 886, DateTimeKind.Local).AddTicks(509),
                            DepartureTime = new DateTime(2024, 7, 25, 19, 23, 29, 886, DateTimeKind.Local).AddTicks(509),
                            Price = 300m,
                            Stops = 1,
                            TicketsAvailable = 50
                        },
                        new
                        {
                            FlightNumber = "FF100",
                            Airline = "Boing777",
                            ArrivalTime = new DateTime(2024, 7, 25, 17, 23, 29, 886, DateTimeKind.Local).AddTicks(511),
                            DepartureTime = new DateTime(2024, 7, 25, 13, 23, 29, 886, DateTimeKind.Local).AddTicks(511),
                            Price = 150m,
                            Stops = 0,
                            TicketsAvailable = 70
                        },
                        new
                        {
                            FlightNumber = "MD101",
                            Airline = "FlightPop",
                            ArrivalTime = new DateTime(2024, 7, 26, 5, 23, 29, 886, DateTimeKind.Local).AddTicks(513),
                            DepartureTime = new DateTime(2024, 7, 25, 17, 23, 29, 886, DateTimeKind.Local).AddTicks(513),
                            Price = 500m,
                            Stops = 3,
                            TicketsAvailable = 90
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
