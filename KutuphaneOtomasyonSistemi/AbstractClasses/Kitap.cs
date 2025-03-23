using KutuphaneOtomasyonSistemi.Enums;
using KutuphaneOtomasyonSistemi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KutuphaneOtomasyonSistemi.AbstractClasses
{
    internal abstract class Kitap : IDurum
    {
        public int KitapId { get; set; }
        public string KitapAdi { get; set; }
        public string Yazar { get; set; }
        public string ISBN { get; set; }
        public string Baslik { get; set; }
        public short YayinYili { get; set; }
        public Durum Durum { get; set; }

        public override string ToString()
        {
            return $"{KitapId} - {KitapAdi} - {Yazar} - {ISBN} - {Baslik} - {YayinYili}";
        }
    }
}
