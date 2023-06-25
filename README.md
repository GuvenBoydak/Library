#### *Projede kullanılan teknoloji ve kütüphaneler*
- **Clean Architecture** / **Ef Core**  / **PostgreSql** / **CQRS** / **MediatR** / **Fluent Validation** / **AutoMapper**  / **Generic Repository pattern** / **MVC UI**

 ## Projenin Kurulumu
 - Projeyi aşagıdaki adresden biligisayarınıza klonlayabilirsiniz
 ````
https://github.com/GuvenBoydak/Library.git
 ````
 - Proje’yi çalıştırmak için PostgreSql'in bilgisayarımızda yüklü ve çalışıyor olması gerekmektedir. Daha Sonra Presentation dosyası içerisinden Library.Api katmanındaki ``appsettings.json`` içerisindeki ``"ConnectionStrings": {
    "PostgresSql": "database adresiniz"
   }`` database adresiniz kısmını kendi database ayaralarınıza göre değiştirmelisiniz.

  - Projeyi çalıştırmak için Solution dosyası üzerinden Configure startup Project diyip daha sonra Multiple Start-Up projesi seçilerek Library.Api ve Library.MvcUi aynı anda işaretlenmesiniz.

# Library App

- __Register__ ve __Login__ olabiliyoruz. Default User ``Email : admin@admin.com  Password : 123456``
- __Profil__ kısmında Kullanıcının daha önce alldıgı kitaplar listelenmekte.
- __Ana Sayfa__ tıklandığında veya giriş yaptıktan sonra Kütüphanenın sahip oldugu kitaplar listeleniyor. Ödünç alınmış kitaplar ise alan kişi ve getirecegi tarih gösteriliyor.
- Bu bölümde __Kitap Ekle__ butonuyla Kütüphaneye yeni kitap ekleyebiliyoruz. Bu kısımda O kitaba ait yazarı __Yazar Ekle__ ve kategorisini de __Kategori Ekle__ butonlarına tıklayarak Ekleye biliyoruz.
- __Ödünç ver__ butonuyla kitaplari bir başka kullanıcılara alış ve veriş tarihini ve alan kullanıcıyı seçerek(Yoksa yeni bir kullanıcı kayıt etmeliyiz) ödünç veriyoruz.

# Kurallar
 **Register**  
- Kısmında FirstName ve LastName boş olamaz ve sadece harf girilebilir.
-  PhoneNumber boş olamaz ve sadece rakamm girilebir.
-  Email boş olamaz ve email formatında olmalı.
-  Password boş olamaz ve en az 6 en fazla 20 karakter olmalıdır.
 
**Login** 
-  Email boş olamaz ve email formatında olmalı.
-  Password boş olamaz ve en az 6 en fazla 20 karakter olmalıdır.

  **Ödünç ver**
  - Alınan tarih bügünden küçük olamaz.
  - Geri getirilecek tarih Alınan tarihden büyük olmalıdır.

   # Database Diagram
![Diagram](https://i.hizliresim.com/m3b6t8f.jpg)
