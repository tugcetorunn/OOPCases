using MaasBordroProgrami.AbstractClasses;
using MaasBordroProgrami.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace MaasBordroProgrami.Classes
{
    internal class Memur : Personel
    {
        public Memur()
        {
            Pozisyon = nameof(Memur);
        }

        public double Mesai { get; set; }
        public Derece Derece { get; set; }
        private double VarsayilanMaas(double saatlikUcret) 
        {
            double varsayilanMaas = 0;
            if (CalismaSaati > 180)
            {
                Mesai = saatlikUcret * 1.5 * (CalismaSaati - 180);
                varsayilanMaas = saatlikUcret * 180 + Mesai;
            }
            else if (CalismaSaati <= 180)
            {
                varsayilanMaas = 500 * CalismaSaati;
            }
            return varsayilanMaas;
        }

        public override void MaasHesapla()
        {
            switch (Derece)
            {
                case Derece.Memur:
                    SaatlikUcret = 500;
                    Maas = VarsayilanMaas(SaatlikUcret);
                    break;
                case Derece.UzmanYardimcisi:
                    SaatlikUcret = 550;
                    Maas = VarsayilanMaas(SaatlikUcret);
                    break;
                case Derece.Uzman:
                    SaatlikUcret = 600;
                    Maas = VarsayilanMaas(SaatlikUcret);
                    break;
                case Derece.Sef:
                    SaatlikUcret = 750;
                    Maas = VarsayilanMaas(SaatlikUcret);
                    break;
                default:
                    break;
            }
            
        }

    }
}
