using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;

namespace ProcessKill
{
    public partial class Form1 : Form
    {
        bool state = true;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(ProcessChecker);
            thread.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            state = false;
            textBox3.Text = "프로세스 체크가 종료되었습니다.";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Process[] process = new Process[5];
            process = Process.GetProcessesByName(textBox4.Text);
            process[0].Kill();
            textBox3.Text = $"{textBox4.Text} 프로세스가 종료되었습니다.";
        }

        void ProcessChecker()
        {
            PerformanceCounter[] counters = new PerformanceCounter[textBox1.Lines.Length];
            for (int i = 0; i < counters.Length; i++)
            {
                counters[i] = new PerformanceCounter("Process", "% User Time", textBox1.Text);
            }

            while(state)
            {
                if (InvokeRequired) // 컨트롤이 메인 스레드에서 만들어졌고, CPU 사용률 체크는 별도 스레드에서 수행되기 때문에 메서드를 호출해야하는 상황 발생.
                                    // Invoke가 필요하면 true값 반환
                {
                    label2.BeginInvoke(new Action(() =>
                    {
                        try
                        {
                            if (textBox1.Lines.Length == 1)
                            {
                                textBox2.Text = counters[0].NextValue().ToString() + "%" + Environment.NewLine;
                            }
                            else if (textBox1.Lines.Length == 2)
                            {
                                textBox2.Text = counters[0].NextValue().ToString() + "%" + Environment.NewLine
                                + counters[1].NextValue().ToString() + "%";
                            }
                            else if (textBox1.Lines.Length == 3)
                            {
                                textBox2.Text = counters[0].NextValue().ToString() + "%" + Environment.NewLine
                                + counters[1].NextValue().ToString() + "%" + Environment.NewLine
                                + counters[2].NextValue().ToString() + "%";
                            }
                        }

                        catch
                        {
                            textBox3.Text = "프로세스가 없습니다.";
                        }
                    }));                   
                }
                else
                {
                    if (textBox1.Lines.Length == 1)
                    {
                        textBox2.Text = counters[0].NextValue().ToString() + "%" + Environment.NewLine;
                    }
                    else if (textBox1.Lines.Length == 2)
                    {
                        textBox2.Text = counters[0].NextValue().ToString() + "%" + Environment.NewLine
                        + counters[1].NextValue().ToString() + "%";
                    }
                    else if (textBox1.Lines.Length == 3)
                    {
                        textBox2.Text = counters[0].NextValue().ToString() + "%" + Environment.NewLine
                        + counters[1].NextValue().ToString() + "%" + Environment.NewLine
                        + counters[2].NextValue().ToString() + "%";
                    }
                }
                Thread.Sleep(1000);
            }
        }
    }
}
