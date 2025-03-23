using MaasBordroProgrami.AbstractClasses;
using MaasBordroProgrami.Classes;
using MaasBordroProgrami.FileService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaasBordroProgrami.PersonelService
{
    internal class PersonelIslemleri
    {
        private readonly Sirket sirket;
        private readonly List<Personel> personeller;
        private readonly string dosyaYolu;
        public PersonelIslemleri(Sirket _sirket, string _dosyaYolu)
        {
            dosyaYolu = _dosyaYolu;
            personeller = new List<Personel>();
            sirket = _sirket;
        }
        public void PersonelEkle(Personel personel)
        {
            personeller.Add(personel);
            sirket.Personeller = personeller;
        }

        public void PersonelleriKaydet()
        {
            DosyaIslemleri.DosyayaYazma(dosyaYolu, personeller);
        }

        public void PersonellereMaasGir()
        {
            List<Personel> dosyadakiPersoneller = DosyaIslemleri.DosyaOkuma<List<Personel>>(dosyaYolu);

            foreach (var personel in dosyadakiPersoneller)
            {

            }
        }


    }
}
