using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ndpproje
{
    internal class siparis
    {
        private string skod;
        private string ykod;
        private float skisi;
        private float sfiyat;
        private float skdvOrani;
        private float skar;

        public string Skod
        { get { return skod; } set { skod = value; } }

        public string Ykod
        { get { return ykod; } set { ykod = value; } }

        public float Skisi
        { get { return skisi; } set { skisi = value; } }

        public float Sfiyat
        { get { return sfiyat; } set { sfiyat = value; } }

        public float SkdvOrani
        { get { return skdvOrani; } set { skdvOrani = value; } }

        public float Skar
        { get { return skar; } set { skar = value; } }

        public siparis(string sk, string yk, float ski, float sf, float skdv, float ska)
        {
            Skod = sk;
            Ykod = yk;
            Skisi = ski;
            Sfiyat = sf;
            SkdvOrani = skdv;
            Skar = ska;
        }

        public siparis()
        {
            Skod = "";
            Ykod = "";
            Skisi = 0.0f;
            Sfiyat = 0.0f;
            SkdvOrani = 0.0f;
            Skar = 0.0f;
        }

        ~siparis()//yıkıcı
        {
        }

        public string sipariskayit()
        {
            String data = Skod + " " + Ykod + " " + Skisi + " " + Sfiyat + " " + SkdvOrani + " " + Skar;
            return data;
        }

        public void siparisdonus(string s)
        {
            string[] alanlar = s.Split(' ');

            if (alanlar.Length >= 6) // Gerekli alan sayısını kontrol edin
            {
                Skod = alanlar[0];
                Ykod = alanlar[1];
                Skisi = Convert.ToSingle(alanlar[2]);
                Sfiyat = Convert.ToSingle(alanlar[3]);
                SkdvOrani = Convert.ToSingle(alanlar[4]);
                Skar = Convert.ToSingle(alanlar[5]);
            }
            else
            {
                // Hata durumuyla ilgili işlem yapabilirsiniz, örneğin:
                Console.WriteLine("Hatalı veri formatı: " + s);
            }
        }
    }
}
