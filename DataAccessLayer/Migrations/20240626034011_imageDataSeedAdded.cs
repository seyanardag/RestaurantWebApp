using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class imageDataSeedAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Abouts",
                keyColumn: "AboutId",
                keyValue: 1,
                column: "ImgUrl",
                value: "/images/aboutimages/about-img.png");

            migrationBuilder.UpdateData(
                table: "Testimonials",
                keyColumn: "TestimonialId",
                keyValue: 1,
                column: "ImgUrl",
                value: "/images/clientimages/client1.jpg");

            migrationBuilder.UpdateData(
                table: "Testimonials",
                keyColumn: "TestimonialId",
                keyValue: 2,
                column: "ImgUrl",
                value: "/images/clientimages/client2.jpg");

            migrationBuilder.UpdateData(
                table: "Testimonials",
                keyColumn: "TestimonialId",
                keyValue: 3,
                column: "ImgUrl",
                value: "/images/clientimages/client1.jpg");

            migrationBuilder.UpdateData(
                table: "Testimonials",
                keyColumn: "TestimonialId",
                keyValue: 4,
                column: "ImgUrl",
                value: "/images/clientimages/client2.jpg");

            migrationBuilder.UpdateData(
                table: "Testimonials",
                keyColumn: "TestimonialId",
                keyValue: 5,
                column: "ImgUrl",
                value: "/images/clientimages/client1.jpg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Abouts",
                keyColumn: "AboutId",
                keyValue: 1,
                column: "ImgUrl",
                value: "test");

            migrationBuilder.UpdateData(
                table: "Testimonials",
                keyColumn: "TestimonialId",
                keyValue: 1,
                column: "ImgUrl",
                value: "");

            migrationBuilder.UpdateData(
                table: "Testimonials",
                keyColumn: "TestimonialId",
                keyValue: 2,
                column: "ImgUrl",
                value: "");

            migrationBuilder.UpdateData(
                table: "Testimonials",
                keyColumn: "TestimonialId",
                keyValue: 3,
                column: "ImgUrl",
                value: "");

            migrationBuilder.UpdateData(
                table: "Testimonials",
                keyColumn: "TestimonialId",
                keyValue: 4,
                column: "ImgUrl",
                value: "");

            migrationBuilder.UpdateData(
                table: "Testimonials",
                keyColumn: "TestimonialId",
                keyValue: 5,
                column: "ImgUrl",
                value: "");
        }
    }
}
