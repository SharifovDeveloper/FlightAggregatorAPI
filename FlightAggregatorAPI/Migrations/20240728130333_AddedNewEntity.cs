using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlightAggregatorAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddedNewEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    TicketNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BookingId = table.Column<int>(type: "int", nullable: false),
                    IssueDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.TicketNumber);
                });

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "FlightNumber",
                keyValue: "FF100",
                columns: new[] { "ArrivalTime", "DepartureTime" },
                values: new object[] { new DateTime(2024, 7, 28, 23, 3, 33, 478, DateTimeKind.Local).AddTicks(378), new DateTime(2024, 7, 28, 19, 3, 33, 478, DateTimeKind.Local).AddTicks(377) });

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "FlightNumber",
                keyValue: "MD101",
                columns: new[] { "ArrivalTime", "DepartureTime" },
                values: new object[] { new DateTime(2024, 7, 29, 11, 3, 33, 478, DateTimeKind.Local).AddTicks(380), new DateTime(2024, 7, 28, 23, 3, 33, 478, DateTimeKind.Local).AddTicks(380) });

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "FlightNumber",
                keyValue: "MF100",
                columns: new[] { "ArrivalTime", "DepartureTime" },
                values: new object[] { new DateTime(2024, 7, 29, 6, 3, 33, 478, DateTimeKind.Local).AddTicks(376), new DateTime(2024, 7, 29, 1, 3, 33, 478, DateTimeKind.Local).AddTicks(375) });

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "FlightNumber",
                keyValue: "MF123",
                columns: new[] { "ArrivalTime", "DepartureTime" },
                values: new object[] { new DateTime(2024, 7, 29, 0, 3, 33, 478, DateTimeKind.Local).AddTicks(369), new DateTime(2024, 7, 28, 21, 3, 33, 478, DateTimeKind.Local).AddTicks(347) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "FlightNumber",
                keyValue: "FF100",
                columns: new[] { "ArrivalTime", "DepartureTime" },
                values: new object[] { new DateTime(2024, 7, 25, 17, 23, 29, 886, DateTimeKind.Local).AddTicks(511), new DateTime(2024, 7, 25, 13, 23, 29, 886, DateTimeKind.Local).AddTicks(511) });

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "FlightNumber",
                keyValue: "MD101",
                columns: new[] { "ArrivalTime", "DepartureTime" },
                values: new object[] { new DateTime(2024, 7, 26, 5, 23, 29, 886, DateTimeKind.Local).AddTicks(513), new DateTime(2024, 7, 25, 17, 23, 29, 886, DateTimeKind.Local).AddTicks(513) });

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "FlightNumber",
                keyValue: "MF100",
                columns: new[] { "ArrivalTime", "DepartureTime" },
                values: new object[] { new DateTime(2024, 7, 26, 0, 23, 29, 886, DateTimeKind.Local).AddTicks(509), new DateTime(2024, 7, 25, 19, 23, 29, 886, DateTimeKind.Local).AddTicks(509) });

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "FlightNumber",
                keyValue: "MF123",
                columns: new[] { "ArrivalTime", "DepartureTime" },
                values: new object[] { new DateTime(2024, 7, 25, 18, 23, 29, 886, DateTimeKind.Local).AddTicks(505), new DateTime(2024, 7, 25, 15, 23, 29, 886, DateTimeKind.Local).AddTicks(474) });
        }
    }
}
