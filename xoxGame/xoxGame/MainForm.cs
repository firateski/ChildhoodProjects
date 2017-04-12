using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace xoxGame
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Tablo üzerindeki durumu ve hangi oyuncunun oyunu kazandığı gibi bilgileri daha okunaklı hale getirmek için kullanılan enumdur.
        /// </summary>
        enum states
        {
            x,
            o,
            nobody
        };

        /// <summary>
        /// Sıradaki hamleyi yapacak oyuncu
        /// </summary>
        states nextMove = states.x;

        /// <summary>
        /// Oyunu kazanan kişiyi tutan değişken
        /// </summary>
        states winner = states.nobody;

        /// <summary>
        /// Oyun kazanılırsa kazanılmasını sağlayan noktaların 'winPoints' listesindeki indeksi tutan değişken
        /// </summary>
        int wonPointIndex = -1;

        /// <summary>
        /// Herhangi bir oyuncunun kazanıp kazanmadığını anlamak için bakmamız gereken noktaların tudulduğu 3 boyutlu dizidir.
        /// </summary>
        private List<Point[]> winPoints = new List<Point[]>()
        {
            new Point[] { new Point(0,0), new Point(0,1), new Point(0,2)},
            new Point[] { new Point(1,0), new Point(1,1), new Point(1,2)},
            new Point[] { new Point(2,0), new Point(2,1), new Point(2,2)},
            new Point[] { new Point(0,0), new Point(1,0), new Point(2,0)},
            new Point[] { new Point(0,1), new Point(1,1), new Point(2,1)},
            new Point[] { new Point(0,2), new Point(1,2), new Point(2,2)},
            new Point[] { new Point(0,0), new Point(1,1), new Point(2,2)},
            new Point[] { new Point(0,2), new Point(1,1), new Point(2,0)},
        };

        /// <summary>
        /// Oyun tahtasındaki durumun tutulduğu tablo
        /// </summary>
        states[,] table = { { states.nobody, states.nobody, states.nobody }, 
                            { states.nobody, states.nobody, states.nobody }, 
                            { states.nobody, states.nobody, states.nobody }
                          };

        /// <summary>
        /// Oyunu kazandıktan sonraki basit animasyon için kullanılan değişken
        /// </summary>
        int effIndex = 0;
        
        /// <summary>
        /// Boş alanı temsil eden resim
        /// </summary>
        Image img_empty = Properties.Resources.empty;

        /// <summary>
        /// X ile doldurulan alanı temsil eden resim
        /// </summary>
        Image img_X = Properties.Resources.x;

        /// <summary>
        /// Y ile doldurulan alanı temsil eden resim
        /// </summary>
        Image img_O = Properties.Resources.o;

        /// <summary>
        /// Form load olayında tetiklenecek metottur.
        /// </summary>
        private void mainForm_Load(object sender, EventArgs e)
        {
            new_game();
        }

        /// <summary>
        /// Kullanıcının yeni oyun başlatmak için kullandığı butonun tetiklediği metottur.
        /// </summary>
        /// <param name="sender">Tıklanan buton nesnesin referansı</param>
        /// <param name="e">Tıklama işleminin argümanlarını tutan parametre</param>
        private void btn_newgame_Click(object sender, EventArgs e)
        {
            new_game();
        }

        /// <summary>
        /// Yeni oyuna başlarken yapılması gereken işlemlerin yapıldığı fonskiyondur.
        /// </summary>
        private void new_game()
        {
            //Oyun değişkenleri varsayılan durumlarına döndürüyoruz.
            wonPointIndex = -1;
            effIndex = 0;
            effect_timer.Enabled = false;
            btn_newgame.Enabled = false;
            setPictureBoxEnabledState(true, true);
            winner = states.nobody;
            nextMove = states.x;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    table[i, j] = states.nobody;
                }
            }

            //Yeni oyuna başladığımız için X ve O durumlarını belirten resimleri sıfırlıyoruz.
            pictureBox1.Image = img_empty;
            pictureBox2.Image = img_empty;
            pictureBox3.Image = img_empty;
            pictureBox4.Image = img_empty;
            pictureBox5.Image = img_empty;
            pictureBox6.Image = img_empty;
            pictureBox7.Image = img_empty;
            pictureBox8.Image = img_empty;
            pictureBox9.Image = img_empty;
        }

        /// <summary>
        /// Oyunu kazanan olursa bu timer aktif ediliyor ve basit bir animasyon işlemi bu fonksiyonun her bir tick olayında gerçekleşiyor.
        /// </summary>
        /// <param name="sender">Timer nesnesinin referansı</param>
        /// <param name="e">Geçerli event argümanını tutan parametre</param>
        void effect_timer_Tick(object sender, EventArgs e)
        {
            if (wonPointIndex < 0) return;

            foreach (dynamic item in this.Controls)
            {
                if (item.GetType() == pictureBox1.GetType() && item.Tag != null)
                {
                    string pictureBoxPoint = item.Tag.ToString();
                    Point currentCheckingPictureBox = new Point(int.Parse(pictureBoxPoint.Split(':')[0]),
                                                                int.Parse(pictureBoxPoint.Split(':')[1]));

                    if(currentCheckingPictureBox.X == winPoints[wonPointIndex][effIndex].X && currentCheckingPictureBox.Y == winPoints[wonPointIndex][effIndex].Y)
                    {
                        item.Visible = !item.Visible;
                    }
                }
            }
            effIndex = (effIndex < 2 && effIndex > -1) ? ++effIndex : 0;
        }

        /// <summary>
        /// Tablonun geçerli durumuna göre herhangi bir oyuncunun kazanıp kazanmadığını kontrol eden fonksiyon.
        /// </summary>
        /// <returns>Kazan var ise True yok ise False döndürülür</returns>
        public bool checkAnyoneIsWon()
        {
            for (int i = 0; i < winPoints.Count; i++)
            {
                bool win = true;
                for (int j = 0; j < winPoints[i].Length; j++)
                {
                    if (table[winPoints[i][j].X, winPoints[i][j].Y] != states.x)
                    {
                        win = false;
                        break;
                    }
                }
                if (win)
                {
                    wonPointIndex = i;
                    winner = states.x;
                    return true;
                }
            }

            for (int i = 0; i < winPoints.Count; i++)
            {
                bool win = true;
                for (int j = 0; j < winPoints[i].Length; j++)
                {
                    if (table[winPoints[i][j].X, winPoints[i][j].Y] != states.o)
                    {
                        win = false;
                        break;
                    }
                }
                if (win)
                {
                    wonPointIndex = i;
                    winner = states.o;
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Oyun içersinde hücreleri temsil eden pictureBoxların enabled özelliğinin verilen parametre doğrultusunda set edilmesi
        /// </summary>
        /// <param name="state">Enabled özelliğinin değeri</param>
        /// <param name="isNewGame">Bu fonksiyonun çağrıldığı yer yeni oyun oluşturma fonksiyonu ise True yapınız. Default olarak False durumundadır.</param>
        private void setPictureBoxEnabledState(bool state, bool isNewGame = false)
        {
            for (int a = 0; a < this.Controls.Count; a++)
            {
                if (this.Controls[a].GetType() == pictureBox1.GetType())
                    this.Controls[a].Enabled = state;
            }

            //Efektten arta kalan gizli pictureBox nesnesi varsa görünür yapıyoruz.
            if (isNewGame)
            {
                for (int a = 0; a < this.Controls.Count; a++)
                {
                    if (this.Controls[a].GetType() == pictureBox1.GetType())
                    {
                        this.Controls[a].Visible = true;
                    }
                }
            }
        }

        /// <summary>
        /// Tablodaki her hücreye tıklandığında bu metot çağrılır ve gerekli işlemler bu fonksiyon ile birlikte yapılır.
        /// </summary>
        /// <param name="sender">Tıklanan pictureBox nesnesin referansı</param>
        /// <param name="e">Tıklama işleminin argümanlarını tutan parametre</param>
        private void CellClick(object sender, EventArgs e)
        {
            btn_newgame.Enabled = true;

            if (nextMove == states.x)
            {
                ((PictureBox)sender).Image = img_X;
                ((PictureBox)sender).Enabled = false;

                string pictureBoxPoint = ((PictureBox)sender).Tag.ToString();
                Point ClickedPictureBoxPoint = new Point(int.Parse(pictureBoxPoint.Split(':')[0]), 
                                                         int.Parse(pictureBoxPoint.Split(':')[1]));
                table[ClickedPictureBoxPoint.X, ClickedPictureBoxPoint.Y] = states.x;
            }
            else
            {
                ((PictureBox)sender).Image = img_O;
                ((PictureBox)sender).Enabled = false;

                string pictureBoxPoint = ((PictureBox)sender).Tag.ToString();
                Point ClickedPictureBoxPoint = new Point(int.Parse(pictureBoxPoint.Split(':')[0]),
                                        int.Parse(pictureBoxPoint.Split(':')[1]));
                table[ClickedPictureBoxPoint.X, ClickedPictureBoxPoint.Y] = states.o;
            }

            if (nextMove == states.x)
                nextMove = states.o;
            else
                nextMove = states.x;

            if (checkAnyoneIsWon() == true)
            {
                if (winner == states.x)
                    MessageBox.Show("Tebrikler X kazandı.");
                else if (winner == states.o)
                    MessageBox.Show("Tebrikler O kazandı.");

                setPictureBoxEnabledState(false);
                effect_timer.Enabled = true;
            }
            else
            {
                bool allBoxesChecked = true;
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (table[i, j] == states.nobody)
                        {
                            allBoxesChecked = false;
                            break;
                        }
                    }
                    if (!allBoxesChecked)
                        break;
                }
                if (allBoxesChecked && winner == states.nobody)
                    MessageBox.Show("Berabere kaldınız...");
            }
        }
    }
}
