using MaasBordroProgrami.AbstractClasses;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MaasBordroProgrami.Classes
{
    internal class MaasBordro
    {
        public string PersonelIsmi { get; set; }
        public int CalismaSaati { get; set; }
        public double AnaOdeme { get; set; }
        public double MesaiYaDaBonus { get; set; } 
        public double ToplamOdeme { get; set; }
        public DateTime Donem { get; set; }
        public string AyYil => Donem.ToString("MM/yyyy", new CultureInfo("tr-TR")).ToUpper();
        private Personel Personel { get; set; }
        public string AzCalisanPersoneller()
        {
            string personelOzeti = "";
            if (Personel.CalismaSaati < 150)
            {
                personelOzeti += Personel.ToString() + "\n";
            }
            return personelOzeti;
        }
    }
}
