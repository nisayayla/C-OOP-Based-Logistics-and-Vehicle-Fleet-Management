# C# OOP-Based Logistics and Vehicle Fleet Management
C# ortamında başlangıç düzeyinde geliştirilmiş; filo takibi,yük yönetimi, transfer operasyonları ve hesap bazlı bakiye/havale işlemlerini yöneten bir konsol lojistik simülasyonudur. Nesne Yönelimli Programlama (OOP) prensipleri ve JSON tabanlı veri kalıcılığı mimarisi üzerine inşa edilmiştir. 


* **Çoklu Hesap Yönetimi:** Yeni hesap oluşturma ve mevcut hesaplar arasında geçiş yapabilme.
* **Finansal İşlemler:** Bakiye sorgulama, hesaba para yatırma ve hesaplar arası güvenli bakiye transferi (Havale).


* **Kalıtım ve Polimorfizm:** `Kamyon`, `Kırkayak` ve `Tır` gibi farklı araç tiplerine özel kapasite, aks sayısı ve teknik kimlik yönetimi (`virtual` / `override`).
* **Dinamik Yükleme:** Paket bazlı ağırlık girişi, toplam yük ağırlığı ve araç doluluk hesabı (LINQ `Sum()`).
* **Lojistik & Transfer:** Araçları farklı şehirlere transfer etme ve anlık durum/konum raporlama.


* **JSON Serialization:** Hesap ve araç verilerinin JSON dosyalarında (`hesaplar.json`, `araclar.json`) yerel olarak kalıcı saklanması.
* **Defensive Coding:** Sayısal veri girişlerinde (`int.TryParse`) ve metin içi kontrollerde hatalı girdilere karşı tam savunma.

------------------------------------------------------------------------------------------------------------------------


This is a console-based logistics simulation developed at the beginner level in the C# environment that manages fleet tracking, cargo management, transfer operations, and account-based balance and transfer transactions. It is built on the principles of Object-Oriented Programming (OOP) and a JSON-based data persistence architecture.


* **Multi-Account Management:** Create new accounts and switch between existing accounts.
* **Financial Transactions:** Check balances, deposit funds into accounts, and securely transfer balances between accounts (wire transfers).


* **Inheritance and Polymorphism:** Capacity, axle count, and technical identification management specific to different vehicle types such as `Truck`, `Trailer`, and `Tractor-Trailer` (`virtual` / `override`).
* **Dynamic Loading:** Package-based weight entry, total load weight, and vehicle load factor calculation (LINQ `Sum()`).
* **Logistics & Transfer:** Transferring vehicles to different cities and real-time status/location reporting.


* **JSON Serialization:** Local persistent storage of account and vehicle data in JSON 

Translated with DeepL.com (free version)
