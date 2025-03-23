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
    internal class Uye : IUye
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public int UyeNo { get; set; }
        public DateTime KayitTarihi { get; set; }
        public List<Kitap> oduncAlinanKitaplar = new List<Kitap>();
        public List<string> Kitaplar()
        {
            List<string> kitaplar = new();
            foreach (var kitap in oduncAlinanKitaplar)
            {
                kitaplar.Add(kitap.ToString());
            }
            return kitaplar;
        }

        public string OduncAlinanKitaplar()
        {
            if (oduncAlinanKitaplar != null)
            {
                string list = "";
                foreach (var kitap in oduncAlinanKitaplar)
                {
                    list += kitap.ToString() + "\n";
                }

                return list;
            }
            else
            {
                return "Ödünç kitap listeniz boş.";
            }
        }
        public override string ToString()
        {
            return $"{UyeNo} - {Ad} {Soyad}";
        }
    }
}
