using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tkachuk_laba_SAPKIS_5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            qq.Clear();
            Clipboard.Clear();
        }

        private const int WH_KEYBOARD_LL = 13;
        private const int WM_KEYDOWN = 0x0100;
        private const int WM_SYSKEYDOWN = 0x0104;

        private static LowLevelKeyboardProc _proc = HookCallback;

        private static IntPtr _hookID = IntPtr.Zero;

        public static string text;

        private static IntPtr SetHook(LowLevelKeyboardProc proc)

        {

            using (Process curProcess = Process.GetCurrentProcess())

            using (ProcessModule curModule = curProcess.MainModule)

            {

                return SetWindowsHookEx(WH_KEYBOARD_LL, proc,

                    GetModuleHandle(curModule.ModuleName), 0);

            }

        }

        private delegate IntPtr LowLevelKeyboardProc(

            int nCode, IntPtr wParam, IntPtr lParam);

        static Queue qq = new Queue(10);
        static Array ArrOut = Array.CreateInstance(typeof(String), 10);
        private static IntPtr HookCallback(

            int nCode, IntPtr wParam, IntPtr lParam)

        {

            if (nCode >= 0 && wParam == (IntPtr)WM_SYSKEYDOWN)

            {
                int vkCode = Marshal.ReadInt32(lParam);

                if ((Keys)vkCode == Keys.V)
                {
                    if (qq.Count == 10)
                    {
                        qq.Dequeue();
                        qq.TrimToSize();
                    }
                    qq.Enqueue(Clipboard.GetText());
                    qq.CopyTo(ArrOut, 0);
                    text = qq.Count.ToString();
                    Clipboard.Clear();
                }

                if ((Keys)vkCode == Keys.D1)
                {
                    text += ArrOut.GetValue(0);
                }

                if ((Keys)vkCode == Keys.D2)
                {
                    text += ArrOut.GetValue(1);
                }

                if ((Keys)vkCode == Keys.D3)
                {
                    text += ArrOut.GetValue(2);
                }

                if ((Keys)vkCode == Keys.D4)
                {
                    text += ArrOut.GetValue(3);
                }

                if ((Keys)vkCode == Keys.D5)
                {
                    text += ArrOut.GetValue(4);
                }

                if ((Keys)vkCode == Keys.D6)
                {
                    text += ArrOut.GetValue(5);
                }

                if ((Keys)vkCode == Keys.D7)
                {
                    text += ArrOut.GetValue(6);
                }

                if ((Keys)vkCode == Keys.D8)
                {
                    text += ArrOut.GetValue(7);
                }

                if ((Keys)vkCode == Keys.D9)
                {
                    text += ArrOut.GetValue(8);
                }

                if ((Keys)vkCode == Keys.D0)
                {
                    text += ArrOut.GetValue(9);
                }

                //text += ' '  + Convert.ToString((Keys)vkCode);

            }
            return CallNextHookEx(_hookID, nCode, wParam, lParam);

        }

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]

        private static extern IntPtr SetWindowsHookEx(int idHook,

            LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);


        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]

        [return: MarshalAs(UnmanagedType.Bool)]

        private static extern bool UnhookWindowsHookEx(IntPtr hhk);


        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]

        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode,

            IntPtr wParam, IntPtr lParam);


        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]

        private static extern IntPtr GetModuleHandle(string lpModuleName);



        private void Form1_Load_1(object sender, EventArgs e)
        {
            _hookID = SetHook(_proc);
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            label2.Text = text + "\n";
        }
    }
}