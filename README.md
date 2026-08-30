# C# OOP-Based Logistics and Vehicle Fleet Management
C# ortamında başlangıç düzeyinde geliştirilmiş; filo takibi,yük yönetimi, transfer operasyonları ve hesap bazlı bakiye/havale işlemlerini yöneten bir konsol lojistik simülasyonudur. Nesne Yönelimli Programlama (OOP) prensipleri ve JSON tabanlı veri kalıcılığı mimarisi üzerine inşa edilmiştir. 


* **Çoklu Hesap Yönetimi:** Yeni hesap oluşturma ve mevcut hesaplar arasında geçiş yapabilme.
* **Finansal İşlemler:** Bakiye sorgulama, hesaba para yatırma ve hesaplar arası güvenli bakiye transferi (Havale).


* **Kalıtım ve Polimorfizm:** `Kamyon`, `Kırkayak` ve `Tır` gibi farklı araç tiplerine özel kapasite, aks sayısı ve teknik kimlik yönetimi (`virtual` / `override`).
* **Dinamik Yükleme:** Paket bazlı ağırlık girişi, toplam yük ağırlığı ve araç doluluk hesabı (LINQ `Sum()`).
* **Lojistik & Transfer:** Araçları farklı şehirlere transfer etme ve anlık durum/konum raporlama.


* **JSON Serialization:** Hesap ve araç verilerinin JSON dosyalarında (`hesaplar.json`, `araclar.json`) yerel olarak kalıcı saklanması.
* **Defensive Coding:** Sayısal veri girişlerinde (`int.TryParse`) ve metin içi kontrollerde hatalı girdilere karşı tam savunma.
