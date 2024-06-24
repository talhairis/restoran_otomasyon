using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ndpproje
{
    internal class depoliste
    {
        private List<urun> liste = new List<urun>();

        public void ekle(urun u)
        {
            liste.Add(u);
        }
        public void sil(int index)
        {
            if (index >= 0)
            {
                liste.RemoveAt(index);
            }
        }
        public List<urun> depoYazdir()
        {
            return liste;
        }
        public urun urunAra(string ukod)
        {
            foreach (urun u in liste)
            {
                if (u.Ukod == ukod)
                {
                    return u;
                }
            }
            return null; // Ürün bulunamazsa null döndürür
        }

    }
}
