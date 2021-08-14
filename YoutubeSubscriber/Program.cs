using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace YoutubeSubscriber
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("채널 주소를 입력하세요.");
            string churl = Console.ReadLine();
            Console.WriteLine("구독자 조회 프로그램을 실행합니다." + Environment.NewLine + Environment.NewLine);
            
            IWebDriver driver = new ChromeDriver();
            driver.Url = churl;
            string cnt = driver.FindElement(By.Id("subscriber-count")).Text;
            driver.Close();

            Console.WriteLine();
            Console.WriteLine(DateTime.Now + $"구독자 수는 {cnt}명 입니다.");
        }
    }
}
