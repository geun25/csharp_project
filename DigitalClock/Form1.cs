using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DigitalClock
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            timer1.Interval = 1000;
            timer1.Enabled = true;          
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToString();
            if (DateTime.Now.Hour == 14 && DateTime.Now.Minute == 27 && DateTime.Now.Second == 00)
                PlaySound();
        }

        private void PlaySound()
        {
            SoundPlayer sound = new SoundPlayer(@"C:\Users\jin yeong\Desktop\01. 그대여 그대여 나의 그대여.wav");
            sound.Play();
        }
    }
}
