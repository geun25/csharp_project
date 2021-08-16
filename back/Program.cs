using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace back
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread.Sleep(1000);
            Console.WriteLine("안녕하세요.");

            Thread.Sleep(1000);
            Console.WriteLine("반갑습니다.");

            Thread.Sleep(1000);
            Console.WriteLine("좋은 하루 되세요.");
        }
    }
}
