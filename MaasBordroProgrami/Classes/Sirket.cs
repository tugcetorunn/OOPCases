using MaasBordroProgrami.AbstractClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaasBordroProgrami.Classes
{
    internal class Sirket
    {
        public string SirketAdi { get; set; } 
        public List<Personel> Personeller { get; set; }

        public string PersonelListesi()
        {
            string list = "";
            foreach (var personel in Personeller)
            {
                list += personel.ToString() + "\n";
            }
            return list;
        }
    }
}
