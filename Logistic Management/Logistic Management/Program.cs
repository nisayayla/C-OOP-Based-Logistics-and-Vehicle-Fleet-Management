using projem;
using projem.Models;
using System.Text.Json;

// 1. Program başlarken kayıtlı verileri yükle
List<Hesap> hesaps = VeriServisi.HesaplariYukle();
List<NakliyeArac> aracs = VeriServisi.AraclariYukle();

Hesap secilenHesap = null!;
bool calisiyor = true;

#region Hesap Yönetim Metotları

void HesapOlusturma()
{
    string tus;
    string hesapn;
    do
    {
        bool aynihesap;
        bool sayivarmi;
        do
        {
            aynihesap = false;
            do
            {
                sayivarmi = false;
                Console.Write("Hesap Adi Giriniz = ");
                hesapn = Console.ReadLine()!.Trim();
                Console.WriteLine();
                sayivarmi = hesapn.Any(char.IsDigit);
                if (sayivarmi)
                {
                    Console.WriteLine("Metin içinde sayı barındırıyor. Lütfen tekrar deneyiniz!\n");
                }
            } while (sayivarmi);

            for (int k = 0; k < hesaps.Count; k++)
            {
                if (hesaps[k].Hesapprop.Equals(hesapn, StringComparison.OrdinalIgnoreCase))
                {
                    aynihesap = true;
                    Console.WriteLine("Bu isimde hesap zaten mevcut. Lütfen başka bir isim giriniz!\n");
                    break;
                }
            }

        } while (aynihesap);

        hesaps.Add(new Hesap(0, hesapn));
        VeriServisi.VerileriKaydet(hesaps, aracs);

        Console.WriteLine("\nYeni Hesap Başarıyla Oluşturuldu! (Toplam Hesap: " + hesaps.Count + ")\n");
        Console.WriteLine("Yeni Hesap Icin -> 0");
        Console.WriteLine("Ileri -> 1\n");
        tus = Console.ReadKey(true).KeyChar.ToString();

    } while (tus == "0");

    HesapSecimi();
}

void HesapSecimi()
{
    if (hesaps.Count == 0)
    {
        HesapOlusturma();
        return;
    }

    Console.Clear();
    Console.WriteLine("Devam Etmek Istedigin Hesabi Sec...\n");
    for (int i = 0; i < hesaps.Count; i++)
    {
        Console.WriteLine((i + 1) + " - " + hesaps[i].Hesapprop + "\n");
    }

    Console.Write("Seçilecek Hesap Adı: ");
    string arananIsim = Console.ReadLine()!.Trim();

    if (int.TryParse(arananIsim, out _))
    {
        Console.WriteLine("[UYARI] Sayı girdiniz! Lütfen hesap adını metin olarak giriniz.");
        GeriDon();
        return;
    }

    secilenHesap = null!;
    for (int j = 0; j < hesaps.Count; j++)
    {
        if (hesaps[j].Hesapprop.Equals(arananIsim, StringComparison.OrdinalIgnoreCase))
        {
            secilenHesap = hesaps[j];
            break;
        }
    }

    if (secilenHesap == null)
    {
        Console.WriteLine("Belirtilen isimde bir hesap bulunamadı!");
        GeriDon();
    }
}

#endregion

// Program ilk açıldığında aktif hesabı belirle
if (hesaps.Count == 0)
{
    HesapOlusturma();
}
else
{
    HesapSecimi();
}

#region Ana Döngü
while (calisiyor)
{
    Console.Clear();
    Console.WriteLine("------------ KARADENIZ LOJISTIK ------------\n");
    Console.WriteLine($"Aktif Hesap: {(secilenHesap != null ? secilenHesap.Hesapprop : "Seçilmedi")}\n");
    Console.WriteLine("Hesap Islemleri -> 1 ");
    Console.WriteLine("Arac Yuk Islemleri -> 2 ");
    Console.WriteLine("Hesap Olustur / Değiştir -> 3 ");
    Console.WriteLine("Çıkış Yap -> 0\n");
    Console.WriteLine("------------ KARADENIZ LOJISTIK ------------\n");

    ConsoleKeyInfo anasecim = Console.ReadKey(true);
    switch (anasecim.KeyChar)
    {
        case '1':
            if (secilenHesap == null)
            {
                HesapSecimi();
                if (secilenHesap == null) break;
            }
            HesapIslemleriMenusu(secilenHesap, hesaps, aracs);
            break;
        case '2':
            AracYukMenusu(aracs, hesaps);
            break;
        case '3':
            Console.Clear();
            Console.WriteLine("[1] Yeni Hesap Oluştur");
            Console.WriteLine("[2] Var Olan Hesaba Geç");
            ConsoleKeyInfo sec = Console.ReadKey(true);
            if (sec.KeyChar == '1') HesapOlusturma();
            else if (sec.KeyChar == '2') HesapSecimi();
            break;
        case '0':
            VeriServisi.VerileriKaydet(hesaps, aracs);
            calisiyor = false;
            break;
    }
}
#endregion

