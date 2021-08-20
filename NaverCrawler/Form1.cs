using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;


namespace NaverCrawler
{
    public partial class Form1 : Form
    {
        string result1, result2, result3, result4, result5, result6, result7, result8;

        public Form1()
        {
            InitializeComponent();
        }      

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ChromeDriverService service = ChromeDriverService.CreateDefaultService();
            service.HideCommandPromptWindow = true;
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("headless");

            IWebDriver driver = new ChromeDriver(service, options);
            driver.Url = "https://www.naver.com";
            driver.FindElement(By.Name("query")).SendKeys(textBox1.Text);
            driver.FindElement(By.Id("search_btn")).Click();

            listBox1.Items.Clear();
            listBox2.Items.Clear();

            try
            {
                driver.FindElement(By.XPath("//*[@id=\"main_pack\"]/section[4]/div/div[1]/div/div[1]/a[2]")).Click();

                listBox1.Items.Add(driver.FindElement(By.XPath("//*[@id=\"sp_blog_1\"]/div/div/a")).Text);
                result1 = driver.FindElement(By.XPath("//*[@id=\"sp_blog_1\"]/div/div/div[2]/div/a/div")).Text;
                listBox1.Items.Add(driver.FindElement(By.XPath("//*[@id=\"sp_blog_2\"]/div/div/a")).Text);
                result2 = driver.FindElement(By.XPath("//*[@id=\"sp_blog_2\"]/div/div/div[2]/div/a/div")).Text;
                listBox1.Items.Add(driver.FindElement(By.XPath("//*[@id=\"sp_blog_3\"]/div/div/a")).Text);
                result3 = driver.FindElement(By.XPath("//*[@id=\"sp_blog_3\"]/div/div/div[2]/div/a/div")).Text;
                listBox1.Items.Add(driver.FindElement(By.XPath("//*[@id=\"sp_blog_4\"]/div/div/a")).Text);
                result4 = driver.FindElement(By.XPath("//*[@id=\"sp_blog_4\"]/div/div/div[2]/div/a/div")).Text;

            }
            catch { listBox1.Items.Add("블로그가 없습니다."); }

            try
            {
                listBox1.Items.Add(driver.FindElement(By.XPath("//*[@id=\"sp_blog_1\"]/div/div/a")).Text);
                result5 = driver.FindElement(By.XPath("//*[@id=\"sp_blog_1\"]/div/div/div[2]/div/a/div")).Text;
                listBox1.Items.Add(driver.FindElement(By.XPath("//*[@id=\"sp_blog_2\"]/div/div/a")).Text);
                result6 = driver.FindElement(By.XPath("//*[@id=\"sp_blog_2\"]/div/div/div[2]/div/a/div")).Text;
                listBox1.Items.Add(driver.FindElement(By.XPath("//*[@id=\"sp_blog_3\"]/div/div/a")).Text);
                result7 = driver.FindElement(By.XPath("//*[@id=\"sp_blog_3\"]/div/div/div[2]/div/a/div")).Text;
                listBox1.Items.Add(driver.FindElement(By.XPath("//*[@id=\"sp_blog_4\"]/div/div/a")).Text);
                result8 = driver.FindElement(By.XPath("//*[@id=\"sp_blog_4\"]/div/div/div[2]/div/a/div")).Text;
            }

            catch { listBox2.Items.Add("동영상이 없습니다."); }
            driver.Close();               
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ChromeDriverService service = ChromeDriverService.CreateDefaultService();
            service.HideCommandPromptWindow = true;
            IWebDriver driver = new ChromeDriver(service);

            if(listBox1.SelectedItem != null && listBox2.SelectedItem != null)
            {
                if (listBox1.SelectedIndex.Equals(0)) driver.Url = "https://" + result1;
                else if (listBox1.SelectedIndex.Equals(1)) driver.Url = "https://" + result2;
                else if (listBox1.SelectedIndex.Equals(2)) driver.Url = "https://" + result3;
                else if (listBox1.SelectedIndex.Equals(3)) driver.Url = "https://" + result4;               
            }

            else if (listBox2.SelectedItem != null && listBox1.SelectedItem != null)
            {
                if (listBox1.SelectedIndex.Equals(0)) driver.Url = "https://" + result5;
                else if (listBox2.SelectedIndex.Equals(1)) driver.Url = "https://" + result6;
                else if (listBox2.SelectedIndex.Equals(2)) driver.Url = "https://" + result7;
                else if (listBox2.SelectedIndex.Equals(3)) driver.Url = "https://" + result8;
            }

            if (driver.Manage().Window == null) driver.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listBox1.SelectedItem = null;
            listBox2.SelectedItem = null;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                Process[] process = new Process[100];
                process = Process.GetProcessesByName("chrome");
                foreach (Process x in process) x.Kill();
                process = Process.GetProcessesByName("chromedriver");
                foreach (Process x in process) x.Kill();
                process = Process.GetProcessesByName("conhost");
                foreach (Process x in process) x.Kill();
            }
            catch { }
        }
    }
}
