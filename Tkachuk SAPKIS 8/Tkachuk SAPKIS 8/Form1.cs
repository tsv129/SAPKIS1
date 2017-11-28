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

namespace Tkachuk_SAPKIS_8
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Bitmap bm = TakeScreenShot(Screen.PrimaryScreen);
            if (!Directory.Exists("screenshot"))
            {
                Directory.CreateDirectory("screenshot");
            }
            using (Graphics g = Graphics.FromImage(bm))
            {
                Font drawFont = new Font("Arial", 20);
                SolidBrush drawBrush = new SolidBrush(Color.YellowGreen);
                g.DrawString(Convert.ToString(DateTime.Now).Replace(".", "-"), drawFont, drawBrush, new Point(50, 50));

                // g.Save("screenshot/" + Convert.ToString(DateTime.Now).Replace(".", "-").Replace(":", "-") + ".png");
            }
            // MessageBox.Show(Convert.ToString(DateTime.UtcNow).Replace(".", "-").Replace(":","-")+".png");
            bm.Save("screenshot/" + Convert.ToString(DateTime.Now).Replace(".", "-").Replace(":", "-") + ".png");

        }

        private Bitmap TakeScreenShot(Screen currentScreen)
        {
            Bitmap bmpScreenShot = new Bitmap(currentScreen.Bounds.Width,
                                              currentScreen.Bounds.Height,
                                              System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            Graphics gScreenShot = Graphics.FromImage(bmpScreenShot);

            gScreenShot.CopyFromScreen(currentScreen.Bounds.X,
                                       currentScreen.Bounds.Y,
                                       0, 0,
                                       currentScreen.Bounds.Size,
                                       CopyPixelOperation.SourceCopy);
            return bmpScreenShot;
        }
    }
}
