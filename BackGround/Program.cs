using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackGround
{
    // back.exe 프로세스가 종료될 때까지 대기 후에 출력결과를 모두 읽어와서 한번에 출력.
    // 어떤 파일을 실행하며 긴 작업을 할 경우, 결과 값만 가져와서 출력하고 싶을 때 이 방법을 사용.
    class Program
    {
        static void Main(string[] args)
        {
            string ApplicationPath = @"C:\Users\jin yeong\.vscode\csharp_project\back\obj\Debug\back.exe";
            Process process = new Process();
            process.StartInfo.FileName = ApplicationPath;

            //옵션
            process.StartInfo.UseShellExecute = false; // 스트림을 읽는데 필요
            process.StartInfo.CreateNoWindow = false; // 새 창에서 시작하지 않음
            process.StartInfo.RedirectStandardOutput = true; // 실행시킨 프로그램의 출력을 얻음
            process.Start();
            process.WaitForExit(); // 종료시까지 대기
            string Result = process.StandardOutput.ReadToEnd(); // 실행시킨 프로그램의 출력을 읽음
            Console.WriteLine(Result);
            Console.ReadLine();
        }
    }
}
