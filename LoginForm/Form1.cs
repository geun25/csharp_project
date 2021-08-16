using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace LoginForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Login_btn_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\jin yeong\Documents\Data5.mdf;Integrated Security=True;Connect Timeout=30");

            SqlDataAdapter sda = new SqlDataAdapter("Select Count(*) from USERINFO where USERNAME='"+ID_txt.Text+"' and PASSWORD = '"+PW_txt.Text+"'", con);

            DataTable newTable = new DataTable();

            sda.Fill(newTable);

            if(newTable.Rows[0][0].ToString() == "1")
            {
                // 로그인 성공
                this.Hide();

                MainForm mainform = new MainForm();
                mainform.Show();
            }
            else
            {
                // 로그인 실패
                MessageBox.Show("아이디와 비밀번호를 확인해주세요.");
            }           
        }
    }
}
