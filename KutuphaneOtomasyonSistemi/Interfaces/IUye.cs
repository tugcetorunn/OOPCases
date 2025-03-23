using KutuphaneOtomasyonSistemi.AbstractClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace KutuphaneOtomasyonSistemi.Interfaces
{
    internal interface IUye
    {
        string Ad { get; set; }
        string Soyad { get; set; }
        int UyeNo { get; set; }
        DateTime KayitTarihi { get; set; }
        string OduncAlinanKitaplar();
    }
}
