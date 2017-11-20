using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tkachuk_laba_SAPKIS_1
{

    public partial class Form1 : Form
    {
        private Byte func = 0; //1 +;2 -;3 *;4 /;5 %;
        private Double first = 0;
        private Boolean drob = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void Func()
        {
            switch (func) {
                case 1:
                    first = first + Double.Parse(TB.Text);
                    TB.Text = first.ToString();
                    break;
                case 2:
                    first = first - Double.Parse(TB.Text);
                    TB.Text = first.ToString();
                    break;
                case 3:
                    first = first * Double.Parse(TB.Text);
                    TB.Text = first.ToString();
                    break;
                case 4:
                    first = first / Double.Parse(TB.Text);
                    TB.Text = first.ToString();
                    break;
                case 5:
                    first = Double.Parse(TB.Text) * first / 100;
                    TB.Text = first.ToString();
                    break;


            }
            label1.Text = "";
            first = 0;
            func = 0;
        }

        private void btn_1_Click(object sender, EventArgs e)
        {
            TB.Text = TB.Text + "1";
        }

        private void btn_2_Click(object sender, EventArgs e)
        {
            TB.Text = TB.Text + "2";
        }

        private void btn_3_Click(object sender, EventArgs e)
        {
            TB.Text = TB.Text + "3";
        }

        private void btn_4_Click(object sender, EventArgs e)
        {
            TB.Text = TB.Text + "4";
        }

        private void btn_5_Click(object sender, EventArgs e)
        {
            TB.Text = TB.Text + "5";
        }

        private void btn_6_Click(object sender, EventArgs e)
        {
            TB.Text = TB.Text + "6";
        }

        private void btn_7_Click(object sender, EventArgs e)
        {
            TB.Text = TB.Text + "7";
        }

        private void btn_8_Click(object sender, EventArgs e)
        {
            TB.Text = TB.Text + "8";
        }

        private void btn_9_Click(object sender, EventArgs e)
        {
            TB.Text = TB.Text + "9";
        }

        private void btn_0_Click(object sender, EventArgs e)
        {
            if (TB.Text != "0")
            TB.Text = TB.Text + "0";
        }

        private void btn_C_Click(object sender, EventArgs e)
        {
            TB.Text = "";
            label1.Text = "";
            func = 0;
        }

        private void call(Byte f, char c)
        {   
            if (TB.Text == String.Empty)
            {
                if (!(label1.Text == String.Empty))
                {
                    func = f;
                    label1.Text = label1.Text.Remove(label1.Text.Length - 1);
                    label1.Text = label1.Text + c;
                }
            }
            else
            {
                if (func == 0)
                {
                    func = f;
                    first = Double.Parse(TB.Text);
                    label1.Text = TB.Text + c;
                    TB.Clear();
                }
                else
                {
                    if (!(TB.Text == String.Empty))
                    {
                        Func();
                        func = 0;
                    }
                }
            }
        }
        private void btn_plus_Click(object sender, EventArgs e)
        {
            call(1,'+');
        }

        private void btn_minus_Click(object sender, EventArgs e)
        {
            call(2,'-');
        }

        private void btn_mult_Click(object sender, EventArgs e)
        {
            call(3,'*');
        }

        private void btn_div_Click(object sender, EventArgs e)
        {
            call(4,'/');
        }

        private void btn_sqrt_Click(object sender, EventArgs e)
        {
            TB.Text = Math.Sqrt(Double.Parse(TB.Text)).ToString();
        }

        private void btn_plusminus_Click(object sender, EventArgs e) { 
        
            Boolean tmp = false;
            if (TB.Text != "")
            {
                TB.Text = (-1 * Double.Parse(TB.Text)).ToString();

        
    }
        }

        private void btn_1divx_Click(object sender, EventArgs e)
        {
            if (TB.Text != "")
            {
                TB.Text = (1 / Double.Parse(TB.Text)).ToString();
            }
        }

        private void btn_proc_Click(object sender, EventArgs e)
        {
            if (func == 0)
            {
                func = 5;
                first = Double.Parse(TB.Text);
                label1.Text = TB.Text + " %";
                TB.Clear();
            }
            else
            {
                Func();
                func = 0;
            }
        }

        private void btn_result_Click(object sender, EventArgs e)
        {
            if (func != 0)
            {
                if (!(TB.Text == String.Empty))
                {
                    Func();
                    func = 0;
                }
            }
        }

        private void btn_Z_Click(object sender, EventArgs e)
        {
            if (TB.Text == String.Empty)
            {
                TB.Text = "0,";
            }
            if (!TB.Text.Contains(',')){
                TB.Text = TB.Text + ",";
            }
        }

        private void btn_back_Click_1(object sender, EventArgs e)
        {
            String str = "";
            char[] c = TB.Text.ToCharArray();
            for (int i = 0; i < TB.Text.Length - 1; i++)
            {
                str = str + c[i];
            }
            TB.Text = str;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            RegistryKey CUK = Registry.CurrentUser;
            RegistryKey myKey = CUK.CreateSubKey("CalcReg");

            myKey.SetValue("first", first);
            myKey.SetValue("second", TB.Text);
            myKey.SetValue("func", func);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RegistryKey CUK = Registry.CurrentUser;
            RegistryKey myKey = CUK.CreateSubKey("CalcReg");

            first = Double.Parse(myKey.GetValue("first").ToString());
            TB.Text = myKey.GetValue("second").ToString();
            func = Byte.Parse(myKey.GetValue("func").ToString());
            switch (func) //1 +;2 -;3 *;4 /;5 %;
            {
                case 1:
                    {
                        label1.Text = first.ToString() + '+';
                        break;
                    }
                case 2:
                    {
                        label1.Text = first.ToString() + '-';
                        break;
                    }
                case 3:
                    {
                        label1.Text = first.ToString() + '*';
                        break;
                    }
                case 4:
                    {
                        label1.Text = first.ToString() + '/';
                        break;
                    }
                case 5:
                    {
                        label1.Text = first.ToString() + '%';
                        break;
                    }

            }
        }

        /*private void GetDir(String startdir)
        {
            using (var sw = File.AppendText("Path.txt"))
            {
                DirectoryInfo dir = new DirectoryInfo(startdir);
                int i = 0;
                foreach (var item in dir.GetDirectories())
                {
                    sw.WriteLine("-> " + startdir + item.Name);
                    startdir = startdir + item.Name;
                    GetDir(startdir);
                }
                foreach (var item in dir.GetFiles())
                {
                    sw.WriteLine(item.Name);
                }
                sw.Close();
            }
        }*/

        void maketree(string startdirectory)
        {

            string[] searchdirectory = Directory.GetDirectories(startdirectory);
            if (searchdirectory.Length > 0)
            {
                for (int i = 0; i < searchdirectory.Length; i++)
                {
                    maketree(searchdirectory[i] + @"\");
                }
            }

            using (var filetext = File.AppendText("Path.txt")) { 
                string[] filesss = Directory.GetFiles(startdirectory);
                for (int i = 0; i < filesss.Length; i++)
                {
                    filetext.WriteLine(filesss[i]);
                }
            }
        }

        private void btn_CE_Click_1(object sender, EventArgs e)
        {
            TB.Text = "";
        }

        private void ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            maketree(Directory.GetCurrentDirectory());
        }

        private void pOSTЗапросToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //string loginURI = "http://www.zapomnika.zzz.com.ua/Lab4.php";
            //string username = "login";
            //string password = "pass";
            //string reqString = "useralias=" + username + "&" + password + "=pass&submit=Connect+%3E%3E";
            //byte[] requestData = Encoding.UTF8.GetBytes(reqString);
            //var request = (HttpWebRequest)WebRequest.Create(loginURI);
            //request.AllowAutoRedirect = true;
            //request.Method = "POST";
            //request.ContentType = "application/x-www-form-urlencoded";
            //request.ContentLength = requestData.Length;
            //using (Stream S = request.GetRequestStream())
            //    S.Write(requestData, 0, requestData.Length);
            //using (var response = (HttpWebResponse)request.GetResponse())
            //{
            //    var newPageCode = new StreamReader(response.GetResponseStream()).ReadToEnd();
            //}


            WebRequest request = WebRequest.Create("http://www.zapomnika.zzz.com.ua/Lab4.php");
            request.Method = "POST";
            string FName = "Tkachuk";
            string pass = "777";
            byte[] byteArray = System.Text.Encoding.UTF8.GetBytes("user=" + FName + "&pass=" + pass);
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = byteArray.Length;
            using (Stream dataStream = request.GetRequestStream())
            {
                dataStream.Write(byteArray, 0, byteArray.Length);
            }
            using (var response = (HttpWebResponse)request.GetResponse())
            {
                var newPageCode = new StreamReader(response.GetResponseStream()).ReadToEnd();
                MessageBox.Show(newPageCode.Remove(47));
            }

            //textBox1.Text = POST("http://www.zapomnika.zzz.com.ua/Lab4.php", "user:Stas,pass:777"); 3
            // MessageBox.Show(textBox1.Text);


        }

        //private static string POST(string Url, string Data) 3
        //{
        //    System.Net.WebRequest req = System.Net.WebRequest.Create(Url);
        //    req.Method = "POST";
        //    req.Timeout = 100000;
        //    req.ContentType = "application/x-www-form-urlencoded";
        //    byte[] sentData = Encoding.GetEncoding(1251).GetBytes(Data);
        //    req.ContentLength = sentData.Length;
        //    System.IO.Stream sendStream = req.GetRequestStream();
        //    sendStream.Write(sentData, 0, sentData.Length);
        //    sendStream.Close();
        //    System.Net.WebResponse res = req.GetResponse();
        //    System.IO.Stream ReceiveStream = res.GetResponseStream();
        //    System.IO.StreamReader sr = new System.IO.StreamReader(ReceiveStream, Encoding.UTF8);
        //    //Кодировка указывается в зависимости от кодировки ответа сервера
        //    Char[] read = new Char[256];
        //    int count = sr.Read(read, 0, 256);
        //    string Out = String.Empty;
        //    while (count > 0)
        //    {
        //        String str = new String(read, 0, count);
        //        Out += str;
        //        count = sr.Read(read, 0, 256);
        //    }
        //    return Out;
        //}
    }
}