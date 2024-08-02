using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class RestaurantTablesEntityandDatasAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RestaurantTables",
                columns: table => new
                {
                    RestaurantTableId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TableName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RestaurantTables", x => x.RestaurantTableId);
                });

            migrationBuilder.InsertData(
                table: "RestaurantTables",
                columns: new[] { "RestaurantTableId", "Status", "TableName" },
                values: new object[,]
                {
                    { 1, false, "Masa 1" },
                    { 2, false, "Masa 2" },
                    { 3, false, "Masa 3" },
                    { 4, false, "Masa 4" },
                    { 5, false, "Masa 5" },
                    { 6, false, "Masa 6" },
                    { 7, false, "Bahçe 1" },
                    { 8, false, "Bahçe 2" },
                    { 9, false, "Bahçe 3" },
                    { 10, false, "Bahçe 4" },
                    { 11, false, "Bahçe 5" },
                    { 12, false, "Bahçe 6" },
                    { 13, false, "Teras 1" },
                    { 14, false, "Teras 2" },
                    { 15, false, "Teras 3" },
                    { 16, false, "Teras 4" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RestaurantTables");
        }
    }
}
