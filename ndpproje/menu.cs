using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ndpproje
{
    internal class menu
    {
        private List<yiyecekicecek> liste = new List<yiyecekicecek>();

        public void ekle(yiyecekicecek yi)
        {
            liste.Add(yi);
        }
        public void sil(int index)
        {
            if (index >= 0)
            {
                liste.RemoveAt(index);
            }
        }
        public List<yiyecekicecek> menuYazdir()
        {
            return liste;
        }
    }
}
