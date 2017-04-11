using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace SayiBulmaOyunu
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int baslangic = 0;
        bool tutulan_deger_cift;
        int girilen;

        #region //Listeler public static türünden oluşturuluyor.
        public static List<int> tek = new List<int>();
        public static List<int> cift = new List<int>();
        public static List<int> a_tek_1 = new List<int>();   //1-3-5-7-9-11-13-15-17-19-21-23         {12} --> tek
        public static List<int> a_tek_2 = new List<int>();   //25-27-29-31-33-35-37-39-41-43-45-47-49 {13} --> tek
        public static List<int> b_tek_1 = new List<int>();   //1-3-5-7-9-11         {6} --> a_tek_1
        public static List<int> b_tek_2 = new List<int>();   //13-15-17-19-21-23    {6} --> a_tek_1
        public static List<int> b_tek_3 = new List<int>();   //25-27-29-31-33-35    {6} --> a_tek_2
        public static List<int> b_tek_4 = new List<int>();   //37-39-41-43-45-47-49 {7} --> a_tek_2
        public static List<int> c_tek_1 = new List<int>();   //1-3-5        {3} --> b_tek_1
        public static List<int> c_tek_2 = new List<int>();   //7-9-11       {3} --> b_tek_1
        public static List<int> c_tek_3 = new List<int>();   //13-15-17     {3} --> b_tek_2
        public static List<int> c_tek_4 = new List<int>();   //19-21-23     {3} --> b_tek_2
        public static List<int> c_tek_5 = new List<int>();   //25-27-29     {3} --> b_tek_3
        public static List<int> c_tek_6 = new List<int>();   //31-33-35     {3} --> b_tek_3
        public static List<int> c_tek_7 = new List<int>();   //37-39-41     {3} --> b_tek_4
        public static List<int> c_tek_8 = new List<int>();   //43-45-47-49  {4} --> b_tek_4
        public static List<int> d_tek_1 = new List<int>();   //1         {1} --> c_tek_1
        public static List<int> d_tek_2 = new List<int>();   //3-5       {2} --> c_tek_1
        public static List<int> d_tek_3 = new List<int>();   //7         {1} --> c_tek_2
        public static List<int> d_tek_4 = new List<int>();   //9-11      {2} --> c_tek_2
        public static List<int> d_tek_5 = new List<int>();   //13        {1} --> c_tek_3
        public static List<int> d_tek_6 = new List<int>();   //15-17     {2} --> c_tek_3
        public static List<int> d_tek_7 = new List<int>();   //19        {1} --> c_tek_4
        public static List<int> d_tek_8 = new List<int>();   //21-23     {2} --> c_tek_4
        public static List<int> d_tek_9 = new List<int>();   //25        {1} --> c_tek_5
        public static List<int> d_tek_10 = new List<int>();  //27-29     {2} --> c_tek_5
        public static List<int> d_tek_11 = new List<int>();  //31        {1} --> c_tek_6
        public static List<int> d_tek_12 = new List<int>();  //33-35     {2} --> c_tek_6
        public static List<int> d_tek_13 = new List<int>();  //37        {1} --> c_tek_7
        public static List<int> d_tek_14 = new List<int>();  //39-41     {2} --> c_tek_7
        public static List<int> d_tek_15 = new List<int>();  //43-45     {2} --> c_tek_8
        public static List<int> d_tek_16 = new List<int>();  //47-49     {2} --> c_tek_8
        public static List<int> e_tek_1 = new List<int>();   //3          {1} --> d_tek_2
        public static List<int> e_tek_2 = new List<int>();   //5          {1} --> d_tek_2
        public static List<int> e_tek_3 = new List<int>();   //9          {1} --> d_tek_4
        public static List<int> e_tek_4 = new List<int>();   //11         {1} --> d_tek_4
        public static List<int> e_tek_5 = new List<int>();   //15         {1} --> d_tek_6
        public static List<int> e_tek_6 = new List<int>();   //17         {1} --> d_tek_6
        public static List<int> e_tek_7 = new List<int>();   //21         {1} --> d_tek_8
        public static List<int> e_tek_8 = new List<int>();   //23         {1} --> d_tek_8
        public static List<int> e_tek_9 = new List<int>();   //27         {1} --> d_tek_10
        public static List<int> e_tek_10 = new List<int>();  //29         {1} --> d_tek_12
        public static List<int> e_tek_11 = new List<int>();  //33         {1} --> d_tek_12
        public static List<int> e_tek_12 = new List<int>();  //35         {1} --> d_tek_10
        public static List<int> e_tek_13 = new List<int>();  //39         {1} --> d_tek_14
        public static List<int> e_tek_14 = new List<int>();  //41         {1} --> d_tek_14
        public static List<int> e_tek_15 = new List<int>();  //43         {1} --> d_tek_15
        public static List<int> e_tek_16 = new List<int>();  //45         {1} --> d_tek_15
        public static List<int> e_tek_17 = new List<int>();  //47         {1} --> d_tek_16
        public static List<int> e_tek_18 = new List<int>();  //49         {1} --> d_tek_16

        //diğer tüm değer kümeleri oluşturuluyor

        // ! ÇİFT ! 
        public static List<int> a_cift_1 = new List<int>(); //2-4-6-8-10-12-14-16-18-20-22-24-26     {13} --> çift
        public static List<int> a_cift_2 = new List<int>(); //28-30-32-34-36-38-40-42-44-46-48-50    {12} --> çift
        public static List<int> b_cift_1 = new List<int>(); //2-4-6-8-10-12-14                {7} --> a_cift_1
        public static List<int> b_cift_2 = new List<int>(); //16-18-20-22-24-26               {6} --> a_cift_1
        public static List<int> b_cift_3 = new List<int>(); //28-30-32-34-36-38               {6} --> a_cift_2
        public static List<int> b_cift_4 = new List<int>(); //40-42-44-46-48-50               {6} --> a_cift_2
        public static List<int> c_cift_1 = new List<int>(); //2-4-6-8                         {4} --> b_cift_1
        public static List<int> c_cift_2 = new List<int>(); //10-12-14                        {3} --> b_cift_1
        public static List<int> c_cift_3 = new List<int>(); //16-18-20                        {3} --> b_cift_2 
        public static List<int> c_cift_4 = new List<int>(); //22-24-26                        {3} --> b_cift_2
        public static List<int> c_cift_5 = new List<int>(); //28-30-32                        {3} --> b_cift_3
        public static List<int> c_cift_6 = new List<int>(); //34-36-38                        {3} --> b_cift_3
        public static List<int> c_cift_7 = new List<int>(); //40-42-44                        {3} --> b_cift_4
        public static List<int> c_cift_8 = new List<int>(); //46-48-50                        {3} --> b_cift_4
        public static List<int> d_cift_1 = new List<int>();    //2-4        {2} --> c_cift_1
        public static List<int> d_cift_2 = new List<int>();    //6-8        {2} --> c_cift_1
        public static List<int> d_cift_3 = new List<int>();    //10-12      {2} --> c_cift_2
        public static List<int> d_cift_4 = new List<int>();    //14         {1} --> c_cift_2
        public static List<int> d_cift_5 = new List<int>();    //16-18      {2} --> c_cift_3
        public static List<int> d_cift_6 = new List<int>();    //20         {1} --> c_cift_3
        public static List<int> d_cift_7 = new List<int>();    //22-24      {2} --> c_cift_4
        public static List<int> d_cift_8 = new List<int>();    //26         {1} --> c_cift_4
        public static List<int> d_cift_9 = new List<int>();    //28-30      {2} --> c_cift_5
        public static List<int> d_cift_10 = new List<int>();   //32         {1} --> c_cift_5
        public static List<int> d_cift_11 = new List<int>();   //34-36      {2} --> c_cift_6
        public static List<int> d_cift_12 = new List<int>();   //38         {1} --> c_cift_6
        public static List<int> d_cift_13 = new List<int>();   //40-42      {2} --> c_cift_7
        public static List<int> d_cift_14 = new List<int>();   //44         {1} --> c_cift_7
        public static List<int> d_cift_15 = new List<int>();   //46-48      {2} --> c_cift_8
        public static List<int> d_cift_16 = new List<int>();   //50         {1} --> c_cift_8
        public static List<int> e_cift_1 = new List<int>();     //2           {1} --> d_cift_1
        public static List<int> e_cift_2 = new List<int>();     //4           {1} --> d_cift_1
        public static List<int> e_cift_3 = new List<int>();     //6           {1} --> d_cift_2
        public static List<int> e_cift_4 = new List<int>();     //8           {1} --> d_cift_2
        public static List<int> e_cift_5 = new List<int>();     //10          {1} --> d_cift_3
        public static List<int> e_cift_6 = new List<int>();     //12          {1} --> d_cift_3
        public static List<int> e_cift_7 = new List<int>();     //16          {1} --> d_cift_5
        public static List<int> e_cift_8 = new List<int>();     //18          {1} --> d_cift_5
        public static List<int> e_cift_9 = new List<int>();     //22          {1} --> d_cift_7
        public static List<int> e_cift_10 = new List<int>();    //24          {1} --> d_cift_7
        public static List<int> e_cift_11 = new List<int>();    //28          {1} --> d_cift_9
        public static List<int> e_cift_12 = new List<int>();    //30          {1} --> d_cift_9
        public static List<int> e_cift_13 = new List<int>();    //34          {1} --> d_cift_11
        public static List<int> e_cift_14 = new List<int>();    //36          {1} --> d_cift_11
        public static List<int> e_cift_15 = new List<int>();    //40          {1} --> d_cift_13
        public static List<int> e_cift_16 = new List<int>();    //42          {1} --> d_cift_13
        public static List<int> e_cift_17 = new List<int>();    //46          {1} --> d_cift_15
        public static List<int> e_cift_18 = new List<int>();    //48          {1} --> d_cift_15
        #endregion listeler public static olarak tanımlanıyor.

        public static void kumeleri_olustur()
        {
            #region        // tek ve çift sayılar döngü ile kümeleniyor.
            int tekmi = 0;
            for (int a = 1; a <= 50; a++)
            {
                tekmi = a / 2;

                if (tekmi * 2 != a)  //tek sayıları al
                {
                    tek.Add(a);
                }
                else                //çift sayıları al
                {
                    cift.Add(a);
                }
            }
            // tek ve çift sayılar döngü ile kümeleniyor.
            #endregion     //----------------------------------------------------------------------------------------

            #region // DEĞERLER AKTARILIYOR.... --->

            // a_tek_1
            a_tek_1.Add(1);
            a_tek_1.Add(3);
            a_tek_1.Add(5);
            a_tek_1.Add(7);
            a_tek_1.Add(9);
            a_tek_1.Add(11);
            a_tek_1.Add(13);
            a_tek_1.Add(15);
            a_tek_1.Add(17);
            a_tek_1.Add(19);
            a_tek_1.Add(21);
            a_tek_1.Add(23);

            //a_tek_2
            a_tek_2.Add(25);
            a_tek_2.Add(27);
            a_tek_2.Add(29);
            a_tek_2.Add(31);
            a_tek_2.Add(33);
            a_tek_2.Add(35);
            a_tek_2.Add(37);
            a_tek_2.Add(39);
            a_tek_2.Add(41);
            a_tek_2.Add(43);
            a_tek_2.Add(45);
            a_tek_2.Add(47);
            a_tek_2.Add(49);

            //b_tek_1
            b_tek_1.Add(1);
            b_tek_1.Add(3);
            b_tek_1.Add(5);
            b_tek_1.Add(7);
            b_tek_1.Add(9);
            b_tek_1.Add(11);

            //b_tek_2
            b_tek_2.Add(13);
            b_tek_2.Add(15);
            b_tek_2.Add(17);
            b_tek_2.Add(19);
            b_tek_2.Add(21);
            b_tek_2.Add(23);

            //b_tek_3
            b_tek_3.Add(25);
            b_tek_3.Add(27);
            b_tek_3.Add(29);
            b_tek_3.Add(31);
            b_tek_3.Add(33);
            b_tek_3.Add(35);

            //b_tek_4
            b_tek_4.Add(37);
            b_tek_4.Add(39);
            b_tek_4.Add(41);
            b_tek_4.Add(43);
            b_tek_4.Add(45);
            b_tek_4.Add(47);
            b_tek_4.Add(49);

            //c_tek_1
            c_tek_1.Add(1);
            c_tek_1.Add(3);
            c_tek_1.Add(5);

            //c_tek_2
            b_tek_4.Add(7);
            b_tek_4.Add(9);
            b_tek_4.Add(11);

            //c_tek_3
            c_tek_3.Add(13);
            c_tek_3.Add(15);
            c_tek_3.Add(17);

            //c_tek_4
            c_tek_4.Add(19);
            c_tek_4.Add(21);
            c_tek_4.Add(23);

            //c_Tek_5
            c_tek_5.Add(25);
            c_tek_5.Add(27);
            c_tek_5.Add(29);

            //c_tek_6
            b_tek_4.Add(31);
            b_tek_4.Add(33);
            b_tek_4.Add(35);

            //c_Tek_7
            c_tek_7.Add(37);
            c_tek_7.Add(39);
            c_tek_7.Add(41);

            //c_tek_8
            c_tek_8.Add(43);
            c_tek_8.Add(45);
            c_tek_8.Add(47);
            c_tek_8.Add(49);

            //d_tek_1
            d_tek_1.Add(1);

            //d_tek_2
            d_tek_2.Add(3);
            d_tek_2.Add(5);

            //d_tek_3
            d_tek_3.Add(7);

            //d_tek_4
            d_tek_4.Add(9);
            d_tek_4.Add(11);

            //d_tek_5
            d_tek_5.Add(13);

            //d_tek_6
            d_tek_6.Add(15);
            d_tek_6.Add(17);

            //d_tek_7
            d_tek_7.Add(19);

            //d_tek_8
            d_tek_8.Add(21);
            d_tek_8.Add(23);

            //d_tek_9
            d_tek_9.Add(25);

            //d_tek_10
            d_tek_10.Add(27);
            d_tek_10.Add(29);

            //d_tek_11
            d_tek_11.Add(31);

            //d_tek_12
            d_tek_12.Add(33);
            d_tek_12.Add(35);

            //d_tek_13
            d_tek_13.Add(37);

            //d_tek_14
            d_tek_14.Add(39);
            d_tek_14.Add(41);

            //d_tek_15
            d_tek_15.Add(43);
            d_tek_15.Add(45);

            //d_tek_16
            d_tek_16.Add(47);
            d_tek_16.Add(49);

            //e_tek_1
            e_tek_1.Add(3);

            //e_tek_2
            e_tek_2.Add(5);

            //e_tek_3
            e_tek_3.Add(9);

            //e_tek_4
            e_tek_4.Add(11);

            //e_tek_5
            e_tek_5.Add(15);

            //e_tek_6
            e_tek_6.Add(17);

            //e_tek_7
            e_tek_7.Add(21);

            //e_tek_8
            e_tek_8.Add(23);
            //e_tek_9
            e_tek_9.Add(27);

            //e_tek_10
            e_tek_10.Add(29);

            //e_tek_11
            e_tek_11.Add(33);

            //e_tek_12
            e_tek_12.Add(35);

            //e_tek_13
            e_tek_13.Add(39);

            //e_tek_14
            e_tek_14.Add(41);

            //e_tek_15
            e_tek_15.Add(43);

            //e_tek_16
            e_tek_16.Add(45);

            //e_tek_17
            e_tek_17.Add(47);

            //e_tek_18
            e_tek_18.Add(49);

            // çift değerler giriliyor..

            //a_cift_1
            a_cift_1.Add(2);
            a_cift_1.Add(4);
            a_cift_1.Add(6);
            a_cift_1.Add(8);
            a_cift_1.Add(10);
            a_cift_1.Add(12);
            a_cift_1.Add(14);
            a_cift_1.Add(16);
            a_cift_1.Add(18);
            a_cift_1.Add(20);
            a_cift_1.Add(22);
            a_cift_1.Add(24);
            a_cift_1.Add(26);

            //a_cift_2
            a_cift_2.Add(28);
            a_cift_2.Add(30);
            a_cift_2.Add(32);
            a_cift_2.Add(34);
            a_cift_2.Add(36);
            a_cift_2.Add(38);
            a_cift_2.Add(40);
            a_cift_2.Add(42);
            a_cift_2.Add(44);
            a_cift_2.Add(46);
            a_cift_2.Add(48);
            a_cift_2.Add(50);

            //b_cift_1
            b_cift_1.Add(2);
            b_cift_1.Add(4);
            b_cift_1.Add(6);
            b_cift_1.Add(8);
            b_cift_1.Add(10);
            b_cift_1.Add(12);
            b_cift_1.Add(14);

            //b_cift_2
            b_cift_2.Add(16);
            b_cift_2.Add(18);
            b_cift_2.Add(20);
            b_cift_2.Add(22);
            b_cift_2.Add(24);
            b_cift_2.Add(26);

            //b_cift_3
            b_cift_3.Add(28);
            b_cift_3.Add(30);
            b_cift_3.Add(32);
            b_cift_3.Add(34);
            b_cift_3.Add(36);
            b_cift_3.Add(38);

            //b_cift_4
            b_cift_4.Add(40);
            b_cift_4.Add(42);
            b_cift_4.Add(44);
            b_cift_4.Add(46);
            b_cift_4.Add(48);
            b_cift_4.Add(50);

            //c_cift_1
            c_cift_1.Add(2);
            c_cift_1.Add(4);
            c_cift_1.Add(6);
            c_cift_1.Add(8);

            //c_cift_2
            c_cift_2.Add(10);
            c_cift_2.Add(12);
            c_cift_2.Add(14);

            //c_cift_3
            c_cift_3.Add(16);
            c_cift_3.Add(18);
            c_cift_3.Add(20);

            //c_cift_4
            c_cift_4.Add(22);
            c_cift_4.Add(24);
            c_cift_4.Add(26);

            //c_cift_5
            c_cift_5.Add(28);
            c_cift_5.Add(30);
            c_cift_5.Add(32);

            //c_cift_6
            c_cift_6.Add(34);
            c_cift_6.Add(36);
            c_cift_6.Add(38);

            //c_cift_7
            c_cift_7.Add(40);
            c_cift_7.Add(42);
            c_cift_7.Add(44);

            //c_cift_8
            c_cift_8.Add(46);
            c_cift_8.Add(48);
            c_cift_8.Add(50);

            //d_cift_1
            d_cift_1.Add(2);
            d_cift_1.Add(4);

            //d_cift_2
            d_cift_2.Add(6);
            d_cift_2.Add(8);

            //d_cift_3
            d_cift_3.Add(10);
            d_cift_3.Add(12);

            //d_cift_4
            d_cift_4.Add(14);

            //d_cift_5
            d_cift_5.Add(16);
            d_cift_5.Add(18);

            //d_cift_6
            d_cift_6.Add(20);

            //d_cift_7
            d_cift_7.Add(22);
            d_cift_7.Add(24);

            //d_cift_8
            d_cift_8.Add(26);

            //d_cift_9
            d_cift_9.Add(28);
            d_cift_9.Add(30);

            //d_cift_10
            d_cift_10.Add(32);

            //d_cift_11
            d_cift_11.Add(34);
            d_cift_11.Add(36);

            //d_cift_12
            d_cift_12.Add(38);

            //d_cift_13
            d_cift_13.Add(40);
            d_cift_13.Add(42);

            //d_cift_14
            d_cift_14.Add(44);

            //d_cift_15
            d_cift_15.Add(46);
            d_cift_15.Add(48);

            //d_cift_16
            d_cift_16.Add(50);

            //e_cift_1
            e_cift_1.Add(2);

            //e_cift_2
            e_cift_2.Add(4);

            //e_cift_3
            e_cift_3.Add(6);

            //e_cift_4
            e_cift_4.Add(8);

            //e_cift_5
            e_cift_5.Add(10);

            //e_cift_6
            e_cift_6.Add(12);

            //e_cift_7
            e_cift_7.Add(16);

            //e_cift_8
            e_cift_8.Add(18);

            //e_cift_9
            e_cift_9.Add(22);

            //e_cift_10
            e_cift_10.Add(24);

            //e_cift_11
            e_cift_11.Add(28);

            //e_cift_12
            e_cift_12.Add(30);

            //e_cift_13
            e_cift_13.Add(34);

            //e_cift_14
            e_cift_14.Add(36);

            //e_cift_15
            e_cift_15.Add(40);

            //e_cift_16
            e_cift_16.Add(42);

            //e_cift_17
            e_cift_17.Add(46);

            //e_cift_18
            e_cift_18.Add(48);
            #endregion
        }

        public void thumb_ekle(ListBox _list)
        {
            s_panel.Children.Clear();
            s_panel2.Children.Clear();
            s_panel3.Children.Clear();

            double _thicknes = 0.5;
            string _liste_degeri;
            string _path = System.IO.Directory.GetCurrentDirectory() + @"\images\";

            for (int i = 0; i < _list.Items.Count; i++)
            {
                if (s_panel.Children.Count < 9)
                {
                    Image image = new Image();
                    image.Height = 24;
                    image.Margin = new Thickness(_thicknes);
                    _liste_degeri = Convert.ToString(_list.Items[i]);
                    BitmapImage s = new BitmapImage(new Uri(_path + _liste_degeri + ".jpg"));
                    image.Source = s;
                    s_panel.Children.Add(image);
                }
                else
                {
                    if (s_panel2.Children.Count < 9)
                    {
                        Image image = new Image();
                        image.Height = 24; //24
                        image.Margin = new Thickness(_thicknes);
                        _liste_degeri = Convert.ToString(_list.Items[i]);
                        BitmapImage s = new BitmapImage(new Uri(_path + _liste_degeri + ".jpg"));
                        image.Source = s;
                        s_panel2.Children.Add(image);
                    }
                    else
                    {
                        Image image = new Image();
                        image.Height = 24;
                        image.Margin = new Thickness(_thicknes);
                        _liste_degeri = Convert.ToString(_list.Items[i]);
                        BitmapImage s = new BitmapImage(new Uri(_path + _liste_degeri + ".jpg"));
                        image.Source = s;
                        s_panel3.Children.Add(image);
                    }
                }
            }
        }

        public void sirala()
        {
            degerKutusu.Items.SortDescriptions.Add(new System.ComponentModel.SortDescription("",
                System.ComponentModel.ListSortDirection.Ascending));
        }

        public void karistir_final()
        {
            string alinan;
            int _rast;

            yedek_liste.Items.Clear();

            for (int b = 0; b < degerKutusu.Items.Count; b++)
            {
                yedek_liste.Items.Add(degerKutusu.Items[b]);
            }
            degerKutusu.Items.Clear();
            Random rnd = new Random();
            _rast = rnd.Next(0, yedek_liste.Items.Count);
            alinan = Convert.ToString(yedek_liste.Items[_rast]);

            for (int a = 0; a < yedek_liste.Items.Count; a++)
            {
                while (degerKutusu.Items.Contains(alinan))
                {
                    alinan = Convert.ToString(yedek_liste.Items[rnd.Next(yedek_liste.Items.Count)]);
                }

                degerKutusu.Items.Add(alinan);
            }
        }

        public void ozel_liste_olustur()
        {
            int rnd1 = 0;
            int rnd2 = 0;
            int list_max = degerKutusu.Items.Count;

            if (tutulan_deger_cift == true) // min 25
            {
                for (int a = 0; a < (25 - list_max); a++)
                {
                    Random r1 = new Random();
                    Random r2 = new Random();

                    rnd1 = r1.Next(degerKutusu.Items.Count + 1);
                    rnd2 = r2.Next(25);

                    girilen = tek[rnd2];

                    while (degerKutusu.Items.Contains(girilen))
                    {
                        rnd1 = r1.Next(degerKutusu.Items.Count + 1);
                        rnd2 = r2.Next(25);

                        girilen = tek[rnd2];
                    }
                    degerKutusu.Items.Insert(rnd1, tek[rnd2]);
                }
            }
            else //min 25
            {
                for (int a = 0; a < (25 - list_max); a++)
                {
                    Random r1 = new Random();
                    Random r2 = new Random();
                    rnd1 = r1.Next(degerKutusu.Items.Count + 1);
                    rnd2 = r2.Next(25);
                    girilen = cift[rnd2];

                    while (degerKutusu.Items.Contains(girilen))
                    {
                        rnd1 = r1.Next(degerKutusu.Items.Count + 1);
                        rnd2 = r2.Next(25);
                        girilen = cift[rnd2];
                    }
                    degerKutusu.Items.Insert(rnd1, cift[rnd2]);
                }
            }
            sirala();
        }

        public void oyunuBitir(int bulunanSayi)
        {
            MessageBox.Show("Aklınızdaki Sayı " + bulunanSayi.ToString(), "Bulunan Sayı", MessageBoxButton.OK, MessageBoxImage.Information);

            btnStart.IsEnabled = true;
            btnStart.Visibility = Visibility.Visible;

            btn_yes.IsEnabled = false;
            btn_no.IsEnabled = false;
            btn_yes.Visibility = Visibility.Hidden;
            btn_no.Visibility = Visibility.Hidden;
        }

        public async Task<bool> cevap(List<int> liste)
        {
            #region Sorgulama kodu

            degerKutusu.Items.Clear();

            for (int i = 0; i < liste.Count; i++)
            {
                degerKutusu.Items.Add(liste[i]);
            }

            ozel_liste_olustur();

            // karistir_final(); // veya bunun yerine sıralı liste olutur. vd_sirala*

            thumb_ekle(degerKutusu);

            if (await waitForResponse())
            {
                return true;
            }
            else
            {
                return false;
            }
            #endregion
        }

        public async void gameLoop()
        {
            if (await cevap(tek) == true) // Tek sayılar üzerindeki algoritma
            { //+
                tutulan_deger_cift = false;

                if (await cevap(a_tek_1) == true) // a_tek_1 için
                {
                    if (await cevap(b_tek_1) == true) // 1-3-5-7-9-11
                    {
                        if (await cevap(c_tek_1) == true) //1-3-5
                        {
                            if (await cevap(d_tek_2) == true) //3-5
                            {
                                if (await cevap(e_tek_1) == true) //3
                                {
                                    oyunuBitir(3);
                                }
                                else //5
                                {
                                    oyunuBitir(5);
                                }
                            }
                            else //1
                            {
                                oyunuBitir(1);
                            }
                        }
                        else
                        {
                            if (await cevap(d_tek_4) == true) //9-11
                            {
                                if (await cevap(e_tek_3) == true) //9
                                {
                                    oyunuBitir(9);
                                }
                                else //11
                                {
                                    oyunuBitir(11);
                                }
                            }
                            else //7
                            {
                                oyunuBitir(7);
                            }
                        }
                    }
                    else
                    {

                        if (await cevap(c_tek_3) == true) //13-15-17
                        {
                            if (await cevap(d_tek_6) == true) //15-17
                            {
                                if (await cevap(e_tek_5) == true) //15
                                {
                                    oyunuBitir(15);
                                }
                                else //17
                                {
                                    oyunuBitir(17);
                                }
                            }
                            else //13
                            {
                                oyunuBitir(13);
                            }
                        }
                        else //19-21-23
                        {
                            if (await cevap(d_tek_8) == true) //21-23
                            {
                                if (await cevap(e_tek_7) == true) //21
                                {
                                    oyunuBitir(21);
                                }
                                else //23
                                {
                                    oyunuBitir(23);
                                }
                            }
                            else //19
                            {
                                oyunuBitir(19);
                            }
                        }

                    }
                }

                else //a_tek_2 için
                {
                    if (await cevap(b_tek_3) == true) //25-27-29-31-33-35
                    {
                        if (await cevap(c_tek_5) == true) //25-27-29
                        {
                            if (await cevap(d_tek_10) == true) //27-29
                            {
                                if (await cevap(e_tek_9) == true) //27
                                {
                                    oyunuBitir(27);
                                }
                                else //29
                                {
                                    oyunuBitir(29);
                                }
                            }
                            else //25
                            {
                                oyunuBitir(25);
                            }
                        }
                        else //31-33-35
                        {
                            if (await cevap(d_tek_12) == true) //33-35
                            {
                                if (await cevap(e_tek_11) == true) //33
                                {
                                    oyunuBitir(33);
                                }
                                else //35
                                {
                                    oyunuBitir(35);
                                }
                            }
                            else //31
                            {
                                oyunuBitir(31);
                            }
                        }
                    }
                    else //37-39-41-43-45-47-49
                    {
                        if (await cevap(c_tek_7) == true) //37-39-41
                        {
                            if (await cevap(d_tek_14) == true) //39-41
                            {
                                if (await cevap(e_tek_13) == true) //39
                                {
                                    oyunuBitir(39);
                                }
                                else //41
                                {
                                    oyunuBitir(41);
                                }
                            }
                            else //37
                            {
                                oyunuBitir(37);
                            }
                        }
                        else // 43-45-47-49
                        {
                            if (await cevap(d_tek_15) == true) // 43-45
                            {
                                if (await cevap(e_tek_15) == true) //43
                                {
                                    oyunuBitir(43);
                                }
                                else //45
                                {
                                    oyunuBitir(45);
                                }
                            }
                            else //47-49
                            {
                                if (await cevap(e_tek_17) == true) //47
                                {
                                    oyunuBitir(47);
                                }
                                else //49
                                {
                                    oyunuBitir(49);
                                }
                            }
                        }
                    }
                }

            } //+
            else //çift sayılar üzerindeki algoritma
            {
                tutulan_deger_cift = true;

                if (await cevap(a_cift_1) == true) //a_cift_1
                {
                    if (await cevap(b_cift_1) == true) //2-4-6-8-10-12-14
                    {
                        if (await cevap(c_cift_1) == true) //2-4-6-8
                        {
                            if (await cevap(d_cift_1) == true) //2-4
                            {
                                if (await cevap(e_cift_1) == true)
                                {
                                    oyunuBitir(2);
                                }
                                else
                                {
                                    oyunuBitir(4);
                                }
                            }
                            else //6-8
                            {
                                if (await cevap(e_cift_3) == true) //6
                                {
                                    oyunuBitir(6);
                                }
                                else //8
                                {
                                    oyunuBitir(8);
                                }

                            }
                        }
                        else //10-12-14
                        {
                            if (await cevap(d_cift_3) == true) //10-12
                            {
                                if (await cevap(e_cift_5) == true) // 10
                                {
                                    oyunuBitir(10);
                                }
                                else //12
                                {
                                    oyunuBitir(12);
                                }
                            }
                            else
                            {
                                oyunuBitir(14);
                            }
                        }
                    }
                    else //16-18-20-22-24-26
                    {
                        if (await cevap(c_cift_3) == true) //16-18-20
                        {
                            if (await cevap(d_cift_5) == true) //16-18
                            {
                                if (await cevap(c_cift_7) == true) //16
                                {
                                    oyunuBitir(16);
                                }
                                else //18
                                {
                                    oyunuBitir(18);
                                }
                            }
                            else
                            {
                                oyunuBitir(20);
                            }
                        }
                        else //22-24-26
                        {
                            if (await cevap(d_cift_7) == true) //22-24
                            {
                                if (await cevap(e_cift_9) == true) //22
                                {
                                    oyunuBitir(22);
                                }
                                else //24
                                {
                                    oyunuBitir(24);
                                }
                            }
                            else //26
                            {
                                oyunuBitir(26);
                            }
                        }
                    }
                }
                else //a_cift_2
                {
                    if (await cevap(b_cift_3) == true) //28-30-32-34-36-38
                    {
                        if (await cevap(c_cift_5) == true) //28-30-32
                        {
                            if (await cevap(d_cift_9) == true) //28-30
                            {
                                if (await cevap(e_cift_11) == true) //28
                                {
                                    oyunuBitir(28);
                                }
                                else //30
                                {
                                    oyunuBitir(30);
                                }
                            }
                            else //32
                            {
                                oyunuBitir(32);
                            }
                        }
                        else //34-36-38
                        {
                            if (await cevap(d_cift_11) == true) //34-36
                            {
                                if (await cevap(e_cift_13) == true) //34
                                {
                                    oyunuBitir(34);
                                }
                                else
                                {
                                    oyunuBitir(36);
                                }
                            }
                            else //38
                            {
                                oyunuBitir(38);
                            }
                        }
                    }
                    else //40-42-44-46-48-50
                    {
                        if (await cevap(c_cift_7) == true) //40-42-44 
                        {
                            if (await cevap(d_cift_13) == true) //40-42
                            {
                                if (await cevap(e_cift_15) == true) //40
                                {
                                    oyunuBitir(40);
                                }
                                else //42
                                {
                                    oyunuBitir(42);
                                }
                            }
                            else
                            {
                                oyunuBitir(44);
                            }
                        }
                        else //46-48-50
                        {
                            if (await cevap(d_cift_15) == true) //46-48
                            {
                                if (await cevap(e_cift_17) == true) //46
                                {
                                    oyunuBitir(46);
                                }
                                else //48
                                {
                                    oyunuBitir(48);
                                }
                            }
                            else //50
                            {
                                oyunuBitir(50);
                            }
                        }
                    }
                }
            }
        }

        bool isAnswered = false;
        bool? answer = null;

        private async Task<bool> waitForResponse()
        {
            isAnswered = false;
            await Task.Run(() =>
            {
                while (!isAnswered) { }
            });

            if (answer != null)
            {
                if (((bool)answer))
                    return true;
                else
                    return false;
            }
            return false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            label_info.Visibility = Visibility.Hidden;

            btnStart.IsEnabled = false;
            btnStart.Visibility = Visibility.Hidden;

            btn_yes.IsEnabled = true;
            btn_no.IsEnabled = true;
            btn_yes.Visibility = Visibility.Visible;
            btn_no.Visibility = Visibility.Visible;

            if (baslangic == 0)
            {
                baslangic++;
                kumeleri_olustur();
                gameLoop();
            }
            else
            {
                gameLoop();
            }
        }

        private void btn_yes_MouseDown(object sender, MouseButtonEventArgs e)
        {
            btn_yes.Source = new BitmapImage(new Uri(@"pack://application:,,,/Resources/yes_down.bmp"));
        }

        private void btn_yes_MouseUp(object sender, MouseButtonEventArgs e)
        {
            btn_yes.Source = new BitmapImage(new Uri(@"pack://application:,,,/Resources/yes.ico"));

            isAnswered = true;
            answer = true;
        }

        private void btn_no_MouseDown(object sender, MouseButtonEventArgs e)
        {
            btn_no.Source = new BitmapImage(new Uri(@"pack://application:,,,/Resources/no_down.bmp"));
        }

        private void btn_no_MouseUp(object sender, MouseButtonEventArgs e)
        {
            btn_no.Source = new BitmapImage(new Uri(@"pack://application:,,,/Resources/no.ico"));

            isAnswered = true;
            answer = false;
        }
    }
}