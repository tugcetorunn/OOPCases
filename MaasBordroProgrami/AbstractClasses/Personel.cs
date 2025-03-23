using MaasBordroProgrami.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaasBordroProgrami.AbstractClasses
{
    internal abstract class Personel
    {
        public int PersonelId { get; set; }
        public string PersonelAd { get; set; }
        public string PersonelSoyad { get; set; }
        private string pozisyon { get; set; }
        public string Pozisyon {
            get 
            {
                return pozisyon;
            }
            set
            {
                pozisyon = value;
            }
        }
        public int CalismaSaati { get; set; }
        public double SaatlikUcret { get; set; }
        private double maas { get; set; }
        public double Maas
        {
            get
            {
                return maas;
            }
            set
            {
                maas = value;
            }
        }
        public MaasBordro MaasBordro { get; set; } = new MaasBordro();
        public abstract void MaasHesapla();
        public override string ToString()
        {
            return $"{PersonelId} - {PersonelAd} {PersonelSoyad} - {Pozisyon}";
        }
    }
}
