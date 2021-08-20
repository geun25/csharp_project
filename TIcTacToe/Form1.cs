using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// 버튼을 클릭했을 때 마킹이 되어야 한다(순서대로 O/X)
// 마킹이 가로 세로 대각선상에 일치하여 위치하면, 해당 순서에 마킹한 유저가 승리.
// 마킹이 있는데 다시 해당 버튼을 클릭한 경우, 경고음 발생.
// 9개의 마킹이 완료되었는데도 결판이 나지 않으면 무승부.

namespace TIcTacToe
{
    public partial class Form1 : Form
    {
        Button[] btns;
        TicTacToe manager = new TicTacToe();

        public Form1()
        {
            InitializeComponent();
            btns = new Button[9] { button, button2, button3, button4, button5, button6, button7, button8, button9 };
            for(int i = 0; i < 9; i++)
            {
                btns[i].Tag = i;
            }

        }

        private void button_Click(object sender, EventArgs e)
        {
            GameRule(sender);
        }

        private void GameRule(object sender)
        {
            Button btn = sender as Button;
            if(btn.Text == "1" || btn.Text == "2")
            {
                Console.Beep(500, 200);
                return;
            }

            manager.Mark((int)btn.Tag);

            if(manager.Seq % 2 == 1)
            {
                btn.Text = "1";
                if(manager.WinnerCheck())
                {
                    MessageBox.Show("1번 유저 승리");
                    Reset();
                }
            }
            else
            {
                btn.Text = "2";
                if (manager.WinnerCheck())
                {
                    MessageBox.Show("2번 유저 승리");
                    Reset();
                }
            }

            if(manager.Seq == 9)
            {
                MessageBox.Show("무승부");
                Reset();
            }
        }

        void Reset()
        {
            manager = new TicTacToe();
            for (int i = 0; i < 9; i++)
            {
                btns[i].Text = null;
            }
        }
    }
}
