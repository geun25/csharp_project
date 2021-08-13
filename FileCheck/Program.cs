using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileCheck
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("검색 경로를 입력하세요: ");
            string result1 = Console.ReadLine();
            Console.WriteLine("파일 확장자를 입력하세요: ");
            string result2 = Console.ReadLine();

            FileHandle file_h = new FileHandle();
            file_h.FileCheck(result1, result2);
        }
    }

    class FileHandle
    {
        public void FileCheck(string path, string file)
        {
            string[] files = Directory.GetFiles(path, $"*.{file}", SearchOption.AllDirectories);

            Console.WriteLine("--------------------------" + Environment.NewLine);
            foreach (string s in files)
            {
                FileInfo file_info = new FileInfo(s);
                if (file_info.Length > 10000)
                {
                    Console.WriteLine(file_info.Name);
                    Console.WriteLine(file_info.DirectoryName);
                    Console.WriteLine(file_info.Length);
                }                
            }
            Console.Read();
        }
    }
}
