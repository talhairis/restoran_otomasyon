using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ndpproje
{
    internal class yiyecekicecek
    {
        protected string ykod;
        protected string yad;
        protected float yfiyat;
        protected float ykdvOrani;

        public string Ykod
        { get { return ykod; } set { ykod = value; } }

        public string Yad
        { get { return yad; } set { yad = value; } }

        public float Yfiyat
        { get { return yfiyat; } set { yfiyat = value; } }

        public float YkdvOrani
        { get { return ykdvOrani; } set { ykdvOrani = value; } }

        public yiyecekicecek(string yko, string ya, float yf, float ykdv)
        {
            Ykod = yko;
            Yad = ya;
            Yfiyat = yf;
            YkdvOrani = ykdv;
        }

        public yiyecekicecek()
        {
            Ykod = "";
            Yad = "";
            Yfiyat = 0.0f;
            YkdvOrani = 0.0f;
        }

        ~yiyecekicecek()//yıkıcı
        {
        }

        public virtual string ykayit()
        {
            String data = Ykod + " " + Yad + " " + Yfiyat + " " + YkdvOrani;
            return data;
        }

        public virtual void ydonus(string s)
        {
            string[] alanlar = s.Split(' ');

            if (alanlar.Length >= 4) // Gerekli alan sayısını kontrol edin
            {
                Ykod = alanlar[0];
                Yad = alanlar[1];
                Yfiyat = Convert.ToSingle(alanlar[2]);
                YkdvOrani = Convert.ToSingle(alanlar[3]);
            }
            else
            {
                // Hata durumuyla ilgili işlem yapabilirsiniz, örneğin:
                Console.WriteLine("Hatalı veri formatı: " + s);
            }
        }
    }
}
