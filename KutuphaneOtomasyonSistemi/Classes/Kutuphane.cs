using KutuphaneOtomasyonSistemi.AbstractClasses;
using KutuphaneOtomasyonSistemi.Enums;
using KutuphaneOtomasyonSistemi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KutuphaneOtomasyonSistemi.Classes
{
    internal class Kutuphane
    {
        public int KutuphaneId { get; set; }
        public string KutuphaneAd { get; set; }
        public List<Kitap> kitaplar = new List<Kitap>();
        public List<Uye> uyeler = new List<Uye>();
        public List<string> Kitaplar()
        {
            List<string> list = new();
            foreach (var kitap in kitaplar)
            {
                list.Add(kitap.ToString());
            }
            return list;
        }        
        public List<string> Uyeler()
        {
            List<string> list = new();
            foreach (var uye in uyeler)
            {
                list.Add(uye.ToString());
            }
            return list;
        }
        public Uye UyeBul(int id)
        {
            foreach (var uye in uyeler)
            {
                if (uye.UyeNo == id)
                {
                    return uye;
                }
            }
            return null;
        }
        public Kitap KitapBul(string ad)
        {
            foreach (var kitap in kitaplar)
            {
                if (kitap.KitapAdi == ad)
                {
                    return kitap;
                }
            }
            return null;
        }
        public string OduncVer(int uyeNo, string kitapAdi)
        {
            Uye uye = UyeBul(uyeNo);
            Kitap kitap = KitapBul(kitapAdi);

            if (uye != null && kitap != null)
            {
                if (kitap.Durum == Durum.OduncAlinabilir)
                {
                    uye.oduncAlinanKitaplar.Add(kitap);
                    kitap.Durum = Durum.Oduncte;
                    return "";
                }
                else if (kitap.Durum == Durum.Oduncte)
                {
                    return "Kitap, bir başka üye tarafından ödünç alınmışitır. Başka zaman deneyiniz.";
                }
                else if (kitap.Durum == Durum.MevcutDegil)
                {
                    return "Malesef bu kitap kütüphanemizde mevcut değil.";
                }
                else
                {
                    return "Geçerli bir kitap adı giriniz.";
                }
            }
            else
            {
                return "Üye veya kitap bulunamadı.";
            }
        }
        public string IadeAl(int uyeNo, string kitapAdi)
        {
            Uye uye = UyeBul(uyeNo);
            Kitap kitap = KitapBul(kitapAdi);

            if (uye != null && kitap != null)
            {
                if (uye.oduncAlinanKitaplar.Contains(kitap))
                {
                    uye.oduncAlinanKitaplar.Remove(kitap);
                    kitap.Durum = Durum.OduncAlinabilir;
                    return "";
                }
                else
                {
                    return "Bu kitap ödünç alınan kitap listesinde bulunmuyor.";
                }
            }
            else
            {
                return "Üye veya kitap bulunumadı.";
            }
        }
        public string KitapListesi()
        {
            string list = "";
            foreach (var kitap in kitaplar)
            {
                list += kitap.ToString() + "\n";
            }
            return list;
        }
        public void UyeleriEkle(List<Uye> yeniUyeler)
        {
            foreach (var uye in yeniUyeler)
            {
                uyeler.Add(uye);
            }
        }
        public void KitaplariEkle(List<Kitap> yeniKitaplar)
        {
            foreach (var kitap in yeniKitaplar)
            {
                kitaplar.Add(kitap);
            }
        }
    }
}
