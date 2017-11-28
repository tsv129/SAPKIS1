using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Spichki
{
    // TODO:
    // Кликать на спички
    public partial class Form1 : Form
    {
        Brush BrownBrush = Brushes.Brown;
        Brush YellowBrush = Brushes.Yellow;
        int kolvo;
        int space;
        int basekol;
        short[] spichki = new short[30];

        public Form1()
        {
            InitializeComponent();
        }

        private void DrawMatch()
        {
            Graphics g = Graphics.FromHwnd(pictureBox1.Handle);
            Graphics gp = Graphics.FromHwnd(pictureBox2.Handle);
            Graphics gc = Graphics.FromHwnd(pictureBox3.Handle);
            g.Clear(SystemColors.Control);
            gc.Clear(SystemColors.Control);
            gp.Clear(SystemColors.Control);
            for (int i = 0; i < basekol; i++)
                switch (spichki[i])
                {
                    case 0:
                        {
                            g.FillRectangle(YellowBrush, ((i+1) * space)+1, 20, 10, 110);
                            g.FillEllipse(BrownBrush, ((i+1) * space), 10, 12, 15);
                            break;
                        }
                    case -1:
                        {
                            gc.FillRectangle(YellowBrush, ((i+1) * space)+1, 25, 10, 110);
                            gc.FillEllipse(BrownBrush, ((i+1) * space), 15, 12, 15);
                            break;
                        }
                    case 1:
                        {
                            gp.FillRectangle(YellowBrush, ((i+1) * space)+1, 35, 10, 110);
                            gp.FillEllipse(BrownBrush, ((i+1) * space), 25, 12, 15);
                            break;
                        }
                }
        }

        private void ButtonSwap(Boolean b)
        {
            button2.Enabled = b;
            button3.Enabled = b;
            button4.Enabled = b;
            button5.Enabled = b;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            kolvo = basekol = Convert.ToInt32(numericUpDown1.Value);
            space = 600 / (kolvo+1);
            for (int y = 0; y < basekol; y++)
                spichki[y] = 0;
            DrawMatch();
            ButtonSwap(true);
            label1.Visible = true;
            label2.Visible = true;
        }

        private bool WinCheck(int p)
        {
            if (kolvo <= 0)
            {
                if (p == -1)
                {
                    MessageBox.Show("Вы проиграли");
                    ButtonSwap(false);
                    return true;
                }
                else
                {
                    MessageBox.Show("Вы выйграли");
                    ButtonSwap(false);
                    return true;
                }
            }
            return false;
        }

        private static int RNG(int k)
        {
            Random rng = new Random();
            return 1+rng.Next(k-1);
        }

        private void BotTurn()
        {
            switch(kolvo % 5)
            {
                case 0:
                    {
                        int b = RNG(5);
                        kolvo -= b;
                        Changer(kolvo, (byte)b, -1);
                        DrawMatch();
                        break;
                    }
                case 1:
                    {
                        kolvo -= 1;
                        Changer(kolvo, 1, -1);
                        DrawMatch();
                        break;
                    }
                case 2:
                    {
                        kolvo -= 2;
                        Changer(kolvo, 2, -1);
                        DrawMatch();
                        break;
                    }
                case 3:
                    {
                        kolvo -= 3;
                        Changer(kolvo, 3, -1);
                        DrawMatch();
                        break;
                    }
                case 4:
                    {
                        kolvo -= 4;
                        Changer(kolvo, 4, -1);
                        DrawMatch();
                        break;
                    }
            }
            WinCheck(-1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Clickbtn(1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Clickbtn(2);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Clickbtn(3);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Clickbtn(4);
        }

        private void Clickbtn(Byte b)
        {
            kolvo -= b;
            Changer(kolvo, b, 1);
            DrawMatch();
            if (!WinCheck(1))
                BotTurn();
        }

        private void Changer(int kol, Byte take, short player)
        {
            for(; kol < kolvo + take; kol++)
            {
                spichki[kol] = player;
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("sdfdsfs");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            numericUpDown1.Value = 10 + RNG(20);
        }
    }
}