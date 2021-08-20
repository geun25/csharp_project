using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace Translator
{
    public partial class Form1 : Form
    {
        IWebDriver driver;
        [DllImport("user32.dll")]
        private static extern int RegisterHotKey(int hwnd, int id, int fsModifiers, int vk);
        [DllImport("user32.dll")]
        private static extern int UnregisterHotKey(int hwnd, int id);

        public Form1()
        {
            InitializeComponent();
            WindowState = FormWindowState.Minimized;
            ShowInTaskbar = false;

            MessageBox.Show("번역 프로그램이 시작되었습니다! \n\n Ctrl + 1 : 클립보드 내용 확인. \n Ctrl + 2 : 클립보드 내용 번역 \n Ctrl + 3 : 프로그램 종료.");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // 0x0 : 조합키 없이 사용, 0x1 : ALT, 0x2 : Ctrl, 0x3 : Shift
            // RegisterHotKey(핸들러함수, 등록키의 ID, 조합키, 등록할 키)
            RegisterHotKey((int)this.Handle, 0, 0x2, (int)System.Windows.Forms.Keys.D1);
            RegisterHotKey((int)this.Handle, 1, 0x2, (int)System.Windows.Forms.Keys.D2);
            RegisterHotKey((int)this.Handle, 2, 0x2, (int)System.Windows.Forms.Keys.D3);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        { // 핫키 해제
            UnregisterHotKey((int)this.Handle, 0);
            UnregisterHotKey((int)this.Handle, 1);
            UnregisterHotKey((int)this.Handle, 2);
        }

        protected override void WndProc(ref Message m)
        {
            if(m.Msg == (int)0x312) // 핫키를 누르면 312라는 번호를 가진 메시지를 받는다.
            {
                if (m.WParam == (IntPtr)0x0)
                {
                    MessageBox.Show(Clipboard.GetText(), "현재 클립보드의 내용");
                }
                if(m.WParam == (IntPtr)0x1)
                {
                    if(Clipboard.GetText() != null)
                    {
                        ChromeOptions options = new ChromeOptions();
                        options.AddArgument("headless");
                        ChromeDriverService service = ChromeDriverService.CreateDefaultService();
                        service.HideCommandPromptWindow = true; 
                        using (driver = new ChromeDriver(service, options))
                        {
                            driver.Url = "http://papago.naver.com/";
                            Thread.Sleep(300);
                            driver.FindElement(By.Id("txtSource")).SendKeys(Clipboard.GetText());
                            string result = Clipboard.GetText();

                            if (result.Length > 1000) Thread.Sleep(2000);
                            else if (result.Length > 700) Thread.Sleep(1600);
                            else if (result.Length > 400) Thread.Sleep(1300);
                            else Thread.Sleep(1000);
                            MessageBox.Show(driver.FindElement(By.Id("targetEditArea")).Text, "------ 네이버 파파고 번역 ------" + result.Length + "자");
                        }
                    }
                }

                if(m.WParam == (IntPtr)0x2)
                {
                    MessageBox.Show("엔터를 누르면 번역 프로그램이 종료됩니다.", "------ 네이버 파파고 종료 ------");
                    this.Close();
                }
            }
            base.WndProc(ref m);
        }
    }
}
