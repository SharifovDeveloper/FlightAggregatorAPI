using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FlightAggregatorAPI.Migrations
{
    /// <inheritdoc />
    public partial class updated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Flights",
                columns: new[] { "FlightNumber", "Airline", "ArrivalTime", "DepartureTime", "Price", "Stops" },
                values: new object[,]
                {
                    { "FF100", "Boing777", new DateTime(2024, 7, 25, 16, 54, 17, 51, DateTimeKind.Local).AddTicks(4444), new DateTime(2024, 7, 25, 12, 54, 17, 51, DateTimeKind.Local).AddTicks(4443), 150m, 0 },
                    { "MD101", "FlightPop", new DateTime(2024, 7, 26, 4, 54, 17, 51, DateTimeKind.Local).AddTicks(4447), new DateTime(2024, 7, 25, 16, 54, 17, 51, DateTimeKind.Local).AddTicks(4446), 500m, 3 },
                    { "MF100", "AirBus", new DateTime(2024, 7, 25, 23, 54, 17, 51, DateTimeKind.Local).AddTicks(4440), new DateTime(2024, 7, 25, 18, 54, 17, 51, DateTimeKind.Local).AddTicks(4439), 300m, 1 },
                    { "MF123", "MockAirline1", new DateTime(2024, 7, 25, 17, 54, 17, 51, DateTimeKind.Local).AddTicks(4429), new DateTime(2024, 7, 25, 14, 54, 17, 51, DateTimeKind.Local).AddTicks(4381), 100m, 0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "FlightNumber",
                keyValue: "FF100");

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "FlightNumber",
                keyValue: "MD101");

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "FlightNumber",
                keyValue: "MF100");

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "FlightNumber",
                keyValue: "MF123");
        }
    }
}
