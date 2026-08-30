using System;
using System.Collections.Generic;
using System.Text;

namespace projem
{
    public class Hesap
    {
        public int bakiye { get; set; }
        public string hesapisim;
        public Hesap() { }
        public Hesap(int x, string hesapn)
        {
            this.bakiye = 0;
            bakiye = x;
            hesapisim = hesapn;
            Hesapprop = hesapn;
        }
        public void ParaYatir(int x)
        {
            bakiye += x;
        }
        public void Havale(Hesap h, int para)
        {
            if (this.bakiye >= para) // Yeterli bakiye var mı kontrolü
            {
                this.bakiye -= para;         // Gönderenin bakiyesinden düş
                h.bakiye += para;   // Alıcının bakiyesine ekle
                Console.WriteLine(h.Hesapprop + " Adli Hesaba "+ para + " TL havale başarıyla gerçekleştirildi.");
            }
            else
            {
                Console.WriteLine("Yetersiz bakiye! Havale gerçekleştirilemedi.");
            }
        }
        public void Kasa()
        {
            if (bakiye <= 0) 
            {
                Console.WriteLine("Hesabinizda Para Bulunmamaktadir !");
            }
            else
                Console.WriteLine(bakiye + ".- TL");
        }
        public string Hesapprop
        {
            get; set;
        } = string.Empty;
    }
    
}
