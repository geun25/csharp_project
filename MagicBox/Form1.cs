using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace MagicBox
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            listBox1.Items.Add("계산기");
            listBox1.Items.Add("인터넷");
            listBox1.Items.Add("CMD");
            listBox1.Items.Add("그림판");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string a = listBox1.SelectedItem.ToString();
                if (a == "계산기")               
                    Process.Start("calc.exe");
                if (a == "인터넷")
                    Process.Start("explorer.exe", "https://www.google.co.kr/");
                if (a == "CMD")
                    Process.Start("cmd.exe");
                if (a == "그림판")
                    Process.Start("mspaint.exe");
            }
            catch
            {
                MessageBox.Show("아무것도 선택되지 않았습니다.");
            }
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Process cmd = new Process();
            cmd.StartInfo.FileName = "cmd.exe";
            cmd.StartInfo.Arguments = "/C" + textBox1.Text;
            cmd.StartInfo.RedirectStandardOutput = true;
            cmd.StartInfo.UseShellExecute = false;
            cmd.Start();
            string txt1 = cmd.StandardOutput.ReadToEnd();
            textBox2.Text = txt1;
        }
    }
}
