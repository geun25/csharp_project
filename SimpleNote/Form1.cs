using System.IO;
using System.Windows.Forms;

namespace SimpleNote
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string result1 = "";

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.NumPad0)
            {
                result1 = textBox1.Text;
                textBox1.Text = null; // 초기화
            }
            if (e.KeyCode == Keys.NumPad1)
            {
                string result2 = textBox1.Text;
                File.WriteAllText(@"C:\Users\jin yeong\.vscode\csharp_project\SimpleNote\" + result2 + ".txt", result1);
                textBox1.Text = null; // 초기화
            }
        }
    }
}
