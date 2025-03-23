using MaasBordroProgrami.AbstractClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaasBordroProgrami.Classes
{
    internal class Yonetici : Personel
    {
        public Yonetici()
        {
            Pozisyon = nameof(Yonetici);
        }

        public double Bonus { get; set; }

        public override void MaasHesapla()
        {
            if (SaatlikUcret < 500)
            {
                throw new Exception("Yönetici saatlik ücreti 500 tl den küçük olamaz.");
            }
            else
            {
                Maas = SaatlikUcret * CalismaSaati + Bonus;
            }
        }
    }
}
