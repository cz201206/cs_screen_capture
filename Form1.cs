using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
namespace ScreenShot
{
    public partial class Form1 : Form
    {
        [DllImport("Kernel32.DLL ", SetLastError = true)]
        public static extern bool SetEnvironmentVariable(string lpName, string lpValue);
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string key = "name_pic";
            string val = DateTime.Now.ToString("yyyy-MM-dd_hh.mm.ss");
            Debug.WriteLine(val);
            SetEnvironmentVariable(key, val);

            this.button1.Enabled = false;
            this.button1.Text = "截图中，请稍候...";

            System.Diagnostics.Process process = new System.Diagnostics.Process();
            //调用的exe的名称
            process.StartInfo.FileName = "1.cmd";
            //传递进exe的参数
            process.StartInfo.Arguments = "";
            process.StartInfo.UseShellExecute = false;
            //不显示exe的界面
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.RedirectStandardOutput = false;
            process.StartInfo.RedirectStandardInput = true;
            process.Start();

            process.StandardInput.AutoFlush = true;
            process.WaitForExit();

            this.pictureBox1.Image = Image.FromFile(val + ".png");
            Debug.WriteLine("截图一次");
            this.button1.Text = "截图";
            this.button1.Enabled = true;
        }


    }

}
