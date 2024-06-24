using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ndpproje
{
    internal class malzeme
    {
        private string ykod;
        private string ukod;
        private float mmiktar;

        public string Ykod
        { get { return ykod; } set { ykod = value; } }
        public string Ukod
        { get { return ukod; } set { ukod = value; } }

        public float Mmiktar
        { get { return mmiktar; } set { mmiktar = value; } }

        public malzeme(string yk, string mk, float mm)
        {
            Ykod = yk;
            Ukod = mk;
            Mmiktar = mm;
        }

        public malzeme()
        {
            Ykod = "";
            Ukod = "";
            Mmiktar = 0.0f;
        }

        ~malzeme()//yıkıcı
        {
        }

        public string malzemekayit()
        {
            String data = Ykod + " " + Ukod + " " + Mmiktar;
            return data;
        }

        public void malzemedonus(string s)
        {
            string[] alanlar = s.Split(' ');

            if (alanlar.Length >= 3) // Gerekli alan sayısını kontrol edin
            {
                Ykod = alanlar[0];
                Ukod = alanlar[1];
                Mmiktar = Convert.ToSingle(alanlar[2]);
            }
            else
            {
                // Hata durumuyla ilgili işlem yapabilirsiniz, örneğin:
                Console.WriteLine("Hatalı veri formatı: " + s);
            }
        }
    }
}