#region Menuler
static void HesapIslemleriMenusu(Hesap secilenHesap, List<Hesap> hesaps, List<NakliyeArac> aracs)
{
    bool hesapMenuCalisiyor = true;

    while (hesapMenuCalisiyor)
    {
        Console.Clear();
        Console.WriteLine("------------ KARADENIZ LOJISTIK ------------\n");
        Console.WriteLine("Para Yatır -> 1 ");
        Console.WriteLine("Havale -> 2 ");
        Console.WriteLine("Bakiye -> 3");
        Console.WriteLine("Ana Menüye Dön -> 0\n");
        Console.WriteLine("------------ KARADENIZ LOJISTIK ------------\n");

        ConsoleKeyInfo secim = Console.ReadKey(true);
        if (secim.KeyChar == '1')
        {
            Console.WriteLine("Yatırmak Istediginiz Para Miktarini Giriniz...\n");
            if (int.TryParse(Console.ReadLine(), out int miktar) && miktar > 0)
            {
                secilenHesap.ParaYatir(miktar);
                VeriServisi.VerileriKaydet(hesaps, aracs);
                Console.WriteLine("\nPara Yatırıldı!");
            }
            else
            {
                Console.WriteLine("\nGeçersiz bir miktar girdiniz!");
            }
            GeriDon();
        }
        else if (secim.KeyChar == '2')
        {
            Console.Write("Havale Yapılacak Hesap Adı: ");
            string aliciIsim = Console.ReadLine()!.Trim();
            Hesap aliciHesap = null!;

            for (int j = 0; j < hesaps.Count; j++)
            {
                if (hesaps[j].Hesapprop.Equals(aliciIsim, StringComparison.OrdinalIgnoreCase))
                {
                    aliciHesap = hesaps[j];
                    break;
                }
            }

            if (aliciHesap != null)
            {
                Console.Write("Para Miktarini Giriniz = ");
                if (int.TryParse(Console.ReadLine(), out int hpara) && hpara > 0)
                {
                    secilenHesap.Havale(aliciHesap, hpara);
                    VeriServisi.VerileriKaydet(hesaps, aracs);
                }
                else
                {
                    Console.WriteLine("Geçersiz bir tutar girdiniz!");
                }
            }
            else
            {
                Console.WriteLine("Bu isimde bir hesap bulunamadı!");
            }
            GeriDon();
        }
        else if (secim.KeyChar == '3')
        {
            Console.Write("Kasada Bulunan Para = ");
            secilenHesap.Kasa();
            GeriDon();
        }
        else if (secim.KeyChar == '0')
        {
            hesapMenuCalisiyor = false;
        }
    }
}

static void AracYukMenusu(List<NakliyeArac> aracs, List<Hesap> hesaps)
{
    bool aracAnaMenu = true;

    while (aracAnaMenu)
    {
        Console.Clear();
        Console.WriteLine("------------ ARAÇ VE YÜK YÖNETİMİ ------------\n");
        Console.WriteLine($"Sistemdeki Toplam Araç Sayısı: {aracs.Count}\n");
        Console.WriteLine("Yeni Araç Ekle             -> 1");
        Console.WriteLine("Var Olan Aracı Seç / Yönet -> 2\n");
        Console.WriteLine("Ana Menüye Dön             -> 0\n");
        Console.WriteLine("----------------------------------------------\n");

        ConsoleKeyInfo secim = Console.ReadKey(true);
        switch (secim.KeyChar)
        {
            case '1':
                YeniAracEkle(aracs, hesaps);
                break;

            case '2':
                if (aracs.Count == 0)
                {
                    Console.WriteLine("\nSistemde kayıtlı araç yok! Önce yeni araç eklemelisiniz.");
                    GeriDon();
                }
                else
                {
                    AracSecVeIslemYap(aracs, hesaps);
                }
                break;

            case '0':
                aracAnaMenu = false;
                break;
        }
    }
}

