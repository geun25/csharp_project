using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            // 돈을 넣는 행위 - 입력
            // 물건을 선택하는 행위 - 처리
            // 물건을 받는 행위 - 출력
            // 거스름돈 계산 - 처리
            // 거스름돈 반환 - 출력
            Console.WriteLine("Insert coin...");
            int coin = int.Parse(Console.ReadLine());
            while(true)
            {
                Console.WriteLine(Environment.NewLine + "Choice your beverage..." + Environment.NewLine + "1. Coffee / 2. Milk / 3. insert extra money / 0. Finish ");
                int choice = int.Parse(Console.ReadLine());

                if(choice == 3)
                {
                    Console.WriteLine("Insert coin...");
                    int extra = int.Parse(Console.ReadLine());
                    coin += extra;
                }
                if(choice == 0)
                {
                    Console.WriteLine($"Change is {coin}...");
                    break;
                }
                else  if(choice == 1 && coin >= 300)
                {                 
                    Console.WriteLine("Making Coffee...");
                    coin -= 300;
                    Console.WriteLine($"extra money is {coin}");
                }
                else if(choice == 2 && coin >= 400)
                {
                    Console.WriteLine("Making Milk...");
                    coin -= 400;
                    Console.WriteLine($"extra money is {coin}");
                }
                else if((choice == 1 && coin < 300) || (choice == 2 && coin < 400))
                {
                    Console.WriteLine("Lack of balance! Would you like to put in extra money?" + Environment.NewLine + "1 . Yes / 2. No");
                    int result = int.Parse(Console.ReadLine());
                    if(result == 1)
                    {
                        Console.WriteLine("Insert coin...");
                        coin += int.Parse(Console.ReadLine());
                    }
                    else                     
                        Console.WriteLine($"Change is {coin}...");                    
                }
            }    
        }
    }
}
