using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class restTableStatusUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "RestaurantTables",
                keyColumn: "RestaurantTableId",
                keyValue: 9,
                column: "Status",
                value: true);

            migrationBuilder.UpdateData(
                table: "RestaurantTables",
                keyColumn: "RestaurantTableId",
                keyValue: 10,
                column: "Status",
                value: true);

            migrationBuilder.UpdateData(
                table: "RestaurantTables",
                keyColumn: "RestaurantTableId",
                keyValue: 12,
                column: "Status",
                value: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "RestaurantTables",
                keyColumn: "RestaurantTableId",
                keyValue: 9,
                column: "Status",
                value: false);

            migrationBuilder.UpdateData(
                table: "RestaurantTables",
                keyColumn: "RestaurantTableId",
                keyValue: 10,
                column: "Status",
                value: false);

            migrationBuilder.UpdateData(
                table: "RestaurantTables",
                keyColumn: "RestaurantTableId",
                keyValue: 12,
                column: "Status",
                value: false);
        }
    }
}
