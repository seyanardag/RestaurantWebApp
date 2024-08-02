using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class discountedProductPropDeleted : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "DiscountedProducts");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "DiscountedProducts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "DiscountedProducts",
                keyColumn: "DiscountedProductId",
                keyValue: 1,
                column: "Description",
                value: "BOŞ");

            migrationBuilder.UpdateData(
                table: "DiscountedProducts",
                keyColumn: "DiscountedProductId",
                keyValue: 2,
                column: "Description",
                value: "BOŞ");
        }
    }
}
