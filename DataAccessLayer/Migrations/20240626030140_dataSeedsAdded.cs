using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class dataSeedsAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Abouts",
                keyColumn: "AboutId",
                keyValue: 1,
                column: "Description",
                value: "Lezzet yolculuğunu unutulmaz kılan bir mola arıyorsanız, doğru adrestesiniz. Restoranımız, deneyimli şeflerimizin elinden çıkan benzersiz lezzetlerle dolu bir gastronomi deneyimi sunuyor. Her bir tabak, özenle seçilmiş malzemelerle hazırlanırken, zengin tatlar ve estetik sunumlarla buluşuyor. Misafirperverliğimiz ve kaliteli hizmet anlayışımızla, her ziyaretinizi özel kılmak için buradayız.");

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "BookingId", "BookingDate", "CustomerName", "Email", "Phone", "numberOfCustomers" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mustafa Çilekçi", "mcilekci@gmail.com", "0543 123 1122", 4 },
                    { 2, new DateTime(2024, 6, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Naz Farklı", "nazfarkli@gmail.com", "0555 123 1144", 2 },
                    { 3, new DateTime(2024, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Altan Kemal Özden", "altankemal@gmail.com", "0507 123 5533", 5 }
                });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "ContactId", "Email", "Location", "Phone" },
                values: new object[] { 1, "sigranlr@gmail.com", "Konya", "0543 789 01 23" });

            migrationBuilder.InsertData(
                table: "DiscountedProducts",
                columns: new[] { "DiscountedProductId", "Description", "DiscountRate", "ImgUrl", "Title" },
                values: new object[,]
                {
                    { 1, "BOŞ", 20, "/images/discountedproductsimages/o1.jpg", "Tadımıza Tat Katalım" },
                    { 2, "BOŞ", 15, "/images/discountedproductsimages/o2.jpg", "Haftanın Lezzeti" }
                });

            migrationBuilder.InsertData(
                table: "Features",
                columns: new[] { "FeatureId", "Text", "Title" },
                values: new object[,]
                {
                    { 1, "Restoranımızın mutfağında çalışan şeflerimiz, lezzetin sınırlarını zorlayan yaratıcı tarifleriyle tanınıyor. Her biri alanında uzmanlaşmış olan şeflerimiz, en taze ve yerel malzemeleri kullanarak unutulmaz tatlar sunuyor.", "Deneyimli Şeflerden Oluşan Mutfak Ekibi" },
                    { 2, "Misafirlerimize modern ve zarif bir atmosferde hizmet veriyoruz. Restoranımızın sunduğu şehir manzarası eşliğinde, keyifli bir yemek deneyimi yaşayabilirsiniz. Her detayı özenle tasarlanmış dekorasyonumuz, konforunuz için özel olarak düşünüldü.", "Şık ve Şehir Manzaralı Atmosfer" },
                    { 3, "Çevre dostu bir yaklaşımla hareket ediyoruz ve sürdürülebilirlik ilkelerine önem veriyoruz. Menümüzde yer alan ürünlerin büyük çoğunluğu yerel tedarikçilerden temin edilirken, doğal ve organik ürünleri tercih ediyoruz. Bu sayede hem sağlığınıza hem de çevreye katkıda bulunuyoruz.", "Sürdürülebilirlik ve Yerel Ürünler" }
                });

            migrationBuilder.InsertData(
                table: "FooterInfos",
                columns: new[] { "Id", "Description", "Title" },
                values: new object[] { 1, "Restoranımızda lezzet ve misafirperverlik buluşuyor. Modern ve şık atmosferimizde, yaratıcı şeflerimizin hazırladığı özenli yemeklerle unutulmaz bir deneyim yaşayın.", "Lezzeti Yaşayın" });

            migrationBuilder.InsertData(
                table: "MoneyBoxes",
                columns: new[] { "MoneyBoxId", "TotalAmount" },
                values: new object[] { 1, 100m });

            migrationBuilder.InsertData(
                table: "OpenHours",
                columns: new[] { "Id", "ClosingHour", "OpenDays", "OpeningHour" },
                values: new object[] { 1, "21.30", "Pazartesi-Cumartesi", "09.00" });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 1,
                column: "Description",
                value: "Hesap Kapatıldı");

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 2,
                column: "Description",
                value: "Hesap Kapatıldı");

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 4,
                column: "Description",
                value: "Müşteri Masada");

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
                column: "ImgUrl",
                value: "/images/productimages/f3.png");

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
                column: "ImgUrl",
                value: "/images/productimages/f8.png");

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

            migrationBuilder.InsertData(
                table: "SocialMedias",
                columns: new[] { "SocialMediaId", "Icon", "Platform", "siteUrl" },
                values: new object[,]
                {
                    { 1, "facebook", "facebook", "www.facebook.com" },
                    { 2, "twitter", "twitter", "www.twitter.com" },
                    { 3, "linkedin", "linkedin", "www.linkedin.com" },
                    { 4, "instagram", "instagram", "www.instagram.com" },
                    { 5, "pinterest", "pinterest", "www.pinterest.com" }
                });

            migrationBuilder.InsertData(
                table: "Testimonials",
                columns: new[] { "TestimonialId", "Comment", "ImgUrl", "Status", "Title", "WriterName" },
                values: new object[,]
                {
                    { 1, "Restoranınızın atmosferi gerçekten büyüleyici! Yemekler harikaydı, özellikle deniz ürünleri çok taze ve lezzetliydi. Servis hızlı ve personel çok ilgiliydi. Tekrar gelmek için sabırsızlanıyorum.", "", true, "Harika Atmosfer", "Ayşe" },
                    { 2, "Geçen hafta burada ailemle birlikte akşam yemeği yedik ve çok memnun kaldık. Yemeklerin lezzeti harikaydı, özellikle şefin önerdiği ana yemek beni çok güzeldi. Hizmet kalitesi ve personelin güleryüzü ise takdire şayan. Kesinlikle tekrar geleceğiz.", "", true, "Mükemmel Hizmet", "Mehmet" },
                    { 3, "Restoranınızın sunduğu manzara gerçekten nefes kesici! Özellikle akşamüstü saatlerinde burada oturmak büyük keyif. Yemeklerin lezzeti de çok başarılıydı. Çalışanlarınızın ilgisi ve servis hızı da memnuniyet vericiydi. Herkese tavsiye ederim.", "", true, "Muhteşem Manzara", "Fatma" },
                    { 4, "Arkadaşlarımı buraya getirdim ve hepsi çok memnun kaldı. Özellikle tadı damağımızda kalan tatlılar harikaydı. Restoranınızın ambiansı da çok hoştu, sıcak bir ortam sağlıyorsunuz. Teşekkürler!", "", true, "Özel Bir Deneyim", "Ali" },
                    { 5, "Burada yediğimiz yemekler gerçekten ilham vericiydi. Yaratıcı sunumlar ve lezzetli tatlar bizi etkiledi. Servis çok profesyonel ve sıcak bir karşılama aldık. Herkese öneririm!", "", true, "İlham Verici Yemekler", "Zeynep" }
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

            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "ContactId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DiscountedProducts",
                keyColumn: "DiscountedProductId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DiscountedProducts",
                keyColumn: "DiscountedProductId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "FeatureId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "FeatureId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "FeatureId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "FooterInfos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MoneyBoxes",
                keyColumn: "MoneyBoxId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "OpenHours",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "SocialMedias",
                keyColumn: "SocialMediaId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "SocialMedias",
                keyColumn: "SocialMediaId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "SocialMedias",
                keyColumn: "SocialMediaId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "SocialMedias",
                keyColumn: "SocialMediaId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "SocialMedias",
                keyColumn: "SocialMediaId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Testimonials",
                keyColumn: "TestimonialId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Testimonials",
                keyColumn: "TestimonialId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Testimonials",
                keyColumn: "TestimonialId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Testimonials",
                keyColumn: "TestimonialId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Testimonials",
                keyColumn: "TestimonialId",
                keyValue: 5);

            migrationBuilder.UpdateData(
                table: "Abouts",
                keyColumn: "AboutId",
                keyValue: 1,
                column: "Description",
                value: "About sayfası için description");

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 1,
                column: "Description",
                value: "Müşteri Masada");

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 2,
                column: "Description",
                value: "Müşteri Masada");

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 4,
                column: "Description",
                value: "Hesap Kapatıldı");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                column: "ImgUrl",
                value: "test");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2,
                column: "ImgUrl",
                value: "test");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3,
                column: "ImgUrl",
                value: "test");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4,
                column: "ImgUrl",
                value: "test");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 5,
                column: "ImgUrl",
                value: "test");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 6,
                column: "ImgUrl",
                value: "test");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 7,
                column: "ImgUrl",
                value: "test");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 8,
                column: "ImgUrl",
                value: "test");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 9,
                column: "ImgUrl",
                value: "test");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 10,
                column: "ImgUrl",
                value: "test");
        }
    }
}
