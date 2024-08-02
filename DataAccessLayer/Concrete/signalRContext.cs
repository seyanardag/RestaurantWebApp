using EntityLayer.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class signalRContext :IdentityDbContext<CustomUser, CustomRole, int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=(localdb)\\MSSQLLocalDB; database=RestaurantDb; Integrated security=true");
        }

        public DbSet<About> Abouts { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Category> Categorys { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<DiscountedProduct> DiscountedProducts { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<FooterInfo> FooterInfos { get; set; }
        public DbSet<OpenHour> OpenHours { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<MoneyBox> MoneyBoxes { get; set; }
        public DbSet<RestaurantTable> RestaurantTables { get; set; }

        public DbSet<Basket> Baskets { get; set; }

        public DbSet<Notification> Notifications { get; set; }

        public DbSet<ContactFormMessage> ContactFormMessages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<About>().HasData(
               new About() { AboutId = 1, Description = "Lezzet yolculuğunu unutulmaz kılan bir mola arıyorsanız, doğru adrestesiniz. Restoranımız, deneyimli şeflerimizin elinden çıkan benzersiz lezzetlerle dolu bir gastronomi deneyimi sunuyor. Her bir tabak, özenle seçilmiş malzemelerle hazırlanırken, zengin tatlar ve estetik sunumlarla buluşuyor. Misafirperverliğimiz ve kaliteli hizmet anlayışımızla, her ziyaretinizi özel kılmak için buradayız.", Title = "Restorantımıza hoşgeldiniz...", ImgUrl = "/images/aboutimages/about-img.png" }
               );

            modelBuilder.Entity<Booking>().HasData(
                new Booking { BookingId = 1, CustomerName = "Mustafa Çilekçi", Phone = "0543 123 1122", Email = "mcilekci@gmail.com", NumberOfCustomers = 4, BookingDate = new DateTime(2024, 5, 25), Status=BookingStatus.PENDING },
                new Booking { BookingId = 2, CustomerName = "Naz Farklı", Phone = "0555 123 1144", Email = "nazfarkli@gmail.com", NumberOfCustomers = 2, BookingDate = new DateTime(2024, 6, 28) , Status = BookingStatus.CANCELED},
                new Booking { BookingId = 3, CustomerName = "Altan Kemal Özden", Phone = "0507 123 5533", Email = "altankemal@gmail.com", NumberOfCustomers = 5, BookingDate = new DateTime(2024, 7, 15), Status = BookingStatus.APPROVED }
                );


            modelBuilder.Entity<Category>().HasData(
                new Category() { CategoryId = 1, CategoryName = "Hamburger", Status = true },
                new Category() { CategoryId = 2, CategoryName = "Makarna", Status = true },
                new Category() { CategoryId = 3, CategoryName = "İçecek", Status = true },
                new Category() { CategoryId = 4, CategoryName = "Salata", Status = true },
                new Category() { CategoryId = 5, CategoryName = "Balık", Status = true },
                new Category() { CategoryId = 6, CategoryName = "Pizza", Status = true }
            );

            modelBuilder.Entity<Contact>().HasData(
                new Contact { ContactId = 1, Location = "Konya", Email = "sigranlr@gmail.com", Phone = "0543 789 01 23" }
                );


            modelBuilder.Entity<DiscountedProduct>().HasData(
                new DiscountedProduct { DiscountedProductId = 1, Title = "Tadımıza Tat Katalım", DiscountRate = 20, ImgUrl = "/images/discountedproductsimages/o1.jpg" },
                new DiscountedProduct { DiscountedProductId = 2, Title = "Haftanın Lezzeti", DiscountRate = 15, ImgUrl = "/images/discountedproductsimages/o2.jpg" }
                );

            modelBuilder.Entity<Feature>().HasData(
                new Feature { FeatureId = 1, Title = "Deneyimli Şeflerden Oluşan Mutfak Ekibi", Text = "Restoranımızın mutfağında çalışan şeflerimiz, lezzetin sınırlarını zorlayan yaratıcı tarifleriyle tanınıyor. Her biri alanında uzmanlaşmış olan şeflerimiz, en taze ve yerel malzemeleri kullanarak unutulmaz tatlar sunuyor." },
                new Feature { FeatureId = 2, Title = "Şık ve Şehir Manzaralı Atmosfer", Text = "Misafirlerimize modern ve zarif bir atmosferde hizmet veriyoruz. Restoranımızın sunduğu şehir manzarası eşliğinde, keyifli bir yemek deneyimi yaşayabilirsiniz. Her detayı özenle tasarlanmış dekorasyonumuz, konforunuz için özel olarak düşünüldü." },
                new Feature { FeatureId = 3, Title = "Sürdürülebilirlik ve Yerel Ürünler", Text = "Çevre dostu bir yaklaşımla hareket ediyoruz ve sürdürülebilirlik ilkelerine önem veriyoruz. Menümüzde yer alan ürünlerin büyük çoğunluğu yerel tedarikçilerden temin edilirken, doğal ve organik ürünleri tercih ediyoruz. Bu sayede hem sağlığınıza hem de çevreye katkıda bulunuyoruz." }
                );

            modelBuilder.Entity<FooterInfo>().HasData(
                new FooterInfo { Id = 1, Title = "Lezzeti Yaşayın", Description = "Restoranımızda lezzet ve misafirperverlik buluşuyor. Modern ve şık atmosferimizde, yaratıcı şeflerimizin hazırladığı özenli yemeklerle unutulmaz bir deneyim yaşayın." }
                );


            modelBuilder.Entity<OpenHour>().HasData(
                new OpenHour { Id = 1, OpenDays = "Pazartesi-Cumartesi", OpeningHour = "09.00", ClosingHour = "21.30" }
            );


            modelBuilder.Entity<Product>().HasData(
                new Product() { ProductId = 1, CategoryId = 2, ProductName = "Spagetti", Price = 60, ProductStatus = true, Description = "Spagetti lezzeti", ImgUrl = "/images/productimages/f1.png" },
                new Product() { ProductId = 2, CategoryId = 3, ProductName = "Cola Turka", Price = 15, ProductStatus = true, Description = "Türk markası  kola tercihimiz", ImgUrl = "/images/productimages/f2.png" },
                new Product() { ProductId = 3, CategoryId = 3, ProductName = "Su", Price = 2, ProductStatus = true, Description = "Doğa su", ImgUrl = "/images/productimages/f3.png" },
                new Product() { ProductId = 4, CategoryId = 4, ProductName = "Akdeniz Salatası", Price = 12, ProductStatus = true, Description = "Akdeniz lezzetlerinin buluştuğu salata", ImgUrl = "/images/productimages/f4.png" },
                new Product() { ProductId = 5, CategoryId = 6, ProductName = "Peynirli Pizza", Price = 85, ProductStatus = true, Description = "Nefis 5 farklı çeşit peynirle donanmış pizza", ImgUrl = "/images/productimages/f5.png" },
                new Product() { ProductId = 6, CategoryId = 6, ProductName = "Karışık Pizza", Price = 80, ProductStatus = true, Description = "Her lezzet dilimin ucunda olsun diyenlere", ImgUrl = "/images/productimages/f6.png" },
                new Product() { ProductId = 7, CategoryId = 6, ProductName = "Sucuklu Pizza", Price = 90, ProductStatus = true, Description = "Sucuk ve pizzanın muhteşem tadına bayılacaksınız", ImgUrl = "/images/productimages/f7.png" },
                new Product() { ProductId = 8, CategoryId = 1, ProductName = "Whooper Menü", Price = 70, ProductStatus = true, Description = "Doyuracak bir hamburger isteyenlere", ImgUrl = "/images/productimages/f8.png" },
                new Product() { ProductId = 9, CategoryId = 1, ProductName = "Double Hamburger", Price = 100, ProductStatus = true, Description = "Ben birazcık fazla mı yesem diyenlere", ImgUrl = "/images/productimages/f9.png" },
                new Product() { ProductId = 10, CategoryId = 1, ProductName = "Triple Hamburger", Price = 120, ProductStatus = true, Description = "Ben doyamam büyük sar abi diyenlere", ImgUrl = "/images/productimages/f9.png" },
                new Product() { ProductId = 11, CategoryId = 5, ProductName = "Somon", Price = 100, ProductStatus = true, Description = "Enfes mangalda balık lezzeti damağınızı şenlendirecek", ImgUrl = "/images/productimages/f2.png" }
                );

            modelBuilder.Entity<SocialMedia>().HasData(
                new SocialMedia { SocialMediaId = 1, Platform = "facebook", siteUrl = "www.facebook.com", Icon = "fa fa-facebook", IsActive=true},
                new SocialMedia { SocialMediaId = 2, Platform = "twitter", siteUrl = "www.twitter.com", Icon = "fa fa-twitter", IsActive = true },
                new SocialMedia { SocialMediaId = 3, Platform = "linkedin", siteUrl = "www.linkedin.com", Icon = "fa fa-linkedin", IsActive = true },
                new SocialMedia { SocialMediaId = 4, Platform = "instagram", siteUrl = "www.instagram.com", Icon = "fa fa-instagram", IsActive = true },
                new SocialMedia { SocialMediaId = 5, Platform = "pinterest", siteUrl = "www.pinterest.com", Icon = "fa fa-pinterest", IsActive = true },
                new SocialMedia { SocialMediaId = 6, Platform = "youtube", siteUrl = "www.youtube.com", Icon = "fa fa-youtube", IsActive = true },
                new SocialMedia { SocialMediaId = 7, Platform = "reddit", siteUrl = "www.reddit.com", Icon = "fa fa-reddit", IsActive = true },
                new SocialMedia { SocialMediaId = 8, Platform = "telegram", siteUrl = "www.telegram.com", Icon = "fa fa-telegram", IsActive = true },
                new SocialMedia { SocialMediaId = 9, Platform = "whatsapp", siteUrl = "www.whatsapp.com", Icon = "fa fa-whatsapp", IsActive = true },
                new SocialMedia { SocialMediaId = 10, Platform = "snapchat", siteUrl = "www.snapchat.com", Icon = "fa fa-snapchat", IsActive = true }
                );


            modelBuilder.Entity<Testimonial>().HasData(
                new Testimonial { TestimonialId = 1, WriterName = "Ayşe", Title = "Harika Atmosfer", Comment = "Restoranınızın atmosferi gerçekten büyüleyici! Yemekler harikaydı, özellikle deniz ürünleri çok taze ve lezzetliydi. Servis hızlı ve personel çok ilgiliydi. Tekrar gelmek için sabırsızlanıyorum.", ImgUrl = "/images/clientimages/client1.jpg", Status = true },
                new Testimonial { TestimonialId = 2, WriterName = "Mehmet", Title = "Mükemmel Hizmet", Comment = "Geçen hafta burada ailemle birlikte akşam yemeği yedik ve çok memnun kaldık. Yemeklerin lezzeti harikaydı, özellikle şefin önerdiği ana yemek beni çok güzeldi. Hizmet kalitesi ve personelin güleryüzü ise takdire şayan. Kesinlikle tekrar geleceğiz.", ImgUrl = "/images/clientimages/client2.jpg", Status = true },
                new Testimonial { TestimonialId = 3, WriterName = "Fatma", Title = "Muhteşem Manzara", Comment = "Restoranınızın sunduğu manzara gerçekten nefes kesici! Özellikle akşamüstü saatlerinde burada oturmak büyük keyif. Yemeklerin lezzeti de çok başarılıydı. Çalışanlarınızın ilgisi ve servis hızı da memnuniyet vericiydi. Herkese tavsiye ederim.", ImgUrl = "/images/clientimages/client1.jpg", Status = true },
                new Testimonial { TestimonialId = 4, WriterName = "Ali", Title = "Özel Bir Deneyim", Comment = "Arkadaşlarımı buraya getirdim ve hepsi çok memnun kaldı. Özellikle tadı damağımızda kalan tatlılar harikaydı. Restoranınızın ambiansı da çok hoştu, sıcak bir ortam sağlıyorsunuz. Teşekkürler!", ImgUrl = "/images/clientimages/client2.jpg", Status = true },
                new Testimonial { TestimonialId = 5, WriterName = "Zeynep", Title = "İlham Verici Yemekler", Comment = "Burada yediğimiz yemekler gerçekten ilham vericiydi. Yaratıcı sunumlar ve lezzetli tatlar bizi etkiledi. Servis çok profesyonel ve sıcak bir karşılama aldık. Herkese öneririm!", ImgUrl = "/images/clientimages/client1.jpg", Status = true }
                );

            modelBuilder.Entity<Order>().HasData(
                new Order() { OrderId = 1, TableNumber = "Salon 01", Description = "Hesap Kapatıldı", OrderDate = Convert.ToDateTime("05-06-2024"), TotalPrice = 0 },
                new Order() { OrderId = 2, TableNumber = "Salon 02", Description = "Hesap Kapatıldı", OrderDate = Convert.ToDateTime("06-06-2024"), TotalPrice = 0 },
                new Order() { OrderId = 3, TableNumber = "Salon 03", Description = "Müşteri Masada", OrderDate = Convert.ToDateTime("07-06-2024"), TotalPrice = 0 },
                new Order() { OrderId = 4, TableNumber = "Bahçe 01", Description = "Müşteri Masada", OrderDate = Convert.ToDateTime("08-06-2024"), TotalPrice = 0 }
                );

            modelBuilder.Entity<OrderDetail>().HasData(
                new OrderDetail() { OrderDetailId = 1, OrderId = 1, ProductId = 1, ProductCount = 2, ProductPrice = 5, TotalPrice = 10 },
                new OrderDetail() { OrderDetailId = 2, OrderId = 1, ProductId = 2, ProductCount = 1, ProductPrice = 7, TotalPrice = 7 },
                new OrderDetail() { OrderDetailId = 3, OrderId = 2, ProductId = 4, ProductCount = 3, ProductPrice = 12, TotalPrice = 36 }

                );


            modelBuilder.Entity<MoneyBox>().HasData(
                new MoneyBox { MoneyBoxId=1, TotalAmount=100}
                );

            modelBuilder.Entity<RestaurantTable>().HasData(
                new RestaurantTable { RestaurantTableId = 1, TableName = "Masa 1", Status = false },
                new RestaurantTable { RestaurantTableId = 2, TableName = "Masa 2", Status = false },
                new RestaurantTable { RestaurantTableId = 3, TableName = "Masa 3", Status = false },
                new RestaurantTable { RestaurantTableId = 4, TableName = "Masa 4", Status = false },
                new RestaurantTable { RestaurantTableId = 5, TableName = "Masa 5", Status = false },
                new RestaurantTable { RestaurantTableId = 6, TableName = "Masa 6", Status = false },
                new RestaurantTable { RestaurantTableId = 7, TableName = "Bahçe 1", Status = false },
                new RestaurantTable { RestaurantTableId = 8, TableName = "Bahçe 2", Status = false },
                new RestaurantTable { RestaurantTableId = 9, TableName = "Bahçe 3", Status = false },
                new RestaurantTable { RestaurantTableId = 10, TableName = "Bahçe 4", Status = false },
                new RestaurantTable { RestaurantTableId = 11, TableName = "Bahçe 5", Status = false },
                new RestaurantTable { RestaurantTableId = 12, TableName = "Bahçe 6", Status = false },
                new RestaurantTable { RestaurantTableId = 13, TableName = "Teras 1", Status = false },
                new RestaurantTable { RestaurantTableId = 14, TableName = "Teras 2", Status = false },
                new RestaurantTable { RestaurantTableId = 15, TableName = "Teras 3", Status = false },
                new RestaurantTable { RestaurantTableId = 16, TableName = "Teras 4", Status = false }
                );



        }

    }
}
