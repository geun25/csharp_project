using System;
using System.Drawing;
using System.Windows.Forms;

namespace ImagePicture
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile(@"C:\Users\jin yeong\Desktop\으막\사나 배경화면\i16518773931.jpg");
            comboBox1.SelectedItem = null;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile(@"C:\Users\jin yeong\Desktop\으막\사나 배경화면\i16520182775.jpg");
            comboBox1.SelectedItem = null;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile(@"C:\Users\jin yeong\Desktop\으막\사나 배경화면\i16537603667.jpg");
            comboBox1.SelectedItem = null;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile(@"C:\Users\jin yeong\Desktop\으막\사나 배경화면\i16542447057.jpg");
            comboBox1.SelectedItem = null;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile(@"C:\Users\jin yeong\Desktop\으막\사나 배경화면\i16581814605.jpg");
            comboBox1.SelectedItem = null;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            comboBox1.SelectedItem = null;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            string[] array = new string[] { "1", "2", "3", "4", "5" };
            comboBox1.Items.AddRange(array);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {          
            if (comboBox1.SelectedItem == null) return;
            else if (comboBox1.SelectedItem.Equals("1")) pictureBox1.Image = Image.FromFile(@"C:\Users\jin yeong\Desktop\으막\사나 배경화면\i16518773931.jpg"); 
            else if (comboBox1.SelectedItem.Equals("2")) pictureBox1.Image = Image.FromFile(@"C:\Users\jin yeong\Desktop\으막\사나 배경화면\i16520182775.jpg"); 
            else if (comboBox1.SelectedItem.Equals("3")) pictureBox1.Image = Image.FromFile(@"C:\Users\jin yeong\Desktop\으막\사나 배경화면\i16537603667.jpg"); 
            else if (comboBox1.SelectedItem.Equals("4")) pictureBox1.Image = Image.FromFile(@"C:\Users\jin yeong\Desktop\으막\사나 배경화면\i16542447057.jpg"); 
            else if (comboBox1.SelectedItem.Equals("5")) pictureBox1.Image = Image.FromFile(@"C:\Users\jin yeong\Desktop\으막\사나 배경화면\i16581814605.jpg"); 
        }
    }
}
