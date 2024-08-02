using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class openHourIsActivePropAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "OpenHours",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "OpenHours",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsActive",
                value: false);

            migrationBuilder.UpdateData(
                table: "SocialMedias",
                keyColumn: "SocialMediaId",
                keyValue: 1,
                columns: new[] { "Icon", "IsActive" },
                values: new object[] { "fa fa-facebook", true });

            migrationBuilder.UpdateData(
                table: "SocialMedias",
                keyColumn: "SocialMediaId",
                keyValue: 2,
                columns: new[] { "Icon", "IsActive" },
                values: new object[] { "fa fa-twitter", true });

            migrationBuilder.UpdateData(
                table: "SocialMedias",
                keyColumn: "SocialMediaId",
                keyValue: 3,
                columns: new[] { "Icon", "IsActive" },
                values: new object[] { "fa fa-linkedin", true });

            migrationBuilder.UpdateData(
                table: "SocialMedias",
                keyColumn: "SocialMediaId",
                keyValue: 4,
                columns: new[] { "Icon", "IsActive" },
                values: new object[] { "fa fa-instagram", true });

            migrationBuilder.UpdateData(
                table: "SocialMedias",
                keyColumn: "SocialMediaId",
                keyValue: 5,
                columns: new[] { "Icon", "IsActive" },
                values: new object[] { "fa fa-pinterest", true });

            migrationBuilder.InsertData(
                table: "SocialMedias",
                columns: new[] { "SocialMediaId", "Icon", "IsActive", "Platform", "siteUrl" },
                values: new object[,]
                {
                    { 6, "fa fa-youtube", true, "youtube", "www.youtube.com" },
                    { 7, "fa fa-reddit", true, "reddit", "www.reddit.com" },
                    { 8, "fa fa-telegram", true, "telegram", "www.telegram.com" },
                    { 9, "fa fa-whatsapp", true, "whatsapp", "www.whatsapp.com" },
                    { 10, "fa fa-snapchat", true, "snapchat", "www.snapchat.com" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SocialMedias",
                keyColumn: "SocialMediaId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "SocialMedias",
                keyColumn: "SocialMediaId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "SocialMedias",
                keyColumn: "SocialMediaId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "SocialMedias",
                keyColumn: "SocialMediaId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "SocialMedias",
                keyColumn: "SocialMediaId",
                keyValue: 10);

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "OpenHours");

            migrationBuilder.UpdateData(
                table: "SocialMedias",
                keyColumn: "SocialMediaId",
                keyValue: 1,
                columns: new[] { "Icon", "IsActive" },
                values: new object[] { "facebook", false });

            migrationBuilder.UpdateData(
                table: "SocialMedias",
                keyColumn: "SocialMediaId",
                keyValue: 2,
                columns: new[] { "Icon", "IsActive" },
                values: new object[] { "twitter", false });

            migrationBuilder.UpdateData(
                table: "SocialMedias",
                keyColumn: "SocialMediaId",
                keyValue: 3,
                columns: new[] { "Icon", "IsActive" },
                values: new object[] { "linkedin", false });

            migrationBuilder.UpdateData(
                table: "SocialMedias",
                keyColumn: "SocialMediaId",
                keyValue: 4,
                columns: new[] { "Icon", "IsActive" },
                values: new object[] { "instagram", false });

            migrationBuilder.UpdateData(
                table: "SocialMedias",
                keyColumn: "SocialMediaId",
                keyValue: 5,
                columns: new[] { "Icon", "IsActive" },
                values: new object[] { "pinterest", false });
        }
    }
}
