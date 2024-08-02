using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class SomonAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categorys",
                keyColumn: "CategoryId",
                keyValue: 5,
                column: "CategoryName",
                value: "Balık");

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "Description", "ImgUrl", "Price", "ProductName", "ProductStatus" },
                values: new object[] { 11, 5, "Enfes mangalda balık lezzeti damağınızı şenlendirecek", "/images/productimages/f2.png", 100m, "Somon", true });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 11);

            migrationBuilder.UpdateData(
                table: "Categorys",
                keyColumn: "CategoryId",
                keyValue: 5,
                column: "CategoryName",
                value: "Sos");
        }
    }
}
