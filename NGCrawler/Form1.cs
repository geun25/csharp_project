using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace NGCrawler
{
    public partial class Form1 : Form
    {
        IWebDriver driver;
        ChromeDriverService service;
        ChromeOptions option;
        ArrayList searchArray = new ArrayList();
        ArrayList videoArray = new ArrayList();
        ArrayList searchArray2 = new ArrayList();
        ArrayList videoArray2 = new ArrayList();

        public Form1()
        {           
            InitializeComponent();
            service = ChromeDriverService.CreateDefaultService();
            service.HideCommandPromptWindow = true; // 프롬프트 창 비활성화
            option = new ChromeOptions();
            option.AddArgument("headless"); // 웹 브라우저 창 비활성화

            Search_Btn.Click += Search_Btn_Click;
            Search_Tbx.KeyDown += Search_Tbx_KeyDown;
        }

        private void Search_Btn_Click(object sender, EventArgs e)
        {
            if (Search_Tbx.Text == "") return;
            using(driver = new ChromeDriver(service, option))
            {
                Search_Lbx.Items.Clear();
                Video_Lbx.Items.Clear();          
                Search_Lbx2.Items.Clear();
                Video_Lbx2.Items.Clear();
                searchArray.Clear();
                videoArray.Clear();
                searchArray2.Clear();
                videoArray2.Clear();

                string encode = Search_Tbx.Text;
                string googleEncode = "";
                if (radioButton1.Checked) googleEncode = HttpUtility.UrlEncode(Search_Tbx.Text);
                else if (radioButton2.Checked) googleEncode = HttpUtility.UrlEncode("intitle" + Search_Tbx.Text);
                else if (radioButton3.Checked) googleEncode = HttpUtility.UrlEncode("intext" + Search_Tbx.Text);
                else if (radioButton4.Checked) googleEncode = HttpUtility.UrlEncode("filetype" + Search_Tbx.Text);
                else if (radioButton5.Checked) googleEncode = HttpUtility.UrlEncode("\"" + Search_Tbx.Text + "\"");

                // 구글 통합
                try
                {
                    driver.Url = "http://google.co.kr/search?q=" + googleEncode;
                    List<IWebElement> elements = driver.FindElement(By.Id("search")).FindElements(By.ClassName("g")).ToList();
                    foreach(IWebElement x in elements)
                    {
                        Search_Lbx.Items.Add(x.Text);
                        searchArray.Add(x.FindElement(By.ClassName("r")).FindElement(By.TagName("a")).GetAttribute("href"));
                    }
                    driver.FindElement(By.XPath("//*[@id=\"xjs\"]/table/tbody/tr/td[3]/a")).Click();

                    elements = driver.FindElement(By.Id("search")).FindElements(By.ClassName("g")).ToList();
                    foreach (IWebElement x in elements)
                    {
                        Search_Lbx.Items.Add(x.Text);
                        searchArray.Add(x.FindElement(By.ClassName("r")).FindElement(By.TagName("a")).GetAttribute("href"));
                    }
                }
                catch { }

                // 구글 동영상
                try
                {
                    driver.Url = "http://google.co.kr/search?q=" + googleEncode + "&hl=ko&tbm=vid";
                    List<IWebElement> elements = driver.FindElement(By.Id("search")).FindElements(By.ClassName("g")).ToList();
                    foreach (IWebElement x in elements)
                    {
                        Video_Lbx.Items.Add(x.Text);
                        videoArray.Add(x.FindElement(By.ClassName("r")).FindElement(By.TagName("a")).GetAttribute("href"));
                    }
                }
                catch { }

                // 네이버 동영상
                try
                {
                    driver.Url = "https://search.naver.com/search.naver?where=video&sm=tab_jum&query=" + encode;
                    List<IWebElement> elements = driver.FindElement(By.XPath()).FindElements(By.TagName("li")).ToList();
                    foreach (IWebElement x in elements)
                    {
                        Video_Lbx2.Items.Add(x.FindElement(By.ClassName("title")).Text);
                        videoArray2.Add(x.FindElement(By.ClassName("title")).GetAttribute("href"));
                    }
                }
                catch { }

                // 네이버 통합
                try
                {
                    if(Post_Rbn.Checked) // 포스트
                    {
                        driver.Url = "https://post.naver.com/search/post.naver?keyword=" + encode;
                        List<IWebElement> elements = driver.FindElement(By.Id("el_list_container")).FindElements(By.TagName("li")).ToList();
                        foreach (IWebElement x in elements)
                        {
                            Search_Lbx2.Items.Add(x.FindElement(By.ClassName("feed_body")).Text);
                            searchArray2.Add(x.FindElement(By.ClassName("feed_body")).FindElement(By.ClassName("link_end")).GetAttribute("href"));
                        }
                    }

                    else if(Blog_Rbn.Checked) // 블로그
                    {
                        driver.Url = "https://search.naver.com/search.naver?where=post&sm=tab_jum&query=" + encode;
                        for (int i = 1; i < 21; i++)
                        {
                            Search_Lbx2.Items.Add(driver.FindElement(By.Id("main_pack")).FindElement(By.Id("")).FindElement(By.XPath("")).Text);
                            searchArray2.Add(x.FindElement(By.ClassName("title")).GetAttribute("href"));
                        }
                    }

                    else if(Cafe_Rbn.Checked) // 카페
                    {
                        driver.Url = "https://search.naver.com/search.naver?where=cafe&sm=tab_jum&query=" + encode;
                        List<IWebElement> elements = driver.FindElement(By.Id("main_pack")).FindElement(By.Id("")).FindElements(By.TagName("li")).ToList();
                        foreach (IWebElement x in elements)
                        {
                            Search_Lbx2.Items.Add(x.FindElement(By.ClassName("sh_cafe_title")).Text);
                            searchArray2.Add(x.FindElement(By.ClassName("sh_cafe_title")).GetAttribute("href"));
                        }
                    }

                    else if(News_Rbn.Checked) // 뉴스
                    {
                        driver.Url = "https://search.naver.com/search.naver?where=video&sm=tab_jum&query=" + encode;
                        List<IWebElement> elements = driver.FindElement(By.XPath()).FindElements(By.TagName("li")).ToList();
                        foreach (IWebElement x in elements)
                        {
                            Search_Lbx2.Items.Add(x.FindElement(By.ClassName("title")).Text);
                            searchArray2.Add(x.FindElement(By.ClassName("title")).GetAttribute("href"));
                        }
                    }
                }
                catch { }



            }

        }

        private void Search_Tbx_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == System.Windows.Forms.Keys.Enter)
                Search_Btn_Click(sender, e)
        }
    }
}
