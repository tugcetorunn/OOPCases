using KutuphaneOtomasyonSistemi.AbstractClasses;
using KutuphaneOtomasyonSistemi.Classes;
using KutuphaneOtomasyonSistemi.Enums;

List<Uye> uyeler = new List<Uye>();
uyeler.AddRange( new[] {
    new Uye() { UyeNo = 1, Ad = "Tuğçe", Soyad = "Torun", KayitTarihi = DateTime.Now },
    new Uye() { UyeNo = 2, Ad = "Talha", Soyad = "Torun", KayitTarihi = DateTime.Now },
    new Uye() { UyeNo = 3, Ad = "Eymen", Soyad = "Toker", KayitTarihi = DateTime.Now },
    new Uye() { UyeNo = 4, Ad = "Zeynep", Soyad = "Köksal", KayitTarihi = DateTime.Now },
    new Uye() { UyeNo = 5, Ad = "Servet", Soyad = "Toker", KayitTarihi = DateTime.Now }
});

List<Kitap> kitaplar = new List<Kitap>();
kitaplar.Add(new KitapRoman() { KitapId = 1, KitapAdi = "Beyaz Zambaklar Ülkesinde", Yazar = "Gregory Petrov", Baslik = "Atatürk’ün Tavsiye Ettiği Kitap", Durum = Durum.OduncAlinabilir, ISBN = "123456", YayinYili = 2025 });
kitaplar.Add(new KitapRoman() { KitapId = 2, KitapAdi = "Yaşamak", Yazar = "Yu Hua", Baslik = "Modern Klasik", Durum = Durum.OduncAlinabilir, ISBN = "123457", YayinYili = 2024 });
kitaplar.Add(new KitapBilim() { KitapId = 3, KitapAdi = "Zihnimi Aç", Yazar = "Barış Muslu", Baslik = "Kişisel Gelişim", Durum = Durum.OduncAlinabilir, ISBN = "123458", YayinYili = 2025 });
kitaplar.Add(new KitapRoman() { KitapId = 4, KitapAdi = "Satranç", Yazar = "Stefan Zweig", Baslik = "", Durum = Durum.OduncAlinabilir, ISBN = "123459", YayinYili = 2025 });
kitaplar.Add(new KitapRoman() { KitapId = 5, KitapAdi = "Bir Aşk Masalı", Yazar = "Ahmet Ümit", Baslik = "Aşk", Durum = Durum.OduncAlinabilir, ISBN = "123460", YayinYili = 2025 });
kitaplar.Add(new KitapTarih() { KitapId = 6, KitapAdi = "Türklerin Tarihi", Yazar = "İlber Ortaylı", Baslik = "Türkiye", Durum = Durum.OduncAlinabilir, ISBN = "123461", YayinYili = 2025 });

Kutuphane kutuphane = new() { KutuphaneId = 123, KutuphaneAd = "Uyumayan Kütüphane" };

kutuphane.UyeleriEkle(uyeler);
kutuphane.KitaplariEkle(kitaplar);

Console.WriteLine(kutuphane.OduncVer(1, "Yaşamak"));
Console.WriteLine(kutuphane.OduncVer(1, "Satranç"));

Console.WriteLine(kutuphane.UyeBul(1).OduncAlinanKitaplar());

Console.WriteLine(kutuphane.OduncVer(1, "Yaşamak"));
Console.WriteLine(kutuphane.IadeAl(1, "Yaşamak"));


Console.WriteLine(kutuphane.UyeBul(1).OduncAlinanKitaplar());
Console.WriteLine();

