using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace SayiBulmaOyunuGelismis
{
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Kullanıcıya gösterilecek olan liste (aranan sayıyı içerebilir)
        /// </summary>
        List<int> anaListe = new List<int>();

        /// <summary>
        /// Kullanıcıya gösterilmeyecek olan liste (aranan sayıyı içerebilir)
        /// </summary>
        List<int> geciciListe = new List<int>();

        /// <summary>
        /// Kullanıcının reddettiği sayılar (aranan sayıyı içermeyen liste)
        /// </summary>
        List<int> dislananlarListesi = new List<int>();

        /// <summary>
        /// Random sayılar üretirken kullanılan Random nesnesi
        /// </summary>
        Random rnd = new Random();

        /// <summary>
        /// Sayıyı bulurken denenen adım sayısı
        /// </summary>
        int toplamAdim = 0;

        public void listeyiTemizle(bool sanalListeleriTemizle = false)
        {
            s_panel.Children.Clear();
            s_panel2.Children.Clear();
            s_panel3.Children.Clear();

            if (sanalListeleriTemizle)
            {
                anaListe.Clear();
                geciciListe.Clear();
                dislananlarListesi.Clear();
            }
        }

        //Verilen listeyi Stackpanel'in içine listeler ve listenin elemanı 25'ten az ise eleman sayısını 25'e tamamlar.
        public void listele(List<int> listRef)
        {
            List<int> _list = new List<int>(listRef);
            listeyiTemizle();

            //Listenin eleman sayısını dislananlar listesinden ekleme yaparak 25'e tamamlıyoruz.
            int gerekenItemSayisi = 25 - _list.Count;
            for (int i = 0; i < gerekenItemSayisi; i++)
            {
                int index = rnd.Next(dislananlarListesi.Count);
                int eklenecek = dislananlarListesi[index];

                while (_list.Contains(eklenecek))
                {
                    index = rnd.Next(dislananlarListesi.Count);
                    eklenecek = dislananlarListesi[index];
                }
                _list.Add(eklenecek);
            }

            _list.Sort();

            double _thicknes = 0.5;
            string _liste_degeri;
            string _path = System.IO.Directory.GetCurrentDirectory() + @"\images\";

            for (int i = 0; i < _list.Count; i++)
            {
                if (s_panel.Children.Count < 9)
                {
                    Image image = new Image();
                    image.Height = 30;
                    image.Margin = new Thickness(_thicknes);
                    _liste_degeri = Convert.ToString(_list[i]);
                    BitmapImage s = new BitmapImage(new Uri(_path + _liste_degeri + ".jpg"));
                    image.Source = s;
                    s_panel.Children.Add(image);
                }
                else
                {
                    if (s_panel2.Children.Count < 9)
                    {
                        Image image = new Image();
                        image.Height = 30; //24
                        image.Margin = new Thickness(_thicknes);
                        _liste_degeri = Convert.ToString(_list[i]);
                        BitmapImage s = new BitmapImage(new Uri(_path + _liste_degeri + ".jpg"));
                        image.Source = s;
                        s_panel2.Children.Add(image);
                    }
                    else
                    {
                        Image image = new Image();
                        image.Height = 30;
                        image.Margin = new Thickness(_thicknes);
                        _liste_degeri = Convert.ToString(_list[i]);
                        BitmapImage s = new BitmapImage(new Uri(_path + _liste_degeri + ".jpg"));
                        image.Source = s;
                        s_panel3.Children.Add(image);
                    }
                }
            }
        }

        /// <summary>
        /// Kullanıcı aklındaki sayının listede olup olmadığını bildirmek için butona bastığında burası çağrılır.
        /// </summary>
        /// <param name="sayiListedeVarMi">Bastığı buton Var butonu ise True, Yok butonu ise False olması gerekir.</param>
        void kullaniciYaniti(bool sayiListedeVarMi)
        {
            toplamAdim++;

            if (sayiListedeVarMi)
            {
                for (int i = 0; i < geciciListe.Count; i++)
                {
                    dislananlarListesi.Add(geciciListe[i]);
                }

                geciciListe.Clear();
                tahminleriListele();
            }
            else
            {
                for (int i = 0; i < anaListe.Count; i++)
                {
                    dislananlarListesi.Add(anaListe[i]);
                }

                anaListe.Clear();

                for (int i = 0; i < geciciListe.Count; i++)
                {
                    anaListe.Add(geciciListe[i]);
                }

                geciciListe.Clear();
                tahminleriListele();
            }
        }

        /// <summary>
        /// Kullanıcının aklındaki sayıyı bulmak için kullanıcıya sormamız gereken sayıları listeler
        /// </summary>
        private void tahminleriListele()
        {
            if (anaListe.Count == 1)
            {
                oyunuBitir(anaListe[0]);
                return;
            }

            int tahminSayisi = anaListe.Count / 2;

            anaListe = anaListe.OrderBy(item => rnd.Next()).ToList(); //İyice karıştır :)

            for (int i = 0; i < tahminSayisi; i++)
            {
                int index = rnd.Next(tahminSayisi);
                geciciListe.Add(anaListe[index]);
                anaListe.RemoveAt(index);
            }

            listele(anaListe);
        }

        /// <summary>
        /// Kullanıcının aklındaki sayıyı bulunca bu metot çağırılır.
        /// </summary>
        /// <param name="bulunanSayi">Bulunan sayı bu parametre ile aktarılır.</param>
        public void oyunuBitir(int bulunanSayi)
        {
            listeyiTemizle(true);

            label_info.Visibility = Visibility.Visible;

            btnStart.IsEnabled = true;
            btnStart.Visibility = Visibility.Visible;

            btn_yes.IsEnabled = false;
            btn_no.IsEnabled = false;
            btn_yes.Visibility = Visibility.Hidden;
            btn_no.Visibility = Visibility.Hidden;

            MessageBox.Show(string.Format("Aklınızda tuttuğunuz {0} sayısı {1} adımda bulundu.", bulunanSayi.ToString(), toplamAdim.ToString()), "Aklınızdaki Sayı", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        /// <summary>
        /// Oyunun başlama butonuna basıldığında bu metot çağrılır ve gerekli işlemler bu metotta yapılır.
        /// </summary>
        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            label_info.Visibility = Visibility.Hidden;

            btnStart.IsEnabled = false;
            btnStart.Visibility = Visibility.Hidden;

            btn_yes.IsEnabled = true;
            btn_no.IsEnabled = true;
            btn_yes.Visibility = Visibility.Visible;
            btn_no.Visibility = Visibility.Visible;

            listeyiTemizle(true);

            toplamAdim = 0;

            //Ana Listeyi 1'den 50'ye kadar sayılarla doldur.
            for (int i = 1; i <= 50; i++)
                anaListe.Add(i);

            tahminleriListele();
        }

        private void btn_yes_MouseDown(object sender, MouseButtonEventArgs e)
        {
            btn_yes.Source = new BitmapImage(new Uri(@"pack://application:,,,/Resources/yes_down.bmp"));
        }

        private void btn_yes_MouseUp(object sender, MouseButtonEventArgs e)
        {
            btn_yes.Source = new BitmapImage(new Uri(@"pack://application:,,,/Resources/yes.ico"));

            kullaniciYaniti(true);
        }

        private void btn_no_MouseDown(object sender, MouseButtonEventArgs e)
        {
            btn_no.Source = new BitmapImage(new Uri(@"pack://application:,,,/Resources/no_down.bmp"));
        }

        private void btn_no_MouseUp(object sender, MouseButtonEventArgs e)
        {
            btn_no.Source = new BitmapImage(new Uri(@"pack://application:,,,/Resources/no.ico"));

            kullaniciYaniti(false);
        }

    }
}