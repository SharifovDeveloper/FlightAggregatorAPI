using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlightAggregatorAPI.Migrations
{
    /// <inheritdoc />
    public partial class added_new_TicketsAvailable_row : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TicketsAvailable",
                table: "Flights",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "FlightNumber",
                keyValue: "FF100",
                columns: new[] { "ArrivalTime", "DepartureTime", "TicketsAvailable" },
                values: new object[] { new DateTime(2024, 7, 25, 17, 23, 29, 886, DateTimeKind.Local).AddTicks(511), new DateTime(2024, 7, 25, 13, 23, 29, 886, DateTimeKind.Local).AddTicks(511), 70 });

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "FlightNumber",
                keyValue: "MD101",
                columns: new[] { "ArrivalTime", "DepartureTime", "TicketsAvailable" },
                values: new object[] { new DateTime(2024, 7, 26, 5, 23, 29, 886, DateTimeKind.Local).AddTicks(513), new DateTime(2024, 7, 25, 17, 23, 29, 886, DateTimeKind.Local).AddTicks(513), 90 });

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "FlightNumber",
                keyValue: "MF100",
                columns: new[] { "ArrivalTime", "DepartureTime", "TicketsAvailable" },
                values: new object[] { new DateTime(2024, 7, 26, 0, 23, 29, 886, DateTimeKind.Local).AddTicks(509), new DateTime(2024, 7, 25, 19, 23, 29, 886, DateTimeKind.Local).AddTicks(509), 50 });

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "FlightNumber",
                keyValue: "MF123",
                columns: new[] { "ArrivalTime", "DepartureTime", "TicketsAvailable" },
                values: new object[] { new DateTime(2024, 7, 25, 18, 23, 29, 886, DateTimeKind.Local).AddTicks(505), new DateTime(2024, 7, 25, 15, 23, 29, 886, DateTimeKind.Local).AddTicks(474), 30 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TicketsAvailable",
                table: "Flights");

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "FlightNumber",
                keyValue: "FF100",
                columns: new[] { "ArrivalTime", "DepartureTime" },
                values: new object[] { new DateTime(2024, 7, 25, 16, 54, 17, 51, DateTimeKind.Local).AddTicks(4444), new DateTime(2024, 7, 25, 12, 54, 17, 51, DateTimeKind.Local).AddTicks(4443) });

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "FlightNumber",
                keyValue: "MD101",
                columns: new[] { "ArrivalTime", "DepartureTime" },
                values: new object[] { new DateTime(2024, 7, 26, 4, 54, 17, 51, DateTimeKind.Local).AddTicks(4447), new DateTime(2024, 7, 25, 16, 54, 17, 51, DateTimeKind.Local).AddTicks(4446) });

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "FlightNumber",
                keyValue: "MF100",
                columns: new[] { "ArrivalTime", "DepartureTime" },
                values: new object[] { new DateTime(2024, 7, 25, 23, 54, 17, 51, DateTimeKind.Local).AddTicks(4440), new DateTime(2024, 7, 25, 18, 54, 17, 51, DateTimeKind.Local).AddTicks(4439) });

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "FlightNumber",
                keyValue: "MF123",
                columns: new[] { "ArrivalTime", "DepartureTime" },
                values: new object[] { new DateTime(2024, 7, 25, 17, 54, 17, 51, DateTimeKind.Local).AddTicks(4429), new DateTime(2024, 7, 25, 14, 54, 17, 51, DateTimeKind.Local).AddTicks(4381) });
        }
    }
}
