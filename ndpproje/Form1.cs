using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ndpproje
{
    public partial class Form1 : Form
    {
        string dosyayolu1 = @"C:\Users\talha\OneDrive\Desktop\saitem c\projedeneme\depo.txt";
        string dosyayolu2 = @"C:\Users\talha\OneDrive\Desktop\saitem c\projedeneme\yemekcesit.txt";
        string dosyayolu3 = @"C:\Users\talha\OneDrive\Desktop\saitem c\projedeneme\malzeme.txt";
        string dosyayolu4 = @"C:\Users\talha\OneDrive\Desktop\saitem c\projedeneme\siparis.txt";
        depoliste d = new depoliste();
        menu m = new menu();
        tarif t = new tarif();
        siparisliste s = new siparisliste();

        private void GuncellenmisMenuyuYukle()
        {
            checkedYemekBox1.Items.Clear();

            using (FileStream fs = new FileStream(dosyayolu2, FileMode.Open, FileAccess.Read))
            using (StreamReader sr = new StreamReader(fs))
            {
                string yemekcesitrapor = sr.ReadLine();
                while (yemekcesitrapor != null)
                {
                    yiyecekicecek yi = new yemek();
                    yi.ydonus(yemekcesitrapor);
                    checkedYemekBox1.Items.Add(yi.ykayit());
                    yemekcesitrapor = sr.ReadLine();
                }
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)//tamam
        {
            if (File.Exists(dosyayolu1))
            {
                using (FileStream fs = new FileStream(dosyayolu1, FileMode.Open, FileAccess.Read))
                using (StreamReader sr = new StreamReader(fs))
                {
                    string deporapor = sr.ReadLine();
                    while (deporapor != null)
                    {
                        urun u = new urun(); // Her döngüde yeni bir ürün oluşturuluyor
                        u.depodonus(deporapor); // Dosyadan okunan veriler ürün özelliklerine atanıyor
                        d.ekle(u); // Ürün depo listesine ekleniyor
                        checkedDepoBox1.Items.Add(u.depokayit()); // Listbox'a ürünü ekleyin veya d.ekle(u) yerine d.menuYazdir() kullanarak liste içeriğini direk ekleyebilirsiniz
                        deporapor = sr.ReadLine();
                    }
                }
            }
            else
            {
                MessageBox.Show("Dosya bulunamadı: " + dosyayolu1);
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)//tamam
        {
            if(tabControl1.SelectedIndex == 0)
            {
                if (File.Exists(dosyayolu1))
                {
                    d.depoYazdir().Clear();
                    checkedDepoBox1.Items.Clear();
                    //checkedDepoBox2.Items.Clear();

                    using (FileStream fs = new FileStream(dosyayolu1, FileMode.Open, FileAccess.Read))
                    using (StreamReader sr = new StreamReader(fs))
                    {
                        string deporapor = sr.ReadLine();
                        while (deporapor != null)
                        {
                            urun u = new urun(); // Her döngüde yeni bir ürün oluşturuluyor
                            u.depodonus(deporapor); // Dosyadan okunan veriler ürün özelliklerine atanıyor
                            d.ekle(u);
                            checkedDepoBox1.Items.Add(u.depokayit());
                            //checkedDepoBox2.Items.Add(u.depokayit()); // Listbox'a ürünü ekleyin veya d.ekle(u) yerine d.menuYazdir() kullanarak liste içeriğini direk ekleyebilirsiniz
                            deporapor = sr.ReadLine();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Dosya bulunamadı: " + dosyayolu1);
                }
            }

            if (tabControl1.SelectedIndex == 1)
            {
                if (File.Exists(dosyayolu2))
                {
                    m.menuYazdir().Clear();
                    checkedYemekBox1.Items.Clear();

                    using (FileStream fs = new FileStream(dosyayolu2, FileMode.Open, FileAccess.Read))
                    using (StreamReader sr = new StreamReader(fs))
                    {
                        string yemekcesitrapor = sr.ReadLine();
                        while (yemekcesitrapor != null)
                        {
                            yiyecekicecek yi = new yemek();
                            yi.ydonus(yemekcesitrapor);
                            m.ekle(yi);
                            checkedYemekBox1.Items.Add(yi.ykayit());
                            yemekcesitrapor = sr.ReadLine();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Dosya bulunamadı: " + dosyayolu2);
                }

                if (File.Exists(dosyayolu3))
                {
                    t.malzemeYazdir().Clear();
                    checkedMalzemeBox1.Items.Clear();

                    using (FileStream fs = new FileStream(dosyayolu3, FileMode.Open, FileAccess.Read))
                    using (StreamReader sr = new StreamReader(fs))
                    {
                        string malzemerapor = sr.ReadLine();
                        while (malzemerapor != null)
                        {
                            malzeme m = new malzeme();
                            m.malzemedonus(malzemerapor);
                            t.ekle(m);
                            checkedMalzemeBox1.Items.Add(m.malzemekayit());
                            malzemerapor = sr.ReadLine();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Dosya bulunamadı: " + dosyayolu3);
                }
            }

            if (tabControl1.SelectedIndex == 2)
            {
                if (File.Exists(dosyayolu1))
                {
                    d.depoYazdir().Clear();
                    checkedDepoBox2.Items.Clear();
                    //checkedDepoBox2.Items.Clear();

                    using (FileStream fs = new FileStream(dosyayolu1, FileMode.Open, FileAccess.Read))
                    using (StreamReader sr = new StreamReader(fs))
                    {
                        string deporapor = sr.ReadLine();
                        while (deporapor != null)
                        {
                            urun u = new urun(); // Her döngüde yeni bir ürün oluşturuluyor
                            u.depodonus(deporapor); // Dosyadan okunan veriler ürün özelliklerine atanıyor
                            d.ekle(u);
                            checkedDepoBox2.Items.Add(u.depokayit());
                            //checkedDepoBox2.Items.Add(u.depokayit()); // Listbox'a ürünü ekleyin veya d.ekle(u) yerine d.menuYazdir() kullanarak liste içeriğini direk ekleyebilirsiniz
                            deporapor = sr.ReadLine();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Dosya bulunamadı: " + dosyayolu1);
                }

                if (File.Exists(dosyayolu2))
                {
                    m.menuYazdir().Clear();
                    checkedYemekBox2.Items.Clear();

                    using (FileStream fs = new FileStream(dosyayolu2, FileMode.Open, FileAccess.Read))
                    using (StreamReader sr = new StreamReader(fs))
                    {
                        string yemekcesitrapor = sr.ReadLine();
                        while (yemekcesitrapor != null)
                        {
                            yiyecekicecek yi = new yemek();
                            yi.ydonus(yemekcesitrapor);
                            m.ekle(yi);
                            checkedYemekBox2.Items.Add(yi.ykayit());
                            yemekcesitrapor = sr.ReadLine();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Dosya bulunamadı: " + dosyayolu2);
                }

                if (File.Exists(dosyayolu3))
                {
                    t.malzemeYazdir().Clear();
                    checkedMalzemeBox2.Items.Clear();

                    using (FileStream fs = new FileStream(dosyayolu3, FileMode.Open, FileAccess.Read))
                    using (StreamReader sr = new StreamReader(fs))
                    {
                        string malzemerapor = sr.ReadLine();
                        while (malzemerapor != null)
                        {
                            malzeme m = new malzeme();
                            m.malzemedonus(malzemerapor);
                            t.ekle(m);
                            checkedMalzemeBox2.Items.Add(m.malzemekayit());
                            malzemerapor = sr.ReadLine();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Dosya bulunamadı: " + dosyayolu3);
                }
            }

            if (tabControl1.SelectedIndex == 3)
            {
                if (File.Exists(dosyayolu2))
                {
                    m.menuYazdir().Clear();
                    checkedYemekBox3.Items.Clear();

                    using (FileStream fs = new FileStream(dosyayolu2, FileMode.Open, FileAccess.Read))
                    using (StreamReader sr = new StreamReader(fs))
                    {
                        string yemekcesitrapor = sr.ReadLine();
                        while (yemekcesitrapor != null)
                        {
                            yiyecekicecek yi = new yemek();
                            yi.ydonus(yemekcesitrapor);
                            m.ekle(yi);
                            checkedYemekBox3.Items.Add(yi.ykayit());
                            yemekcesitrapor = sr.ReadLine();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Dosya bulunamadı: " + dosyayolu2);
                }

                if (File.Exists(dosyayolu3))
                {
                    t.malzemeYazdir().Clear();
                    checkedMalzemeBox3.Items.Clear();

                    using (FileStream fs = new FileStream(dosyayolu3, FileMode.Open, FileAccess.Read))
                    using (StreamReader sr = new StreamReader(fs))
                    {
                        string malzemerapor = sr.ReadLine();
                        while (malzemerapor != null)
                        {
                            malzeme m = new malzeme();
                            m.malzemedonus(malzemerapor);
                            t.ekle(m);
                            checkedMalzemeBox3.Items.Add(m.malzemekayit());
                            malzemerapor = sr.ReadLine();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Dosya bulunamadı: " + dosyayolu3);
                }

                if (File.Exists(dosyayolu4))
                {
                    s.siparisYazdir().Clear();
                    checkedSiparisBox1.Items.Clear();

                    using (FileStream fs = new FileStream(dosyayolu4, FileMode.Open, FileAccess.Read))
                    using (StreamReader sr = new StreamReader(fs))
                    {
                        string siparisrapor = sr.ReadLine();
                        while (siparisrapor != null)
                        {
                            siparis siparis = new siparis();
                            siparis.siparisdonus(siparisrapor);
                            s.ekle(siparis);
                            checkedSiparisBox1.Items.Add(siparis.sipariskayit());
                            siparisrapor = sr.ReadLine();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Dosya bulunamadı: " + dosyayolu4);
                }
            }

            if (tabControl1.SelectedIndex == 4)
            {
                if (File.Exists(dosyayolu4))
                {
                    s.siparisYazdir().Clear();
                    checkedSiparisBox2.Items.Clear();

                    using (FileStream fs = new FileStream(dosyayolu4, FileMode.Open, FileAccess.Read))
                    using (StreamReader sr = new StreamReader(fs))
                    {
                        string siparisrapor = sr.ReadLine();
                        while (siparisrapor != null)
                        {
                            siparis siparis = new siparis();
                            siparis.siparisdonus(siparisrapor);
                            s.ekle(siparis);
                            checkedSiparisBox2.Items.Add(siparis.sipariskayit());
                            siparisrapor = sr.ReadLine();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Dosya bulunamadı: " + dosyayolu4);
                }
            }
        }

        private void depoekle_Click(object sender, EventArgs e)//tamam
        {
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(textBox3.Text) || string.IsNullOrEmpty(textBox4.Text) || string.IsNullOrEmpty(textBox5.Text) || string.IsNullOrEmpty(textBox6.Text))
            {
                MessageBox.Show("Lütfen tüm gerekli alanları doldurun.");
                return;
            }

            if (!float.TryParse(textBox3.Text, out float stok) || !float.TryParse(textBox4.Text, out float minStok) || !float.TryParse(textBox5.Text, out float kalori) || !float.TryParse(textBox6.Text, out float fiyat))
            {
                MessageBox.Show("Geçersiz sayı girildi.");
                return;
            }

            urun yeniUrun = new urun(textBox1.Text, textBox2.Text, stok, minStok, kalori, fiyat);

            using (StreamWriter sw = new StreamWriter(dosyayolu1, true))
            {
                sw.WriteLine(yeniUrun.depokayit());
            }

            // Ürünü depoliste'ye eklemek için
            d.ekle(yeniUrun);

            // checkedDepoBox içeriğini temizle
            checkedDepoBox1.Items.Clear();

            using (FileStream fs = new FileStream(dosyayolu1, FileMode.Open, FileAccess.Read))
            using (StreamReader sr = new StreamReader(fs))
            {
                string deporapor = sr.ReadLine();
                while (deporapor != null)
                {
                    urun u = new urun(); // Her döngüde yeni bir ürün oluşturuluyor
                    u.depodonus(deporapor); // Dosyadan okunan veriler ürün özelliklerine atanıyor
                    checkedDepoBox1.Items.Add(u.depokayit()); // Listbox'a ürünü ekleyin veya d.ekle(u) yerine d.menuYazdir() kullanarak liste içeriğini direk ekleyebilirsiniz
                    deporapor = sr.ReadLine();
                }
            }

            // Kullanıcıya geribildirim vermek ve textboxları temizlemek için
            MessageBox.Show("Ürün depoya eklendi.");
            textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = textBox6.Text = "";
        }

        private void deposil_Click(object sender, EventArgs e)//tamam
        {
            List<int> indexesToRemove = new List<int>();

            // Seçili olan ürünlerin indekslerini bul
            for (int i = 0; i < checkedDepoBox1.CheckedItems.Count; i++)
            {
                indexesToRemove.Add(checkedDepoBox1.Items.IndexOf(checkedDepoBox1.CheckedItems[i]));
            }

            // İndeksleri büyükten küçüğe sırala (sondan başlayarak silme işlemi için)
            indexesToRemove.Sort((a, b) => b.CompareTo(a));

            // Depo.txt dosyasından silme işlemleri
            List<string> lines = File.ReadAllLines(dosyayolu1).ToList();

            foreach (int index in indexesToRemove)
            {
                if (index >= 0 && index < lines.Count)
                {
                    lines.RemoveAt(index);
                }
            }

            File.WriteAllLines(dosyayolu1, lines);

            // Seçilenleri checkbox listesinden kaldır
            for (int i = checkedDepoBox1.Items.Count - 1; i >= 0; i--)
            {
                if (checkedDepoBox1.GetItemChecked(i))
                {
                    checkedDepoBox1.Items.RemoveAt(i);
                }
            }
        }

        private void depoguncelle_Click(object sender, EventArgs e)//tamam
        {
            if (checkedDepoBox1.SelectedItem == null)
            {
                MessageBox.Show("Lütfen güncellenecek bir ürün seçin.");
                return;
            }

            int seciliUrunIndex = checkedDepoBox1.SelectedIndex;

            if (seciliUrunIndex >= 0 && seciliUrunIndex < d.depoYazdir().Count)
            {
                urun seciliUrun = d.depoYazdir()[seciliUrunIndex]; // 1. Adım: Güncellenecek ürünü seç

                float yeniStok, yeniMinStok, yeniKalori, yeniFiyat;

                yeniStok = seciliUrun.Ustok;    // Varsayılan değer olarak mevcut stok değerini al
                yeniMinStok = seciliUrun.Uminstok;  // Varsayılan değer olarak mevcut minStok değerini al
                yeniKalori = seciliUrun.Ukalori;    // Varsayılan değer olarak mevcut kalori değerini al
                yeniFiyat = seciliUrun.Ufiyat;    // Varsayılan değer olarak mevcut fiyat değerini al

                if (!string.IsNullOrEmpty(textBox3.Text) && !float.TryParse(textBox3.Text, out yeniStok))
                {
                    MessageBox.Show("Geçersiz stok sayısı girildi.");
                    return;
                }

                if (!string.IsNullOrEmpty(textBox4.Text) && !float.TryParse(textBox4.Text, out yeniMinStok))
                {
                    MessageBox.Show("Geçersiz minStok sayısı girildi.");
                    return;
                }

                if (!string.IsNullOrEmpty(textBox5.Text) && !float.TryParse(textBox5.Text, out yeniKalori))
                {
                    MessageBox.Show("Geçersiz kalori sayısı girildi.");
                    return;
                }

                if (!string.IsNullOrEmpty(textBox6.Text) && !float.TryParse(textBox6.Text, out yeniFiyat))
                {
                    MessageBox.Show("Geçersiz fiyat sayısı girildi.");
                    return;
                }

                urun yeniUrun = new urun(); // 2. Adım: Yeni ürün nesnesi oluştur
                yeniUrun.Ukod = seciliUrun.Ukod;
                yeniUrun.Uad = seciliUrun.Uad;
                yeniUrun.Ustok = yeniStok;
                yeniUrun.Uminstok = yeniMinStok;
                yeniUrun.Ukalori = yeniKalori;
                yeniUrun.Ufiyat = yeniFiyat;

                d.sil(seciliUrunIndex); // 3. Adım: Eski ürünü sil
                d.ekle(yeniUrun); // 4. Adım: Yeni ürünü ekle

                List<string> urunBilgileri = new List<string>();

                foreach (var urun in d.depoYazdir())
                {
                    urunBilgileri.Add(urun.depokayit());
                }

                File.WriteAllLines(dosyayolu1, urunBilgileri);

                checkedDepoBox1.Items.Clear();
                foreach (var urun in urunBilgileri)
                {
                    checkedDepoBox1.Items.Add(urun);
                }

                MessageBox.Show("Ürün güncellendi.");

                textBox3.Text = textBox4.Text = textBox5.Text = textBox6.Text = "";
            }
            else
            {
                MessageBox.Show("Geçersiz indeks seçildi.");
            }
        }

        private void yemekekle_Click(object sender, EventArgs e)//tamam
        {
            yiyecekicecek yeniYi = new yiyecekicecek();

            if (string.IsNullOrEmpty(textBox7.Text) || string.IsNullOrEmpty(textBox8.Text) || string.IsNullOrEmpty(textBox9.Text) || string.IsNullOrEmpty(textBox10.Text) || string.IsNullOrEmpty(textBox11.Text))
            {
                MessageBox.Show("Lütfen tüm gerekli alanları doldurun.");
                return;
            }

            float kalori = Convert.ToSingle(textBox9.Text);
            float fiyat = Convert.ToSingle(textBox10.Text);
            float kdvOrani = Convert.ToSingle(textBox11.Text);

            if (comboBox1.Text == "Yemek")
            {
                yeniYi = new yemek(textBox7.Text, textBox8.Text, kalori, fiyat, kdvOrani);
            }
            if (comboBox1.Text == "Salata")
            {
                yeniYi = new salata(textBox7.Text, textBox8.Text, kalori, fiyat, kdvOrani);
            }
            if (comboBox1.Text == "Tatlı")
            {
                yeniYi = new tatli(textBox7.Text, textBox8.Text, kalori, fiyat, kdvOrani);
            }
            if (comboBox1.Text == "İçecek")
            {
                yeniYi = new icecek(textBox7.Text, textBox8.Text, kalori, fiyat, kdvOrani);
            }

            using (StreamWriter sw = new StreamWriter(dosyayolu2, true))
            {
                sw.WriteLine(yeniYi.ykayit());
            }

            m.ekle(yeniYi);

            // checkedDepoBox içeriğini temizle
            checkedYemekBox1.Items.Clear();

            using (FileStream fs = new FileStream(dosyayolu2, FileMode.Open, FileAccess.Read))
            using (StreamReader sr = new StreamReader(fs))
            {
                string yemekcesitrapor = sr.ReadLine();
                while (yemekcesitrapor != null)
                {
                    yiyecekicecek yi = new yemek(); // Her döngüde yeni bir ürün oluşturuluyor
                    yi.ydonus(yemekcesitrapor); // Dosyadan okunan veriler ürün özelliklerine atanıyor
                    checkedYemekBox1.Items.Add(yi.ykayit());
                    yemekcesitrapor = sr.ReadLine();
                }
            }

            MessageBox.Show("Yemek menüye eklendi.");
            comboBox1.SelectedIndex = -1;
            textBox7.Text = textBox8.Text = textBox9.Text = textBox10.Text = textBox11.Text = "";
        }

        private void yemeksil_Click(object sender, EventArgs e)//tamam
        {
            if (checkedYemekBox1.SelectedItem == null)
            {
                MessageBox.Show("Lütfen silinecek bir yemek seçin.");
                return;
            }

            int seciliYemekIndex = checkedYemekBox1.SelectedIndex;
            yiyecekicecek seciliYemek = m.menuYazdir()[seciliYemekIndex];
            string seciliYemekKod = seciliYemek.Ykod;

            // Tarif listesinden ilgili malzemeleri sil
            for (int i = t.malzemeYazdir().Count - 1; i >= 0; i--)
            {
                if (t.malzemeYazdir()[i].Ykod == seciliYemekKod)
                {
                    t.sil(i);
                }
            }

            // Seçilen yemeği menüden ve checkedYemekBox'tan sil
            m.sil(seciliYemekIndex);
            checkedYemekBox1.Items.RemoveAt(seciliYemekIndex);

            // İlgili yemeği yemekcesit.txt'den sil
            List<string> yemekLines = File.ReadAllLines(dosyayolu2).ToList();
            List<string> updatedYemekLines = new List<string>();

            foreach (string line in yemekLines)
            {
                string[] parts = line.Split(' ');
                if (parts.Length >= 1 && parts[0] != seciliYemekKod)
                {
                    updatedYemekLines.Add(line);
                }
            }

            File.WriteAllLines(dosyayolu2, updatedYemekLines);

            // İlgili malzemeleri checkedMalzemeBox1 ve malzeme.txt'den sil
            List<string> malzemeLines = File.ReadAllLines(dosyayolu3).ToList();
            List<string> updatedMalzemeLines = new List<string>();

            foreach (string line in malzemeLines)
            {
                string[] parts = line.Split(' ');
                if (parts.Length >= 1 && parts[0] != seciliYemekKod)
                {
                    updatedMalzemeLines.Add(line);
                }
            }

            File.WriteAllLines(dosyayolu3, updatedMalzemeLines);

            // checkedMalzemeBox1'i güncelle
            checkedMalzemeBox1.Items.Clear();
            foreach (var malzeme in updatedMalzemeLines)
            {
                checkedMalzemeBox1.Items.Add(malzeme);
            }

            MessageBox.Show("Yemek ve ilgili malzemeleri silindi.");
        }

        private void yemekguncelle_Click(object sender, EventArgs e)//dandik
        {
            if (checkedYemekBox1.SelectedItem == null)
            {
                MessageBox.Show("Lütfen güncellenecek bir yemek seçin.");
                return;
            }

            int seciliYemekIndex = checkedYemekBox1.SelectedIndex;

            if (seciliYemekIndex >= 0 && seciliYemekIndex < m.menuYazdir().Count)
            {
                yiyecekicecek seciliYemek = m.menuYazdir()[seciliYemekIndex]; // 1. Adım: Güncellenecek yemeği seç

                float yeniKalori, yeniFiyat, yeniKdvOrani;

                yeniKalori = ((yemek)seciliYemek).Ykalori;    // Varsayılan değer olarak mevcut kalori değerini al
                yeniFiyat = seciliYemek.Yfiyat;    // Varsayılan değer olarak mevcut fiyat değerini al
                yeniKdvOrani = seciliYemek.YkdvOrani;    // Varsayılan değer olarak mevcut KDV oranını al

                if (!string.IsNullOrEmpty(textBox9.Text) && !float.TryParse(textBox9.Text, out yeniKalori))
                {
                    MessageBox.Show("Geçersiz kalori sayısı girildi.");
                    return;
                }

                if (!string.IsNullOrEmpty(textBox10.Text) && !float.TryParse(textBox10.Text, out yeniFiyat))
                {
                    MessageBox.Show("Geçersiz fiyat sayısı girildi.");
                    return;
                }

                if (!string.IsNullOrEmpty(textBox11.Text) && !float.TryParse(textBox11.Text, out yeniKdvOrani))
                {
                    MessageBox.Show("Geçersiz KDV oranı girildi.");
                    return;
                }

                List<yiyecekicecek> eskiMenu = new List<yiyecekicecek>(m.menuYazdir());

                // Seçili yemeği güncelle
                yiyecekicecek yeniYemek = new yemek();
                yeniYemek.Ykod = seciliYemek.Ykod;
                yeniYemek.Yad = seciliYemek.Yad;
                ((yemek)yeniYemek).Ykalori = yeniKalori;
                yeniYemek.Yfiyat = yeniFiyat;
                yeniYemek.YkdvOrani = yeniKdvOrani;

                m.sil(seciliYemekIndex); // Eski yemeği menüden sil
                m.ekle(yeniYemek); // Yeni yemeği menüye ekle

                // İlgili yemeği yemekcesit.txt dosyasında güncelle
                List<string> yemekLines = File.ReadAllLines(dosyayolu2).ToList();

                for (int i = 0; i < yemekLines.Count; i++)
                {
                    string[] parts = yemekLines[i].Split(' ');
                    if (parts.Length >= 1 && parts[0] == seciliYemek.Ykod)
                    {
                        yemekLines[i] = yeniYemek.ykayit();
                        break;
                    }
                }

                File.WriteAllLines(dosyayolu2, yemekLines);

                GuncellenmisMenuyuYukle();

                MessageBox.Show("Yemek güncellendi.");

                textBox9.Text = textBox10.Text = textBox11.Text = "";
            }
            else
            {
                MessageBox.Show("Geçersiz indeks seçildi.");
            }
        }

        private void malzemeekle_Click(object sender, EventArgs e)//tamam
        {
            if (checkedYemekBox2.SelectedItem == null || checkedDepoBox2.SelectedItem == null)
            {
                MessageBox.Show("Lütfen yemek ve ürün seçin.");
                return;
            }

            string yemekKodu = m.menuYazdir()[checkedYemekBox2.SelectedIndex].Ykod;
            string urunKodu = d.depoYazdir()[checkedDepoBox2.SelectedIndex].Ukod;
            float miktar;

            if (!float.TryParse(textBox12.Text, out miktar) || miktar <= 0)
            {
                MessageBox.Show("Geçersiz miktar girildi.");
                return;
            }

            malzeme yeniMalzeme = new malzeme(yemekKodu, urunKodu, miktar);
            t.ekle(yeniMalzeme);

            checkedMalzemeBox2.Items.Add(yeniMalzeme.malzemekayit());

            using (StreamWriter sw = new StreamWriter(dosyayolu3, true))
            {
                sw.WriteLine(yeniMalzeme.malzemekayit());
            }

            textBox12.Text = "";

            MessageBox.Show("Malzeme tarife eklendi.");
        }

        private void malzemesil_Click(object sender, EventArgs e)//tamam
        {
            if (checkedMalzemeBox2.SelectedItem == null)
            {
                MessageBox.Show("Lütfen silinecek bir malzeme seçin.");
                return;
            }

            int seciliMalzemeIndex = checkedMalzemeBox2.SelectedIndex;

            if (seciliMalzemeIndex >= 0 && seciliMalzemeIndex < t.malzemeYazdir().Count)
            {
                t.sil(seciliMalzemeIndex); // Malzemeyi tarif listesinden sil
                checkedMalzemeBox2.Items.RemoveAt(seciliMalzemeIndex); // Checkbox listesinden sil

                // Malzeme listesini güncelleyin
                List<string> malzemeBilgileri = new List<string>();

                foreach (var malzeme in t.malzemeYazdir())
                {
                    malzemeBilgileri.Add(malzeme.malzemekayit());
                }

                File.WriteAllLines(dosyayolu3, malzemeBilgileri); // malzeme.txt dosyasını güncelleyin

                MessageBox.Show("Malzeme tariften ve listeden silindi.");
            }
            else
            {
                MessageBox.Show("Geçersiz indeks seçildi.");
            }
        }

        private void malzemeguncelle_Click(object sender, EventArgs e)//tamam
        {
            if (checkedMalzemeBox2.SelectedItem == null)
            {
                MessageBox.Show("Lütfen güncellenecek bir malzeme seçin.");
                return;
            }

            int seciliMalzemeIndex = checkedMalzemeBox2.SelectedIndex;

            if (seciliMalzemeIndex >= 0 && seciliMalzemeIndex < t.malzemeYazdir().Count)
            {
                if (string.IsNullOrEmpty(textBox12.Text) || !float.TryParse(textBox12.Text, out float yeniMiktar))
                {
                    MessageBox.Show("Geçersiz miktar girildi.");
                    return;
                }

                t.malzemeYazdir()[seciliMalzemeIndex].Mmiktar = yeniMiktar; // Malzeme miktarını güncelle

                // Malzeme listesini güncelleyin
                List<string> malzemeBilgileri = new List<string>();

                foreach (var malzeme in t.malzemeYazdir())
                {
                    malzemeBilgileri.Add(malzeme.malzemekayit());
                }

                File.WriteAllLines(dosyayolu3, malzemeBilgileri); // malzeme.txt dosyasını güncelleyin

                t.malzemeYazdir().Clear();
                checkedMalzemeBox2.Items.Clear();

                using (FileStream fs = new FileStream(dosyayolu3, FileMode.Open, FileAccess.Read))
                using (StreamReader sr = new StreamReader(fs))
                {
                    string malzemerapor = sr.ReadLine();
                    while (malzemerapor != null)
                    {
                        malzeme m = new malzeme();
                        m.malzemedonus(malzemerapor);
                        t.ekle(m);
                        checkedMalzemeBox2.Items.Add(m.malzemekayit());
                        malzemerapor = sr.ReadLine();
                    }
                }

                MessageBox.Show("Malzeme miktarı güncellendi.");
                textBox12.Text = ""; // TextBox'ı temizle
            }
            else
            {
                MessageBox.Show("Geçersiz indeks seçildi.");
            }
        }

        private void siparisekle_Click(object sender, EventArgs e)//tamam
        {
            if (checkedYemekBox3.SelectedItem == null)
            {
                MessageBox.Show("Lütfen bir yemek seçin.");
                return;
            }

            if (string.IsNullOrEmpty(textBox13.Text) || string.IsNullOrEmpty(textBox14.Text))
            {
                MessageBox.Show("Lütfen gerekli alanları doldurun.");
                return;
            }

            int seciliYemekIndex = checkedYemekBox3.SelectedIndex;
            string seciliYemekKod = m.menuYazdir()[seciliYemekIndex].Ykod;

            if (!int.TryParse(textBox14.Text, out int siparisPorsiyonu))
            {
                MessageBox.Show("Geçersiz porsiyon sayısı girildi.");
                return;
            }

            yiyecekicecek seciliYemek = m.menuYazdir()[seciliYemekIndex];

            string siparisKod = textBox13.Text;
            float siparisFiyat = seciliYemek.Yfiyat * siparisPorsiyonu;
            float siparisKdvOrani = seciliYemek.YkdvOrani;
                float siparisKdvTutari = siparisFiyat * siparisKdvOrani / 100;
            float siparisToplamFiyat = siparisFiyat - siparisKdvTutari;

            siparis yeniSiparis = new siparis(siparisKod, seciliYemekKod, siparisPorsiyonu, siparisFiyat, siparisKdvOrani, siparisToplamFiyat);

            s.ekle(yeniSiparis);

            string siparisSatir = $"{siparisKod} {seciliYemekKod} {siparisPorsiyonu} {siparisFiyat} {siparisKdvOrani} {siparisToplamFiyat}";

            using (StreamWriter sw = new StreamWriter(dosyayolu4, true))
            {
                sw.WriteLine(siparisSatir);
            }

            // Yemeğin malzemelerini güncelle
            foreach (malzeme malzeme in t.malzemeYazdir())
            {
                if (malzeme.Ykod == seciliYemekKod)
                {
                    int index = 0;
                    urun guncelUrun = new urun();
                    urun depoUrun = d.urunAra(malzeme.Ukod);
                    for(int i = 0; i < d.depoYazdir().Count; i++)
                    {
                        if (d.depoYazdir()[i] == depoUrun)
                        {
                            index = i;
                        }
                    }
                    if (depoUrun != null)
                    {
                        guncelUrun.Ukod = depoUrun.Ukod;
                        guncelUrun.Uad = depoUrun.Uad;
                        float yenistok = depoUrun.Ustok - (malzeme.Mmiktar * siparisPorsiyonu);
                        if (0 < yenistok && yenistok <= depoUrun.Uminstok)
                        {
                            MessageBox.Show("Bu sipariş için yeterli stoğunuz yoktur. Lütfen yenileyin.");
                            return;
                        }
                        else if (yenistok <= 0)
                        {
                            MessageBox.Show("Ürün stoğunuz bitmiş bulunmaktadır. Lütfen yenileyin.");
                            return;
                        }
                        else
                        {
                            guncelUrun.Ustok = yenistok;
                        }
                        guncelUrun.Uminstok = depoUrun.Uminstok;
                        guncelUrun.Ukalori = depoUrun.Ukalori;
                        guncelUrun.Ufiyat = depoUrun.Ufiyat;

                        d.sil(index);
                        d.ekle(guncelUrun);

                        List<string> depoBilgileri = new List<string>();

                        foreach (var urun in d.depoYazdir())
                        {
                            depoBilgileri.Add(urun.depokayit());
                        }

                        File.WriteAllLines(dosyayolu1, depoBilgileri);
                    }
                }
            }

            // checkedSiparisBox1 içeriğini güncelle
            checkedSiparisBox1.Items.Add(siparisSatir);

            MessageBox.Show("Sipariş eklendi ve malzemeler eksiltildi.");
            textBox13.Text = textBox14.Text = "";
        }

        private void siparissil_Click(object sender, EventArgs e)//tamam
        {
            if (checkedSiparisBox1.SelectedItem == null)
            {
                MessageBox.Show("Lütfen iptal edilecek bir sipariş seçin.");
                return;
            }

            int seciliSiparisIndex = checkedSiparisBox1.SelectedIndex;
            siparis seciliSiparis = s.siparisYazdir()[seciliSiparisIndex];

            // Siparişi sipariş listesinden ve checkedSiparisBox1'den sil
            s.sil(seciliSiparisIndex);
            checkedSiparisBox1.Items.RemoveAt(seciliSiparisIndex);

            // İlgili sipariş bilgisini siparis.txt'den sil
            List<string> siparisLines = File.ReadAllLines(dosyayolu4).ToList();
            List<string> updatedSiparisLines = new List<string>();

            foreach (string line in siparisLines)
            {
                string[] parts = line.Split(' ');
                if (parts.Length >= 1 && parts[0] != seciliSiparis.Skod)
                {
                    updatedSiparisLines.Add(line);
                }
            }

            File.WriteAllLines(dosyayolu4, updatedSiparisLines);

            // Siparişin içeriğine göre stoğu geri ekle
            foreach (malzeme malzeme in t.malzemeYazdir())
            {
                if (malzeme.Ykod == seciliSiparis.Ykod)
                {
                    urun depoUrun = d.urunAra(malzeme.Ukod);
                    if (depoUrun != null)
                    {
                        float yeniStok = depoUrun.Ustok + (malzeme.Mmiktar * seciliSiparis.Skisi);
                        depoUrun.Ustok = yeniStok;

                        int index = 0;
                        for (int i = 0; i < d.depoYazdir().Count; i++)
                        {
                            if (d.depoYazdir()[i] == depoUrun)
                            {
                                index = i;
                                break;
                            }
                        }

                        d.sil(index);
                        d.ekle(depoUrun);

                        List<string> depoBilgileri = new List<string>();
                        foreach (var urun in d.depoYazdir())
                        {
                            depoBilgileri.Add(urun.depokayit());
                        }

                        File.WriteAllLines(dosyayolu1, depoBilgileri);
                    }
                }
            }

            MessageBox.Show("Sipariş iptal edildi, stoklar güncellendi.");
        }

        private void muhasebe_Click(object sender, EventArgs e)//tamam
        {
            float toplamCiro = 0;
            float toplamKar = 0;
            float toplamKdv = 0;
            float toplamMaliyet = 0;

            foreach (siparis siparis in s.siparisYazdir())
            {
                toplamCiro += siparis.Sfiyat;
                toplamKar += siparis.Skar;
                toplamKdv += siparis.Sfiyat * siparis.SkdvOrani / 100;
            }

            foreach (urun urun in d.depoYazdir())
            {
                float urunMaliyet = urun.Ufiyat * urun.Ustok;
                toplamMaliyet += urunMaliyet;
            }

            float kdvPayi = toplamKdv;
            float netKar = toplamKar - toplamMaliyet;

            textBox15.Text = toplamCiro.ToString("0.00");
            textBox16.Text = kdvPayi.ToString("0.00");
            textBox17.Text = toplamMaliyet.ToString("0.00");
            textBox18.Text = netKar.ToString("0.00");
            textBox19.Text = toplamKar.ToString("0.00");
        }
    }
}
