using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class userImagePropAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "BookingId", "BookingDate", "CustomerName", "Email", "NumberOfCustomers", "Phone", "Status" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mustafa Çilekçi", "mcilekci@gmail.com", 4, "0543 123 1122", 0 },
                    { 2, new DateTime(2024, 6, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Naz Farklı", "nazfarkli@gmail.com", 2, "0555 123 1144", 1 },
                    { 3, new DateTime(2024, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Altan Kemal Özden", "altankemal@gmail.com", 5, "0507 123 5533", 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "BookingId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "BookingId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "BookingId",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "AspNetUsers");
        }
    }
}
