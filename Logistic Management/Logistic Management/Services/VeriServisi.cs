using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace projem
{
    internal class VeriServisi
    {
        private static readonly string HesaplarDosyasi = "hesaplar.json";
        private static readonly string AraclarDosyasi = "araclar.json";

        // JSON formatının okunabilir (girintili) kaydedilmesini sağlar
        private static readonly JsonSerializerOptions JsonAyar = new JsonSerializerOptions
        {
            WriteIndented = true
        };

        // Verileri Diske Kaydetme
        public static void VerileriKaydet(List<Hesap> hesaps, List<NakliyeArac> aracs)
        {
            string hesapJson = JsonSerializer.Serialize(hesaps, JsonAyar);
            File.WriteAllText(HesaplarDosyasi, hesapJson);

            string aracJson = JsonSerializer.Serialize(aracs, JsonAyar);
            File.WriteAllText(AraclarDosyasi, aracJson);
        }

        // Hesapları Dosyadan Okuma
        public static List<Hesap> HesaplariYukle()
        {
            if (!File.Exists(HesaplarDosyasi))
                return new List<Hesap>();

            string json = File.ReadAllText(HesaplarDosyasi);
            return JsonSerializer.Deserialize<List<Hesap>>(json) ?? new List<Hesap>();
        }

        // Araçları Dosyadan Okuma
        public static List<NakliyeArac> AraclariYukle()
        {
            if (!File.Exists(AraclarDosyasi))
                return new List<NakliyeArac>();

            string json = File.ReadAllText(AraclarDosyasi);
            return JsonSerializer.Deserialize<List<NakliyeArac>>(json) ?? new List<NakliyeArac>();
        }
    }
}

