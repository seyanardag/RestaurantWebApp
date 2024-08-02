using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class datasAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Abouts",
                columns: new[] { "AboutId", "Description", "ImgUrl", "Title" },
                values: new object[] { 1, "About sayfası için description", "test", "Restorantımıza hoşgeldiniz..." });

            migrationBuilder.InsertData(
                table: "Categorys",
                columns: new[] { "CategoryId", "CategoryName", "Status" },
                values: new object[,]
                {
                    { 1, "Hamburger", true },
                    { 2, "Makarna", true },
                    { 3, "İçecek", true },
                    { 4, "Salata", true },
                    { 5, "Sos", true },
                    { 6, "Pizza", true }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderId", "Description", "OrderDate", "TableNumber", "TotalPrice" },
                values: new object[,]
                {
                    { 1, "Salon 01 için order", new DateTime(2024, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Salon 01", 0m },
                    { 2, "Salon 02 için order", new DateTime(2024, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Salon 02", 0m },
                    { 3, "Salon 03 için order", new DateTime(2024, 6, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Salon 03", 0m },
                    { 4, "Bahçe 01 için order", new DateTime(2024, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bahçe 01", 0m }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "Description", "ImgUrl", "Price", "ProductName", "ProductStatus" },
                values: new object[,]
                {
                    { 1, 2, "Spagetti lezzeti", "test", 60m, "Spagetti", true },
                    { 2, 3, "Türk markası  kola tercihimiz", "test", 15m, "Cola Turka", true },
                    { 3, 3, "Doğa su", "test", 2m, "Su", true },
                    { 4, 4, "Akdeniz lezzetlerinin buluştuğu salata", "test", 12m, "Akdeniz Salatası", true },
                    { 5, 6, "Nefis 5 farklı çeşit peynirle donanmış pizza", "test", 85m, "Peynirli Pizza", true },
                    { 6, 6, "Her lezzet dilimin ucunda olsun diyenlere", "test", 80m, "Karışık Pizza", true },
                    { 7, 6, "Sucuk ve pizzanın muhteşem tadına bayılacaksınız", "test", 90m, "Sucuklu Pizza", true },
                    { 8, 1, "Doyuracak bir hamburger isteyenlere", "test", 70m, "Whooper Menü", true },
                    { 9, 1, "Ben birazcık fazla mı yesem diyenlere", "test", 100m, "Double Hamburger", true },
                    { 10, 1, "Ben doyamam büyük sar abi diyenlere", "test", 120m, "Triple Hamburger", true }
                });

            migrationBuilder.InsertData(
                table: "OrderDetails",
                columns: new[] { "OrderDetailId", "OrderId", "ProductCount", "ProductId", "ProductPrice", "TotalPrice" },
                values: new object[,]
                {
                    { 1, 1, 2, 1, 5m, 10m },
                    { 2, 1, 1, 2, 7m, 7m },
                    { 3, 2, 3, 4, 12m, 36m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Abouts",
                keyColumn: "AboutId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categorys",
                keyColumn: "CategoryId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "OrderDetails",
                keyColumn: "OrderDetailId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "OrderDetails",
                keyColumn: "OrderDetailId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "OrderDetails",
                keyColumn: "OrderDetailId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Categorys",
                keyColumn: "CategoryId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categorys",
                keyColumn: "CategoryId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categorys",
                keyColumn: "CategoryId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categorys",
                keyColumn: "CategoryId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categorys",
                keyColumn: "CategoryId",
                keyValue: 4);
        }
    }
}
