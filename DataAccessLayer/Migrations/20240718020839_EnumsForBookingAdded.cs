using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class EnumsForBookingAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "IsApproved",
                table: "Bookings");

            migrationBuilder.RenameColumn(
                name: "numberOfCustomers",
                table: "Bookings",
                newName: "NumberOfCustomers");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Bookings",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Bookings");

            migrationBuilder.RenameColumn(
                name: "NumberOfCustomers",
                table: "Bookings",
                newName: "numberOfCustomers");

            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "Bookings",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "BookingId", "BookingDate", "CustomerName", "Email", "IsApproved", "Phone", "numberOfCustomers" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mustafa Çilekçi", "mcilekci@gmail.com", false, "0543 123 1122", 4 },
                    { 2, new DateTime(2024, 6, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Naz Farklı", "nazfarkli@gmail.com", false, "0555 123 1144", 2 },
                    { 3, new DateTime(2024, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Altan Kemal Özden", "altankemal@gmail.com", false, "0507 123 5533", 5 }
                });
        }
    }
}
