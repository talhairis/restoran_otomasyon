using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ndpproje
{
    internal class siparisliste
    {
        private List<siparis> liste = new List<siparis>();

        public void ekle(siparis s)
        {
            liste.Add(s);
        }
        public void sil(int index)
        {
            if (index >= 0)
            {
                liste.RemoveAt(index);
            }
        }
        public List<siparis> siparisYazdir()
        {
            return liste;
        }
    }
}
