# RestaurantWebApp
-Projemiz, restoranların yönetim süreçlerini kolaylaştırmak ve müşteri deneyimini geliştirmek amacıyla tasarlanmıştır.
-Projede kullanılan teknolojiler;
	C#
	AspNet Core 8.0
	n-Tier Architecture
	Repository Design Pattern
	Asp.Net Core Api
	Swagger
	SignalR
	Entity Framework Core - LinQ
	EF Core - Identity
	DTO
	Code-First
	MsSQL
	İlişkili Tablolar
	Html, Css, Bootstrap
	JavaScript
	JQuery
	AJAX
	SweetAlert
	moment.JS (bildirim tarih formatları)
	Yandex SMTP ile Mail gönderimi
	Real-Time İstatistik
	Google Charts
	Basket-Sepet işlemleri
	Real-Time Bildirim
	ViewComponent
	PartialView


Uygulamanın Tanıtımı;
Önyüzde (vitrin) bizleri restoranın web uygulaması karşılıyor. Burada standart bir tanıtım web sitesinde bulunan bilgiler ve ürünler menüsü bulunmaktadır.
Admin paneli sayesinde ise web sitesine ait bütün bilgiler özelleştirilebilmektedir. Bu kapsamda;
•	Hakkımızda, iletişim bilgileri, çalışma saatleri, ürünler (menü), ürün kategorileri gibi vitrin tarafındaki bütün bilgiler için CRUD işlemleri yapılabilmektedir.
•	Ayrıca vitrine ait işlemler haricinde de masa işlemleri ve anlık masaların durumları, talep olarak gelen rezervasyonlara ait işlemler (onaylama/reddetme), yaklaşan rezervasyonların görülmesi, bildirim yayımlama, Yandex SMTP ile mail gönderimi gibi işlemler de admin yetkileri kapsamında yapılabilmektedir.
SignalR kütüphanesiyle; restorana ait özet istatistik verileri, rezervasyon durumları, masaların durumları ve bildirimler sayfa yenilemeye ihtiyaç olmadan anlık olarak izlenebilmektedir.
Ajax ile menüdeki ürünlerin sayfa yenilenmeden sepete eklenmesiyle kullanıcı deneyimi iyileştirilmiştir.
Admin paneli Identity kütüphanesi ile güvenlik altına alınmıştır.
Projede mimari olarak n-Tier architecture (n-katmanlı mimari) kullanılmıştır. Kullanılan 6 katman şu şekildedir;
-Entity Layer 
-Data Access Layer
-Dto Layer
-Business Layer
-WebApi
-WebUI

Projenin ilk yüklenmesi esnasında örnek veriler eklenerek DB Seed edilmiştir. 


