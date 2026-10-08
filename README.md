🚗 Rent A Car Web API

Bu proje, temel bir Araç Kiralama (Rent A Car) sisteminin arka plan (backend) servislerini sağlamak amacıyla geliştirilmiş bir ASP.NET Core Web API projesidir. Eski bir Rent A Car projesinin modernize edilerek dışa açık API uç noktaları (endpoints) haline getirilmiş halidir.

🚀 Teknolojiler

Bu projede kullanılan temel teknolojiler ve araçlar:

C# & .NET (ASP.NET Core Web API)

Entity Framework Core (ORM - Veritabanı işlemleri için) (Eğer kullanıyorsan)

Swagger / OpenAPI (API dokümantasyonu ve test süreçleri için)

Katmanlı Mimari prensiplerine uygun tasarım

🎯 Özellikler

Sistem şu anda aşağıdaki temel işlemleri destekleyecek altyapıya sahiptir:

Araç Yönetimi: Yeni araç ekleme, güncelleme, silme ve listeleme (CRUD).

Marka ve Durum Yönetimi: Araçlara ait marka ve durum bilgilerinin yönetimi.

Müşteri ve Kullanıcı İşlemleri: Sistemdeki müşterilerin kayıt altına alınması.

Kiralama (Rental) İşlemleri: Araçların belirli tarih aralıklarında kiralanması, teslim alınması ve müsaitlik kontrolü.

🛠️ Kurulum ve Çalıştırma

Projeyi kendi bilgisayarınızda çalıştırmak için aşağıdaki adımları izleyebilirsiniz:

Projeyi Klonlayın:

git clone https://github.com/Em1rkanK1raz/RentACarWebAPI.git


Gerekli SDK'yı İndirin:
Bilgisayarınızda .NET SDK'sının (projenizin kullandığı sürüme uygun olan) kurulu olduğundan emin olun.

Veritabanı Bağlantısını Ayarlayın:
appsettings.json dosyası içerisindeki ConnectionStrings bölümünü kendi yerel veritabanı (Örn: SQL Server, PostgreSQL) bilgilerinize göre güncelleyin.

Projeyi Derleyin ve Çalıştırın:
Visual Studio üzerinden RentACarWebAPI.sln dosyasını açıp F5 veya Ctrl+F5 ile projeyi başlatabilirsiniz.

Alternatif olarak CLI üzerinden:

cd RentACarWebAPI
dotnet restore
dotnet run


API'yi Test Edin:
Proje ayağa kalktıktan sonra tarayıcınızda açılan https://localhost:<port>/swagger adresinden Swagger UI üzerinden API uç noktalarını inceleyebilir ve test edebilirsiniz.

🤝 Katkıda Bulunma

Bu proje geliştirilmeye açıktır. Katkıda bulunmak isterseniz bir Pull Request oluşturabilir veya bir Issue açabilirsiniz.
