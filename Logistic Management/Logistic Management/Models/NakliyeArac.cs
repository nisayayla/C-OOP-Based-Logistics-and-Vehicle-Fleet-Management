using System;
using System.Collections.Generic;
using System.Linq;
using projem.Models;

namespace projem
{
    public class NakliyeArac
    {
        // 1. JSON serileştiricinin kaydedip okuyabilmesi için public { get; set; } zorunludur:
        public int AracNumarasi { get; set; }
        public int Kapasite { get; set; }
        public int Doluluk { get; set; }
        public int Agirlik { get; set; }
        public string? Sehir { get; set; }
        public List<int> Yuk { get; set; } = new List<int>();

        // 2. JSON'dan geri okuma (Deserialize) yapabilmek için BOŞ Constructor zorunludur:
        public NakliyeArac()
        {
        }
        public AracTurleri? AracTuru { get; set; }
        // Program içinde kullandığın 3 parametreli Constructor:
        public NakliyeArac(int kapasite, int doluluk, int aracNumarasi, AracTurleri? aracTuru = null)
        {
            Kapasite = kapasite;
            Doluluk = doluluk;
            AracNumarasi = aracNumarasi;
        }

        public void YukEkle(int[] yenipakets)
        {
            if (yenipakets == null || yenipakets.Length == 0) return;

            for (int i = 0; i < yenipakets.Length; i++)
            {
                Yuk.Add(yenipakets[i]);
            }

            Doluluk = Yuk.Count;
            Agirlik = Yuk.Sum();
            Console.WriteLine("\nPaketler araca başarıyla yüklendi!");
        }

        public void AracTransfer(string sehir)
        {
            Sehir = sehir;
            Console.WriteLine("\n" + AracNumarasi + " Numaralı Araç " + sehir + " Konumuna Transfer Edildi.\n");
        }

        public void AracDurum()
        {
            Console.WriteLine("\n" + AracNumarasi + " Numarali Arac Bilgisi\n");
            Console.WriteLine("Yüklü Paket Sayısı : " + Yuk.Count + " Adet");
            Console.WriteLine("Toplam Yük Ağırlığı: " + Agirlik + " kg");

            if (!string.IsNullOrEmpty(Sehir))
            {
                Console.WriteLine("Araç Konumu        : " + Sehir + " Konumuna Transfer Edildi\n");
            }
            else
            {
                Console.WriteLine("Araç Konumu        : Merkez Garajda\n");
            }
        }
    }
}