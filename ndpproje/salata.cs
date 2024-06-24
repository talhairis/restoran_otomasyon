using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ndpproje
{
    internal class salata : yiyecekicecek
    {
        public float ykalori;

        public float Ykalori
        { get { return ykalori; } set { ykalori = value; } }

        public salata(string yko, string ya, float yka, float yf, float ykdv) : base(yko, ya, yf, ykdv)
        {
            Ykalori = yka;
        }

        public salata() : base()
        {
            Ykalori = 0.0f;
        }

        ~salata()//yıkıcı
        {
        }

        public override string ykayit()
        {
            String data = Ykod + " " + Yad + " " + Ykalori + " " + Yfiyat + " " + YkdvOrani;
            return data;
        }

        public override void ydonus(string s)
        {
            string[] alanlar = s.Split(' ');

            if (alanlar.Length >= 5) // Gerekli alan sayısını kontrol edin
            {
                Ykod = alanlar[0];
                Yad = alanlar[1];
                Ykalori = Convert.ToSingle(alanlar[2]);
                Yfiyat = Convert.ToSingle(alanlar[3]);
                YkdvOrani = Convert.ToSingle(alanlar[4]);
            }
            else
            {
                // Hata durumuyla ilgili işlem yapabilirsiniz, örneğin:
                Console.WriteLine("Hatalı veri formatı: " + s);
            }
        }
    }
}
