using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ndpproje
{
    internal class tarif
    {
        private List<malzeme> liste = new List<malzeme>();

        public void ekle(malzeme m)
        {
            liste.Add(m);
        }
        public void sil(int index)
        {
            if (index >= 0)
            {
                liste.RemoveAt(index);
            }
        }
        public List<malzeme> malzemeYazdir()
        {
            return liste;
        }
    }
}
