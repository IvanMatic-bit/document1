using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace iks_oks2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int playerKey = 1;//player key da odredi ko je X a ko O, mijenja se nakon svake runde
        int key = 1;//key mijenja se nakon svakog poteza i odreduje koji igraè je na potezu.Mijenja se nakon svakog poteza
        int iksoks = 1;//Mijenja se nakon svakog poteza i upisuje se u matricu
        //
       
        const int max = 3;//velicina matrice
        int counterPlayer1 = 0;//brojac pobjeda igraca 1
        int counterPlayer2 = 0;//brojac pobjeda igraca 2
        int[,] matrica = new int[max, max] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };
       
        void SetKey()
        {
            if (key == 1)
            {
                key = 2;
                pictureBox2.Visible = true;
                pictureBox1.Visible = false;

            }

            else
            {
                key = 1;
                pictureBox1.Visible = true;
                pictureBox2.Visible = false;
                

            }
        }
        void setiksoks()
        {
            if (iksoks == 1)
                iksoks = 2;
            else
                iksoks = 1;
        }
        void SetPlayerKey()
        {
            if (playerKey == 1)
            {
                playerKey = 2;
            }
            else
            {
                playerKey = 1;
            }
        }
        void SetMatrica(int i, int j)
        {
            matrica[i, j] = iksoks;
            setiksoks();
        }
        bool CheckEmpty(int i, int j)
        {

            if (matrica[i, j] == 0)
                return true;
            else
                return false;
        }
        void ChechWinneer()
        {
            for (int i = 0; i < max; i++)
            {
                if (matrica[i, 0] == matrica[i, 1] && matrica[i, 0] == matrica[i, 2] && matrica[i, 0] != 0)
                {
                    ShowWinner();
                    Reset();
                }

            }
            for (int i = 0; i < max; i++)
            {
                if (matrica[0, i] == matrica[1, i] && matrica[2, i] == matrica[0, i] && matrica[0, i] != 0)
                {
                    ShowWinner();
                    Reset();
                }

            }
            if (matrica[0, 0] == matrica[1, 1] && matrica[0, 0] == matrica[2, 2] && matrica[0, 0] != 0)
            {
                ShowWinner();
                Reset();
            }
            if (matrica[0, 2] != 0 && matrica[0, 2] == matrica[1, 1] && matrica[0, 2] == matrica[2, 0])
            {
                ShowWinner();
                Reset();
            }

        }
        bool CheckTie()
        {
            bool flag = true;
            for (int i = 0; i < max; i++)
            {
                for (int j = 0; j < max; j++)
                {
                    if (matrica[i, j] == 0)
                        flag = false;
                }
            }
            return flag;
        }
        void CoutTie()
        {
            if (CheckTie())
            {
                MessageBox.Show("Neriješeno");
                
                Reset();
                
            }
        }
        void setMatrica()
        {
            for (int i = 0; i < max; i++)
            {
                for (int j = 0; j < max; j++)
                {
                    matrica[i, j] = 0;
                }
            }
        }
        void Reset()
        {

            if (playerKey == 1)
            {
                key = 2;
            }

            else
            {
                key = 1;
            }
            iksoks = 1;
            SetPlayerKey();
           // SetKey();
            setMatrica();
           
            button00.BackgroundImage = null;
            button01.BackgroundImage = null;
            button02.BackgroundImage = null;
            button20.BackgroundImage = null;
            button21.BackgroundImage = null;
            button22.BackgroundImage = null;
            button10.BackgroundImage = null;
            button11.BackgroundImage = null;
            button12.BackgroundImage = null;
        }
        
        private void ShowWinner()
        {
            if (key == 1)
            {

                counterPlayer1++;
                
                richTextBox1.Text = counterPlayer1.ToString();
                MessageBox.Show("Pobjednik je " + player1textBox.Text);
            }
            else
            {
                counterPlayer2++;
               
                richTextBox2.Text = counterPlayer2.ToString();
                MessageBox.Show("Pobjednik je " + Player2textBox.Text);
            }
          

        }
        void Korak(int i, int j, Button b)
        {
            //Image iks1 = Properties.Resources.iks;
            //iks1 = iks1.GetThumbnailImage(50, 50, null, IntPtr.Zero);
            //Image oks1 = Properties.Resources.oks2;
            //oks1 = oks1.GetThumbnailImage(50, 50, null, IntPtr.Zero);
            if (CheckEmpty(i, j))
            {
                if (iksoks == 1)

                    b.BackgroundImage = Properties.Resources.iks.GetThumbnailImage(50, 50, null, IntPtr.Zero);

                else
                    b.BackgroundImage = Properties.Resources.oks2.GetThumbnailImage(50, 50, null, IntPtr.Zero);

                SetMatrica(i, j);
                ChechWinneer();
                CoutTie();
                SetKey();
            }
        }
        private void Button00_Click(object sender, EventArgs e)
        {
            Korak(0, 0, button00);
        }

        private void Button01_Click(object sender, EventArgs e)
        {
            Korak(0, 1, button01);
        }

        private void Button02_Click(object sender, EventArgs e)
        {
            Korak(0, 2, button02);
        }

        private void Button10_Click(object sender, EventArgs e)
        {
            Korak(1, 0, button10);
        }

        private void Button11_Click(object sender, EventArgs e)
        {
            Korak(1, 1, button11);
        }

        private void Button12_Click(object sender, EventArgs e)
        {
            Korak(1, 2, button12);
        }

        private void Button20_Click(object sender, EventArgs e)
        {
            Korak(2, 0, button20);
        }

        private void Button21_Click(object sender, EventArgs e)
        {
            Korak(2, 1, button21);
        }

        private void Button22_Click(object sender, EventArgs e)
        {
            Korak(2, 2, button22);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Reset();
        }
    }
}
