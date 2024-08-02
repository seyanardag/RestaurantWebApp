using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class discountedProductIsActivePropAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isActive",
                table: "DiscountedProducts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "DiscountedProducts",
                keyColumn: "DiscountedProductId",
                keyValue: 1,
                column: "isActive",
                value: false);

            migrationBuilder.UpdateData(
                table: "DiscountedProducts",
                keyColumn: "DiscountedProductId",
                keyValue: 2,
                column: "isActive",
                value: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isActive",
                table: "DiscountedProducts");
        }
    }
}
