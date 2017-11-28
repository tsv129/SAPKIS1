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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            numericUpDown1.Value = 10 + Form1.RNG(20);
        }

        private void Form2_Activated(object sender, EventArgs e)
        {
            numericUpDown1.Value = Form1.basekol;
            if (Form1.firstmove)
                radioButton1.Checked = true;
            else
                radioButton2.Checked = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1.basekol = Convert.ToInt32(numericUpDown1.Value);
            if (radioButton1.Checked)
                Form1.firstmove = true;
            else
                Form1.firstmove = false;
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
