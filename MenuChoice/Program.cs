using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;


namespace MenuChoice
{
    class Program
    {
        public static void ChoiceStart(string data)
        {
            Console.WriteLine();
            Console.WriteLine("------------------------" + Environment.NewLine);
            Console.WriteLine("먹은 음식의 빈도 분석..." + Environment.NewLine);
            Console.WriteLine("------------------------" + Environment.NewLine);
            if (File.Exists(@"C:\Users\jin yeong\.vscode\csharp_project\MenuChoice\Menu.xlsx"))
            {
                Console.WriteLine("데이터베이스 존재, 이전에 먹은 메뉴를 참고하여 분석...");
                Excel.Application xlApp = new Excel.Application();
                Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(@"C:\Users\jin yeong\.vscode\csharp_project\MenuChoice\Menu.xlsx");

                Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
                xlWorksheet.Cells[6, 1] = data;
                Excel.Range xlRange = xlWorksheet.UsedRange;
                xlWorkbook.Save();
                xlWorkbook.Application.ActiveWorkbook.Saved = true; // 파일을 읽어와서 저장하고 끌때 저장여부를 물어보는 창을 띄우는지 마는지

                int rowCount = xlRange.Rows.Count;
                int colCount = xlRange.Columns.Count;

                string[] result = new string[10];

                Console.WriteLine(Environment.NewLine);
                for (int i = 1; i <= rowCount; i++)
                {
                    if (xlRange.Cells[i, 1] != null && xlRange.Cells[i, 1].Value2 != null)
                    {
                        result[i - 1] = xlRange.Cells[i, 1].Value2.ToString();
                    }
                }

                Console.WriteLine();
                xlWorkbook.Close();
                xlWorkbook = null;
                if (xlApp != null)
                {
                    Process[] pProcess;
                    pProcess = Process.GetProcessesByName("HCell");
                    pProcess[0].Kill();
                }
                Console.WriteLine("------------------------");
                Console.WriteLine("먹은 음식 리스트");
                Console.WriteLine("------------------------" + Environment.NewLine);
                foreach (string x in result)
                {
                    if (x != null)
                        Console.WriteLine(x);
                }

                int bigcnt = 0;
                string bigmenu = "";
                for (int i = 0; i < result.Length; i++)
                {
                    if (result[i] != null)
                    {
                        int cnt = 0;
                        for (int j = 0; j < result.Length; j++)
                        {
                            if (result[i] == result[j])
                                cnt++;
                        }
                        if (cnt > bigcnt)
                        {
                            bigcnt = cnt;
                            bigmenu = result[i];
                        }
                    }
                }
                Console.WriteLine();
                Console.WriteLine($"최근에 가장 많이 드신 메뉴는 {bigmenu}이며, 총 {bigcnt}회 드셨습니다.");
                Console.WriteLine();

                while (true)
                {
                    Console.WriteLine();
                    Console.WriteLine($"{bigmenu}를 드시겠습니까? 드시려면 1번, 랜덤으로 다시 선택하려면 2번을 눌러주세요.");
                    string result1 = Console.ReadLine();
                    if (result1 == "1")
                    {
                        Console.WriteLine();
                        Console.WriteLine("웹페이지에서 해당 메뉴를 검색하여 이미지를 찾습니다.");
                        Console.WriteLine();
                        IWebDriver handler = new ChromeDriver();
                        handler.Url = "https://www.google.co.kr/";
                        handler.FindElement(By.Name("q")).SendKeys(bigmenu);
                        handler.FindElement(By.XPath("/html/body/div[1]/div[3]/form/div[1]/div[1]/div[3]/center/input[1]")).Click();
                        handler.FindElement(By.XPath("//*[@id=\"hdtb - msb\"]/div[1]/div/div[2]/a")).Click();
                        break;
                    }
                    else if (result1 == "2")
                    {
                        string NoMenu = "";
                        Console.WriteLine();
                        Console.WriteLine("랜덤으로 메뉴를 골라드립니다. ");
                        Console.WriteLine("혹시 드시지 않는 메뉴가 있으면 입력해주세요. ");
                        NoMenu = Console.ReadLine();
                        int index = 0;
                        List<string> menu = new List<string>() { "한식", "중식", "일식", "양식", "국수", "냉면", "김치찌개", "된장찌개", "피자", "햄버거" };
                        Random random = new Random();
                        index = random.Next(1, menu.Count - 1);
                        Console.WriteLine();
                        Console.WriteLine($"오늘의 메뉴는 {menu[index]}입니다.");
                        Console.ReadLine();
                        break;
                    }
                    else
                        Console.WriteLine("잘못 선택하셨습니다.");
                }
            }

            else
            {
                Console.WriteLine("데이터베이스가 없습니다. 새로운 데이터베이스를 생성합니다.");
                Excel.Application xlApp = new Excel.Application();
                xlApp.Workbooks.Add();
                Excel._Worksheet workSheet = xlApp.ActiveSheet;
                workSheet.SaveAs(@"C:\Users\jin yeong\.vscode\csharp_project\MenuChoice\Menu.xlsx");
                Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(@"C:\Users\jin yeong\.vscode\csharp_project\MenuChoice\Menu.xlsx");

                Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
                xlWorksheet.Cells[DateTime.Now, 1] = data;
                Excel.Range xlRange = xlWorksheet.UsedRange;
                xlWorkbook.Save();
                xlWorkbook.Application.ActiveWorkbook.Saved = true; // 파일을 읽어와서 저장하고 끌때 저장여부를 물어보는 창을 띄우는지 마는지

                int rowCount = xlRange.Rows.Count;
                int colCount = xlRange.Columns.Count;

                string[] result = new string[10];

                Console.WriteLine(Environment.NewLine);
                for (int i = 1; i <= rowCount; i++)
                {
                    if (xlRange.Cells[i, 1] != null && xlRange.Cells[i, 1].Value2 != null)
                    {
                        result[i - 1] = xlRange.Cells[i, 1].Value2.ToString();
                    }
                }

                Console.WriteLine();
                xlWorkbook.Close();
                xlWorkbook = null;
                if (xlApp != null)
                {
                    Process[] pProcess;
                    pProcess = Process.GetProcessesByName("HCell");
                    pProcess[0].Kill();
                }
                Console.WriteLine("------------------------");
                Console.WriteLine("먹은 음식 리스트");
                Console.WriteLine("------------------------" + Environment.NewLine);
                foreach (string x in result)
                {
                    if (x != null)
                        Console.WriteLine(x);
                }

                int bigcnt = 0;
                string bigmenu = "";
                for (int i = 0; i < result.Length; i++)
                {
                    if (result[i] != null)
                    {
                        int cnt = 0;
                        for (int j = 0; j < result.Length; j++)
                        {
                            if (result[i] == result[j])
                                cnt++;
                        }
                        if (cnt > bigcnt)
                        {
                            bigcnt = cnt;
                            bigmenu = result[i];
                        }
                    }
                }
                Console.WriteLine();
                Console.WriteLine($"최근에 가장 많이 드신 메뉴는 {bigmenu}이며, 총 {bigcnt}회 드셨습니다.");
                Console.WriteLine();

                while (true)
                {
                    Console.WriteLine();
                    Console.WriteLine($"{bigmenu}를 드시겠습니까? 드시려면 1번, 랜덤으로 다시 선택하려면 2번을 눌러주세요.");
                    string result1 = Console.ReadLine();
                    if (result1 == "1")
                    {
                        Console.WriteLine();
                        Console.WriteLine("웹페이지에서 해당 메뉴를 검색하여 이미지를 찾습니다.");
                        Console.WriteLine();
                        IWebDriver handler = new ChromeDriver();
                        handler.Url = "https://www.google.co.kr/";
                        handler.FindElement(By.Name("q")).SendKeys(bigmenu);
                        handler.FindElement(By.XPath("/html/body/div[1]/div[3]/form/div[1]/div[1]/div[3]/center/input[1]")).Click();
                        handler.FindElement(By.XPath("//*[@id=\"hdtb - msb\"]/div[1]/div/div[2]/a")).Click();
                        break;
                    }
                    else if (result1 == "2")
                    {
                        string NoMenu = "";
                        Console.WriteLine();
                        Console.WriteLine("랜덤으로 메뉴를 골라드립니다. ");
                        Console.WriteLine("혹시 드시지 않는 메뉴가 있으면 입력해주세요. ");
                        NoMenu = Console.ReadLine();
                        int index = 0;
                        List<string> menu = new List<string>() { "한식", "중식", "일식", "양식", "국수", "냉면", "김치찌개", "된장찌개", "피자", "햄버거" };
                        Random random = new Random();
                        index = random.Next(1, menu.Count - 1);
                        Console.WriteLine();
                        Console.WriteLine($"오늘의 메뉴는 {menu[index]}입니다.");
                        Console.ReadLine();
                        break;
                    }
                    else
                        Console.WriteLine("잘못 선택하셨습니다.");
                }
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("먹은 음식을 입력하세요. ");
            string food = Console.ReadLine();
            Console.WriteLine("Creating Excel document in new way...");
            ChoiceStart(food);          
        }
    }
}
