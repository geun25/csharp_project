using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessCheck
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("번호를 입력하세요." + Environment.NewLine + "1번 - 전체 Process / 2번 - 개별 Precess");
            string result = Console.ReadLine();
            if(result == "1")
            {
                try
                {
                    Process[] allprocess = Process.GetProcesses();
                    int a = 1;
                    Console.WriteLine("--------- 모든 프로세스 정보 ---------");
                    Console.WriteLine($"현재 실행중인 모든 프로세스 숫자 : {allprocess.Length}");

                    foreach(Process p in allprocess)
                    {
                        try
                        {
                            Console.WriteLine($"--------- {a++}번쨰 프로세스 ---------");
                            ProcessInfo(p);
                            Console.WriteLine();
                        }
                        catch
                        {

                        }
                    }
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                Console.ReadLine();
            }

            else if(result == "2")
            {
                Console.WriteLine("프로세스의 이름을 입력하십시오 : ");
                string result2 = Console.ReadLine();
                foreach(var process in Process.GetProcessesByName(result2))
                {
                    Console.WriteLine($"Process : {process.ProcessName}");
                    Console.WriteLine($"시작 시간 : {process.StartTime}");
                    Console.WriteLine($"Process ID : {process.Id}");
                    Console.WriteLine($"메모리 : {process.VirtualMemorySize}");
                    Console.WriteLine($"Process Path : {process.MainModule.FileName}");
                }
            }
        }

        static void ProcessInfo(Process processinfo)
        {
            Console.WriteLine($"Process : {processinfo.ProcessName}");
            Console.WriteLine($"시작 시간 : {processinfo.StartTime}");
            Console.WriteLine($"Process ID : {processinfo.Id}");
            Console.WriteLine($"메모리 : {processinfo.VirtualMemorySize}");
            Console.WriteLine($"Process Path : {processinfo.MainModule.FileName}");
        }
    }
}