static void YeniAracEkle(List<NakliyeArac> aracs, List<Hesap> hesaps)
{
    int aracn;
    bool ayniarac;

    do
    {
        ayniarac = false;
        Console.Write("\nEklemek İstediğiniz Araç Numarasını Giriniz = ");
        while (!int.TryParse(Console.ReadLine(), out aracn))
        {
            Console.WriteLine("[UYARI] Sadece rakam girebilirsiniz!");
            Console.Write("Lütfen geçerli bir Araç Numarası Giriniz = ");
        }

        for (int k = 0; k < aracs.Count; k++)
        {
            if (aracs[k].AracNumarasi == aracn)
            {
                ayniarac = true;
                Console.WriteLine("\n[HATA] Bu numarada araç zaten kayıtlı! Farklı bir numara giriniz.\n");
                break;
            }
        }

    } while (ayniarac);

    Console.Clear();
    AracTurleri secilenTip = AracTipi();
    NakliyeArac yeniArac = new NakliyeArac(0, 0, aracn);
    yeniArac.AracTuru = secilenTip; // <-- Tür araca bağlandı
    aracs.Add(yeniArac);
    VeriServisi.VerileriKaydet(hesaps, aracs);
}

static void AracSecVeIslemYap(List<NakliyeArac> aracs, List<Hesap> hesaps)
{
    Console.Clear();
    Console.WriteLine("--- MEVCUT ARAÇLAR ---\n");
    for (int i = 0; i < aracs.Count; i++)
    {
        string turAdi = aracs[i].AracTuru != null ? $"({aracs[i].AracTuru.Tip})" : "(Tür Belirtilmedi)";
        Console.WriteLine($"{i + 1} - Araç No: {aracs[i].AracNumarasi} {turAdi}");
    }

    Console.Write("\nİşlem Yapmak İstediğiniz Araç Numarasını Giriniz: ");
    int arananarac;
    while (!int.TryParse(Console.ReadLine(), out arananarac))
    {
        Console.WriteLine("[UYARI] İçinde harf olan bir girdi yaptınız! Lütfen SADECE sayı giriniz.");
        Console.Write("Tekrar deneyin: ");
    }

    NakliyeArac secilenarac = null!;
    for (int j = 0; j < aracs.Count; j++)
    {
        if (aracs[j].AracNumarasi == arananarac)
        {
            secilenarac = aracs[j];
            break;
        }
    }

    if (secilenarac == null)
    {
        Console.WriteLine("\nBelirtilen numarada bir araç bulunamadı!");
        GeriDon();
        return;
    }

    bool islemMenusu = true;
    while (islemMenusu)
    {
        Console.Clear();
        Console.WriteLine($"------------ ARAÇ NO: {secilenarac.AracNumarasi} ------------\n");
        Console.WriteLine("Araç Durumu        -> 1");
        Console.WriteLine("Yük Ekle           -> 2");
        Console.WriteLine("Transfer           -> 3");
        Console.WriteLine("Araç Kimliği/Detay -> 4\n");
        Console.WriteLine("Önceki Menüye Dön  -> 0\n");
        Console.WriteLine("-----------------------------------------\n");

        ConsoleKeyInfo secim = Console.ReadKey(true);
        if (secim.KeyChar == '1')
        {
            secilenarac.AracDurum();
            GeriDon();
        }
        else if (secim.KeyChar == '2')
        {
            Console.Write("Yük Miktarını Giriniz = ");
            if (int.TryParse(Console.ReadLine(), out int miktar) && miktar > 0)
            {
                int[] eklenecekPaketler = new int[miktar];

                for (int i = 0; i < miktar; i++)
                {
                    Console.Write((i + 1) + ". Paket Ağırlığı: ");
                    while (!int.TryParse(Console.ReadLine(), out eklenecekPaketler[i]))
                    {
                        Console.Write("Geçerli bir sayı giriniz: ");
                    }
                }

                secilenarac.YukEkle(eklenecekPaketler);
                VeriServisi.VerileriKaydet(hesaps, aracs);
            }
            else
            {
                Console.WriteLine("Geçersiz yük miktarı!");
            }
            GeriDon();
        }
        else if (secim.KeyChar == '3')
        {
            Console.WriteLine("Aracı Transfer Etmek İstediğiniz Konumu Seçin...\n\n");
            Console.WriteLine("1) İstanbul \n2) Kocaeli \n3) Trabzon \n4) İzmir \n");
            string sehir = Console.ReadLine() ?? "";
            secilenarac.AracTransfer(sehir);
            VeriServisi.VerileriKaydet(hesaps, aracs);
            GeriDon();
        }
        else if (secim.KeyChar == '4')
        {
            Console.Clear();
            if (secilenarac.AracTuru != null)
            {
                secilenarac.AracTuru.AracKimligi();
            }
            else
            {
                Console.WriteLine("Bu araca ait tip ve kimlik bilgisi bulunmamaktadır.");
            }
            GeriDon();
        }
        else if (secim.KeyChar == '0')
        {
            islemMenusu = false;
        }
    }
}

