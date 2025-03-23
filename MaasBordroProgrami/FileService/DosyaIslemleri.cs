using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaasBordroProgrami.FileService
{
    internal static class DosyaIslemleri
    {
        public static void DosyayaYazma<T>(string dosyaYolu, T entity)
        {
            string json = JsonConvert.SerializeObject(entity, Formatting.Indented, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All });

            File.WriteAllText(dosyaYolu, json);
        }

        public static T DosyaOkuma<T>(string dosyaYolu)
        {
            if (!File.Exists(dosyaYolu))
            {
                throw new Exception("Dosya bulunamadı.");
            }

            string jsonIcerik = File.ReadAllText(dosyaYolu);

            return JsonConvert.DeserializeObject<T>(jsonIcerik, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto });

        }
    }
}
