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

namespace Diary
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            File.WriteAllText(@"C:\Users\jin yeong\.vscode\csharp_project\Diary\" + textBox1.Text + ".txt", 
                textBox2.Text + Environment.NewLine + Environment.NewLine + "현재시간 : " + DateTime.Now);
            MessageBox.Show("일기 내용이 입력되었습니다.");
        }
    }
}
