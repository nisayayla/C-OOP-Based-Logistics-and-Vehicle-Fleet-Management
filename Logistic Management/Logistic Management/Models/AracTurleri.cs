using System;
using System.Text.Json.Serialization;

namespace projem.Models
{
    [JsonDerivedType(typeof(AracTurleri), typeDiscriminator: "base")]
    [JsonDerivedType(typeof(Kamyon), typeDiscriminator: "kamyon")]
    [JsonDerivedType(typeof(Kirkayak), typeDiscriminator: "kirkayak")]
    [JsonDerivedType(typeof(Tir), typeDiscriminator: "tir")]
    public class AracTurleri
    {
        public string Marka { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public string Tip { get; set; } = string.Empty;
        public int Kapasite { get; set; }

        // JSON serileştirme için boş constructor
        public AracTurleri() { }

        public AracTurleri(string marka, string model, string tip, int kapasite)
        {
            Marka = marka;
            Model = model;
            Tip = tip;
            Kapasite = kapasite;
        }

        public virtual void AracKimligi()
        {
            Console.WriteLine("Marka      : \t" + Marka);
            Console.WriteLine("Model      : \t" + Model);
            Console.WriteLine("Araç Tipi  : \t" + Tip);
            Console.WriteLine("Kapasite   : \t" + Kapasite + " KG");
        }

        public string Tipisim
        {
            get { return Tip; }
            set { Tip = value; }
        }
    }

    public class Kamyon : AracTurleri
    {
        public int AksSayisi { get; set; } = 3;

        public Kamyon() { }

        public Kamyon(string marka, string model, int kapasite)
            : base(marka, model, "Kamyon (3 Akslı)", kapasite)
        {
        }

        public void KapasiteDenetim()
        {
            if (Kapasite > 15000)
                Console.WriteLine("[UYARI] Bu taşıtın azami taşıma kapasitesi 15.000 KG'dir.");
        }

        public override void AracKimligi()
        {
            base.AracKimligi();
            Console.WriteLine("Aks Sayısı : \t" + AksSayisi);
        }
    }

    public class Kirkayak : AracTurleri
    {
        public int AksSayisi { get; set; } = 4;

        public Kirkayak() { }

        public Kirkayak(string marka, string model, int kapasite)
            : base(marka, model, "Kırkayak (4 Akslı)", kapasite)
        {
        }

        public void KapasiteDenetim()
        {
            if (Kapasite > 25000)
                Console.WriteLine("[UYARI] Bu taşıtın azami taşıma kapasitesi 25.000 KG'dir.");
        }

        public override void AracKimligi()
        {
            base.AracKimligi();
            Console.WriteLine("Aks Sayısı : \t" + AksSayisi);
        }
    }

    public class Tir : AracTurleri
    {
        public int AksSayisi { get; set; } = 5;

        public Tir() { }

        public Tir(string marka, string model, int kapasite)
            : base(marka, model, "Tır", kapasite)
        {
        }

        public void KapasiteDenetim()
        {
            if (Kapasite > 28000)
                Console.WriteLine("[UYARI] Bu taşıtın azami taşıma kapasitesi 28.000 KG'dir.");
        }

        public override void AracKimligi()
        {
            base.AracKimligi();
            Console.WriteLine("Aks Sayısı : \t" + AksSayisi);
        }
    }
}