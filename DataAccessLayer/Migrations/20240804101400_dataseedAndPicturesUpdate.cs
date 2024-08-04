using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class dataseedAndPicturesUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Abouts",
                keyColumn: "AboutId",
                keyValue: 1,
                columns: new[] { "Description", "ImgUrl", "Title" },
                values: new object[] { "Büyüyen ve gelişen restoran zincirimiz sizlerin desteği ve profesyonel ekibimizin sayesinde yeni şubeler açmaya devam ediyor. İstanbul a yolunuz düşerse aynı lezzeti İstanbul şubemizde de yaşayın, yaşattırın...", "/images/aboutimages/about2.png", "Lezzet almanı mutluluk kaynağımız..." });

            migrationBuilder.InsertData(
                table: "Abouts",
                columns: new[] { "AboutId", "Description", "ImgUrl", "Title", "isSelected" },
                values: new object[] { 2, "Lezzet yolculuğunu unutulmaz kılan bir mola arıyorsanız, doğru adrestesiniz. Restoranımız, deneyimli şeflerimizin elinden çıkan benzersiz lezzetlerle dolu bir gastronomi deneyimi sunuyor. Her bir tabak, özenle seçilmiş malzemelerle hazırlanırken, zengin tatlar ve estetik sunumlarla buluşuyor. Misafirperverliğimiz ve kaliteli hizmet anlayışımızla, her ziyaretinizi özel kılmak için buradayız.", "/images/aboutimages/about-img.png", "Restorantımıza hoşgeldiniz...", true });

            migrationBuilder.InsertData(
                table: "Baskets",
                columns: new[] { "BasketId", "Count", "Price", "ProductId", "RestaurantTableId", "TotalPrice" },
                values: new object[,]
                {
                    { 1, 2, 2m, 3, 4, 4m },
                    { 2, 1, 85m, 5, 4, 85m },
                    { 3, 1, 120m, 10, 4, 120m },
                    { 4, 1, 15m, 2, 4, 15m }
                });

            migrationBuilder.InsertData(
                table: "Categorys",
                columns: new[] { "CategoryId", "CategoryName", "Status" },
                values: new object[,]
                {
                    { 7, "Kızartma", true },
                    { 8, "Vejeteryan", false }
                });

            migrationBuilder.InsertData(
                table: "ContactFormMessages",
                columns: new[] { "ContactFormMessageId", "Content", "Date", "IsRead", "Mail", "NameSurname", "Phone", "Title" },
                values: new object[,]
                {
                    { 1, "Merhaba, restoranınızı uzun zamandır duyuyorum ve ilk kez ziyaret etmek istiyorum. Menünüzde vejeteryan yemek göremedim, acaba özel olarak yaptığınız menüde bulunmaya bir vejeteryan yemeğiniz var mıydı?", new DateTime(2024, 7, 15, 23, 28, 5, 0, DateTimeKind.Unspecified), true, "mpekmez@yandex.com", "Mustafa Pekmez", "0554 454 55 66", "Vejeteryan menü var mı" },
                    { 2, "Merhaba, çocuk menünüz ve çocuk sandalyeniz var mıydı acaba?", new DateTime(2024, 1, 8, 5, 26, 43, 0, DateTimeKind.Unspecified), false, "handeyet@gmail.com", "Hande Yetkin", "0554 555 77 56", "Çocuk menüsü" }
                });

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "ContactId",
                keyValue: 1,
                column: "Email",
                value: "restorankonyasube@gmail.com");

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "ContactId", "Email", "Location", "Phone", "isSelected" },
                values: new object[,]
                {
                    { 2, "restoranizmirsube@gmail.com", "İzmir", "0543 555 66 77", false },
                    { 3, "restoranistanbulsube@gmail.com", "İstanbul", "0543 888 88 99", false }
                });

            migrationBuilder.UpdateData(
                table: "FooterInfos",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsActive",
                value: true);

            migrationBuilder.InsertData(
                table: "FooterInfos",
                columns: new[] { "Id", "Description", "IsActive", "Title" },
                values: new object[] { 2, "Tam bir lezzet fabrikası olan restoranımızdan sevdiklerinizin de faydalanması bizlerin de mutluluğu olur.", false, "Tadın, Tattırın" });

            migrationBuilder.InsertData(
                table: "Notifications",
                columns: new[] { "NotificationId", "Date", "Description", "IsRead", "Type" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 7, 12, 15, 30, 45, 0, DateTimeKind.Unspecified), "Toplantı", true, "primary" },
                    { 2, new DateTime(2024, 8, 4, 16, 52, 32, 0, DateTimeKind.Unspecified), "Prim Ödemeleri", true, "warning" },
                    { 3, new DateTime(2024, 8, 4, 13, 35, 5, 0, DateTimeKind.Unspecified), "Toplantı", false, "primary" },
                    { 4, new DateTime(2024, 8, 4, 14, 15, 45, 0, DateTimeKind.Unspecified), "Denetleme", true, "danger" }
                });

            migrationBuilder.UpdateData(
                table: "OpenHours",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsActive",
                value: true);

            migrationBuilder.InsertData(
                table: "OpenHours",
                columns: new[] { "Id", "ClosingHour", "IsActive", "OpenDays", "OpeningHour" },
                values: new object[] { 2, "22.00", false, "Her Gün", "09.00" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                column: "ImgUrl",
                value: "/images/productimages/spagetti.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2,
                column: "ImgUrl",
                value: "/images/productimages/colaturca.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3,
                columns: new[] { "Description", "ImgUrl" },
                values: new object[] { "Erikli 0,5l su", "/images/productimages/su.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4,
                column: "ImgUrl",
                value: "/images/productimages/akdenizSalatası.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 5,
                column: "ImgUrl",
                value: "/images/productimages/peynirliPizza.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 6,
                column: "ImgUrl",
                value: "/images/productimages/karışıkPizza.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 7,
                column: "ImgUrl",
                value: "/images/productimages/sucukluPizza.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 8,
                columns: new[] { "Description", "ImgUrl" },
                values: new object[] { "Doyuracak bir hamburger menü isteyenlere", "/images/productimages/wooperMenu.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 9,
                column: "ImgUrl",
                value: "/images/productimages/doubleHamburger.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 10,
                column: "ImgUrl",
                value: "/images/productimages/tripleHamburger.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 11,
                column: "ImgUrl",
                value: "/images/productimages/somon.png");

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "Description", "ImgUrl", "Price", "ProductName", "ProductStatus" },
                values: new object[,]
                {
                    { 12, 2, "Taze sebzelerle hazırlanan hafif makarnamız", "/images/productimages/pastaPrimavera.png", 220m, "Pasta Primavera", true },
                    { 13, 2, "Kıvrımlı ve spiral şeklindeki makarnamız.", "/images/productimages/Cavatappi.png", 220m, "Cavatappi", true },
                    { 16, 4, "Tapzate sebzelerle klasik ama leziz salatamı.", "/images/productimages/çobanSalata.png", 50m, "Çoban Salata", true }
                });

            migrationBuilder.UpdateData(
                table: "Testimonials",
                keyColumn: "TestimonialId",
                keyValue: 1,
                column: "ImgUrl",
                value: "/images/clientimages/k1.jpg");

            migrationBuilder.UpdateData(
                table: "Testimonials",
                keyColumn: "TestimonialId",
                keyValue: 2,
                column: "ImgUrl",
                value: "/images/clientimages/e1.jpg");

            migrationBuilder.UpdateData(
                table: "Testimonials",
                keyColumn: "TestimonialId",
                keyValue: 3,
                column: "ImgUrl",
                value: "/images/clientimages/k2.jpg");

            migrationBuilder.UpdateData(
                table: "Testimonials",
                keyColumn: "TestimonialId",
                keyValue: 4,
                column: "ImgUrl",
                value: "/images/clientimages/e2");

            migrationBuilder.UpdateData(
                table: "Testimonials",
                keyColumn: "TestimonialId",
                keyValue: 5,
                column: "ImgUrl",
                value: "/images/clientimages/k1.jpg");

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "Description", "ImgUrl", "Price", "ProductName", "ProductStatus" },
                values: new object[,]
                {
                    { 14, 7, "İnce dilimlenmiş veya jülyen kesilmiş leziz patateslerimiz", "/images/productimages/patatesKızartma.png", 50m, "Patates Kızartması", true },
                    { 15, 7, "Baharatlı ve lezzetli soğanlar halkalarımız.", "/images/productimages/soğanHalkası.png", 65m, "Soğan Halkası", true },
                    { 17, 7, "Üzerinde eritilmiş peynir ile tam bir harika.", "/images/productimages/mantar.png", 45m, "Kızarmış Mantar", true },
                    { 18, 8, "İnce bulgur, domates, salatalık, yeşillikler şöleni.", "/images/productimages/kısır.png", 85m, "Kısır", true },
                    { 19, 8, "Taze enginarlarımızın zeytinyağı, limon suyu, soğan ve baharatlarla dansı.", "/images/productimages/enginar.png", 110m, "Zeytinyağlı Enginar", true }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Abouts",
                keyColumn: "AboutId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Baskets",
                keyColumn: "BasketId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Baskets",
                keyColumn: "BasketId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Baskets",
                keyColumn: "BasketId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Baskets",
                keyColumn: "BasketId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ContactFormMessages",
                keyColumn: "ContactFormMessageId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ContactFormMessages",
                keyColumn: "ContactFormMessageId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "ContactId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "ContactId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "FooterInfos",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "NotificationId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "NotificationId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "NotificationId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "NotificationId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "OpenHours",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Categorys",
                keyColumn: "CategoryId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Categorys",
                keyColumn: "CategoryId",
                keyValue: 8);

            migrationBuilder.UpdateData(
                table: "Abouts",
                keyColumn: "AboutId",
                keyValue: 1,
                columns: new[] { "Description", "ImgUrl", "Title" },
                values: new object[] { "Lezzet yolculuğunu unutulmaz kılan bir mola arıyorsanız, doğru adrestesiniz. Restoranımız, deneyimli şeflerimizin elinden çıkan benzersiz lezzetlerle dolu bir gastronomi deneyimi sunuyor. Her bir tabak, özenle seçilmiş malzemelerle hazırlanırken, zengin tatlar ve estetik sunumlarla buluşuyor. Misafirperverliğimiz ve kaliteli hizmet anlayışımızla, her ziyaretinizi özel kılmak için buradayız.", "/images/aboutimages/about-img.png", "Restorantımıza hoşgeldiniz..." });

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "ContactId",
                keyValue: 1,
                column: "Email",
                value: "sigranlr@gmail.com");

            migrationBuilder.UpdateData(
                table: "FooterInfos",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsActive",
                value: false);

            migrationBuilder.UpdateData(
                table: "OpenHours",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsActive",
                value: false);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                column: "ImgUrl",
                value: "/images/productimages/f1.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2,
                column: "ImgUrl",
                value: "/images/productimages/f2.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3,
                columns: new[] { "Description", "ImgUrl" },
                values: new object[] { "Doğa su", "/images/productimages/f3.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4,
                column: "ImgUrl",
                value: "/images/productimages/f4.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 5,
                column: "ImgUrl",
                value: "/images/productimages/f5.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 6,
                column: "ImgUrl",
                value: "/images/productimages/f6.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 7,
                column: "ImgUrl",
                value: "/images/productimages/f7.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 8,
                columns: new[] { "Description", "ImgUrl" },
                values: new object[] { "Doyuracak bir hamburger isteyenlere", "/images/productimages/f8.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 9,
                column: "ImgUrl",
                value: "/images/productimages/f9.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 10,
                column: "ImgUrl",
                value: "/images/productimages/f9.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 11,
                column: "ImgUrl",
                value: "/images/productimages/f2.png");

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
    }
}
