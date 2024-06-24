using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ndpproje
{
    internal class urun
    {
        private string ukod;
        private string uad;
        private float ustok;
        private float uminstok;
        private float ukalori;
        private float ufiyat;//alanlar

        public string Ukod
        { get { return ukod; } set { ukod = value; } }
        public string Uad
        { get { return uad; } set { uad = value; } }
        public float Ustok
        { get { return ustok; } set { ustok = value; } }
        public float Uminstok
        { get { return uminstok; } set { uminstok = value; } }
        public float Ukalori
        { get { return ukalori; } set { ukalori = value; } }
        public float Ufiyat
        { get { return ufiyat; } set { ufiyat = value; } }
        public urun(string uko, string ua, float us, float um, float uka, float uf)//parametreli kurucu
        {
            ukod = uko;
            Uad = ua;
            Ustok = us;
            Uminstok = um;
            Ukalori = uka;
            Ufiyat = uf;
        }

        public urun()//varsayılan(default) kurucu
        {
            Ukod = "";
            Uad = "";
            Ustok = 0.0f;
            Uminstok = 0.0f;
            Ukalori = 0.0f;
            Ufiyat = 0.0f;
        }

        ~urun()//yıkıcı
        {
        }

        public string depokayit()
        {
            String data = Ukod + " " + Uad + " " + Ustok + " " + Uminstok + " " + Ukalori + " " + Ufiyat;
            return data;
        }

        public void depodonus(string s)
        {
            string[] alanlar = s.Split(' ');

            if (alanlar.Length >= 6) // Gerekli alan sayısını kontrol edin
            {
                Ukod = alanlar[0];
                Uad = alanlar[1];
                Ustok = Convert.ToSingle(alanlar[2]);
                Uminstok = Convert.ToSingle(alanlar[3]);
                Ukalori = Convert.ToSingle(alanlar[4]);
                Ufiyat = Convert.ToSingle(alanlar[5]);
            }
            else
            {
                // Hata durumuyla ilgili işlem yapabilirsiniz, örneğin:
                Console.WriteLine("Hatalı veri formatı: " + s);
            }
        }
    }
}
