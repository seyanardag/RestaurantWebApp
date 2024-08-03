# NOT
Projeyi çalıştırdığınızda "HttpRequestException: Hedef makine etkin olarak reddettiğinden bağlantı kurulamadı. (localhost:44346)" hatası alırsanız lütfen WebApi ve WebUI katmanlarını ayrı ayrı IIS Express moduna çekiniz. Daha sonra projeyi "Multiple starup projects" modunda WebApi ve WebUI katmanlarının ikisini beraber ayağa kaldırarak çalıştırabilirsiniz.
# RestaurantWebApp
Projemiz, restoranların yönetim süreçlerini kolaylaştırmak ve müşteri deneyimini geliştirmek amacıyla tasarlanmıştır.

Projeye ait ekran görüntüleri bu  sayfanın sonunda yer almaktadır.

Projede kullanılan teknolojiler;

-C#

-AspNet Core 8.0

-n-Tier Architecture

-Repository Design Pattern

-Asp.Net Core Api

-Swagger

-SignalR

-Entity Framework Core - LinQ

-EF Core - Identity

-DTO

-Code-First

-MsSQL

-İlişkili Tablolar

-Html, Css, Bootstrap

-JavaScript

-JQuery

-AJAX

-SweetAlert

-moment.JS (bildirim tarih formatları)

-Yandex SMTP ile Mail gönderimi

-Real-Time İstatistik

-Google Charts

-Basket-Sepet işlemleri

-Real-Time Bildirim

-ViewComponent

-PartialView


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

![2](https://github.com/user-attachments/assets/cc2fd463-4e2f-4fac-a496-c218ccdf4576)
![3](https://github.com/user-attachments/assets/621411bd-5e15-467d-aa70-5350f6176212)
![4](https://github.com/user-attachments/assets/6918ffdf-8de4-4b40-8d01-0589b9951100)
![1](https://github.com/user-attachments/assets/13378304-c9c5-4cd1-bae4-5da0f7de1f20)
![5](https://github.com/user-attachments/assets/0d4d4d6f-459b-4c73-bd3a-2be456aa8b62)
![6](https://github.com/user-attachments/assets/0a2752ed-e7ab-4fb8-8e8b-b07dad8b37cb)
![7](https://github.com/user-attachments/assets/38ef9a6b-45cc-4795-afb3-441a99002761)
![8](https://github.com/user-attachments/assets/fed0df9f-cd74-4ddf-b696-33ee55793030)
![9](https://github.com/user-attachments/assets/5a13fffb-f26d-4fab-9833-b724734fbafd)
![10](https://github.com/user-attachments/assets/fec3c9a9-47b7-4243-98d5-f5620344f4cb)
![12](https://github.com/user-attachments/assets/f763b31e-f6d3-4547-bf83-a6773983a82e)
![13](https://github.com/user-attachments/assets/8497b8e0-e85b-49e7-aebf-3aaeb3440655)
![11](https://github.com/user-attachments/assets/1dc550e3-d0a2-44b5-9bf3-b1bc02a9e6e7)
![14](https://github.com/user-attachments/assets/7ee4d809-c1c5-4489-8a8e-5113fffb3ff6)
![15](https://github.com/user-attachments/assets/944238e0-511b-4e26-adbd-fd07d3abbc11)