static AracTurleri AracTipi()
{
    Console.Clear();
    Console.WriteLine("Kullanacağınız araç tipini seçiniz:\n");
    Console.WriteLine("1) Kamyon (3 Akslı)");
    Console.WriteLine("2) Kırkayak Kamyon (4 Akslı)");
    Console.WriteLine("3) Tır\n");

    ConsoleKeyInfo sec = Console.ReadKey(true);

    Console.Write("Aracın markasını giriniz: ");
    string marka = Console.ReadLine()?.Trim() ?? "";

    Console.Write("Aracın modelini giriniz: ");
    string model = Console.ReadLine()?.Trim() ?? "";

    Console.Write("Yük taşıma kapasitesini giriniz (kg): ");
    int kapasite;
    while (!int.TryParse(Console.ReadLine(), out kapasite) || kapasite <= 0)
    {
        Console.Write("[UYARI] Lütfen geçerli bir kapasite sayısı giriniz: ");
    }

    switch (sec.KeyChar)
    {
        case '1':
            return new Kamyon(marka, model, kapasite);

        case '2':
            return new Kirkayak(marka, model, kapasite);

        case '3':
            return new Tir(marka, model, kapasite);

        default:
            return new AracTurleri(marka, model, "Standart Araç", kapasite);
    }
}

static void GeriDon()
{
    Console.WriteLine("\nÖnceki menüye dönmek için [ 0 ] tuşuna basınız...");
    while (Console.ReadKey(true).KeyChar != '0') { }
}

#endregion

#region Veri Kayıt Servisi
public static class VeriServisi
{
    private static readonly string HesaplarDosyasi = "hesaplar.json";
    private static readonly string AraclarDosyasi = "araclar.json";
    private static readonly JsonSerializerOptions JsonAyar = new JsonSerializerOptions { WriteIndented = true };

    public static void VerileriKaydet(List<Hesap> hesaps, List<NakliyeArac> aracs)
    {
        try
        {
            string hesapJson = JsonSerializer.Serialize(hesaps, JsonAyar);
            File.WriteAllText(HesaplarDosyasi, hesapJson);

            string aracJson = JsonSerializer.Serialize(aracs, JsonAyar);
            File.WriteAllText(AraclarDosyasi, aracJson);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Kayıt hatası: {ex.Message}");
        }
    }

    public static List<Hesap> HesaplariYukle()
    {
        try
        {
            if (!File.Exists(HesaplarDosyasi)) return new List<Hesap>();
            string json = File.ReadAllText(HesaplarDosyasi);
            return JsonSerializer.Deserialize<List<Hesap>>(json) ?? new List<Hesap>();
        }
        catch
        {
            return new List<Hesap>();
        }
    }

    public static List<NakliyeArac> AraclariYukle()
    {
        try
        {
            if (!File.Exists(AraclarDosyasi)) return new List<NakliyeArac>();
            string json = File.ReadAllText(AraclarDosyasi);
            return JsonSerializer.Deserialize<List<NakliyeArac>>(json) ?? new List<NakliyeArac>();
        }
        catch
        {
            return new List<NakliyeArac>();
        }
    }
}
#endregion