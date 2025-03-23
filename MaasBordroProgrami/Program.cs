using MaasBordroProgrami.AbstractClasses;
using MaasBordroProgrami.Classes;
using MaasBordroProgrami.Enums;
using MaasBordroProgrami.FileService;
using MaasBordroProgrami.PersonelService;
using Newtonsoft.Json;
using System.Reflection.Metadata;

Sirket sirket = new Sirket();
PersonelIslemleri personelislemleri = new(sirket, "PersonelBilgi.json");

List<Personel> personeller = new List<Personel>();
personeller.Add(new Yonetici() { PersonelId = 1, PersonelAd = "Tuğçe", PersonelSoyad = "Torun" });
personeller.Add(new Yonetici() { PersonelId = 2, PersonelAd = "Talha", PersonelSoyad = "Torun" });
personeller.Add(new Memur() { PersonelId = 3, PersonelAd = "Servet", PersonelSoyad = "Toker", Derece = Derece.Sef });
personeller.Add(new Memur() { PersonelId = 4, PersonelAd = "Eymen", PersonelSoyad = "Toker", Derece = Derece.Uzman });
personeller.Add(new Memur() { PersonelId = 5, PersonelAd = "Zeynep", PersonelSoyad = "Toker Köksal", Derece = Derece.Sef });


string json = "";

foreach (var personel in personeller)
{
    personelislemleri.PersonelEkle(personel);
}

personelislemleri.PersonelleriKaydet();

void DosyadakiPersonellereMaasGir(string dosyaYolu)
{
    if (!File.Exists(dosyaYolu))
    {
        throw new Exception("Dosya bulunamadı.");
    }

    string jsonIcerik = File.ReadAllText(dosyaYolu);

    List<Personel> personeller = JsonConvert.DeserializeObject<List<Personel>>(jsonIcerik, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto });

    foreach (var personel in personeller)
    {
        Console.WriteLine(personel.ToString());
        Console.WriteLine("Personelin maaş bilgisi için bilgileri giriniz : ");
        personel.MaasBordro.Donem = DateTime.Now;
        personel.MaasBordro.PersonelIsmi = personel.PersonelAd;
        Console.WriteLine("Çalışma saati giriniz : ");
        personel.CalismaSaati = int.Parse(Console.ReadLine());
        personel.MaasBordro.CalismaSaati = personel.CalismaSaati;

        if (personel is Yonetici yonetici)
        {
            Console.WriteLine("Saatlik ücret giriniz : ");
            yonetici.SaatlikUcret = double.Parse(Console.ReadLine());
            Console.WriteLine("Bonus giriniz : ");
            yonetici.Bonus = double.Parse(Console.ReadLine());
            yonetici.MaasBordro.AnaOdeme = yonetici.CalismaSaati * yonetici.SaatlikUcret;
            yonetici.MaasBordro.MesaiYaDaBonus = yonetici.Bonus;
            yonetici.MaasBordro.ToplamOdeme = yonetici.MaasBordro.AnaOdeme + yonetici.Bonus;
        }

        personel.MaasHesapla();

        if (personel is Memur memur)
        {
            memur.MaasBordro.AnaOdeme = memur.CalismaSaati * memur.SaatlikUcret;
            memur.MaasBordro.MesaiYaDaBonus = memur.Mesai;
            memur.MaasBordro.ToplamOdeme = memur.Maas;
        }

        Console.WriteLine("Personelin maaşı : " + personel.Maas);

        PersonelMaasBilgileriniKaydet(personel);
    }
}

void PersonelMaasBilgileriniKaydet(Personel personel)
{
    if (personel == null)
    {
        throw new Exception("Personel bilgisi boş olamaz.");
    }

    string klasorAdi = $"{personel.PersonelAd}_{personel.PersonelSoyad}";
    Directory.CreateDirectory(klasorAdi);

    string dosyaAdi = Path.Combine(klasorAdi, $"{personel.PersonelAd}_{personel.PersonelSoyad}_MaasBilgisi.json");

    string json = JsonConvert.SerializeObject(personel.MaasBordro, Formatting.Indented);
    File.WriteAllText(dosyaAdi, json);
}

DosyadakiPersonellereMaasGir("PersonelBilgi.json");


Console.WriteLine();

