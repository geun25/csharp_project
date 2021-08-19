using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Tcp_Server_exe
{
    class Program
    {
        static void Main(string[] args)
        {
            RunServer();
            Console.ReadLine();
        }

        async static void RunServer() // Async는 컴파일러에게 해당 메서드에 await가 존재한다는것을 알려줌.
        {
            int BUFF_SIZE = 1024;
            TcpListener listener = new TcpListener(IPAddress.Any, 9999);
            listener.Start();

            while (true)
            {
                TcpClient tc = await listener.AcceptTcpClientAsync(); // 비동기 실행

                NetworkStream stream = tc.GetStream();

                // 데이터 크기 수신
                byte[] bytes = new byte[4];
                int nb = await stream.ReadAsync(bytes, 0, bytes.Length);
                int total = BitConverter.ToInt32(bytes, 0);

                // 실제 데이터 수신
                string filename = "Hello.exe";
                using (var fs = new FileStream(filename, FileMode.CreateNew))
                {
                    var buff = new byte[BUFF_SIZE];
                    int received = 0;
                    while (received < total)
                    {
                        int n = total - received >= BUFF_SIZE ? BUFF_SIZE : total - received;
                        nb = await stream.ReadAsync(buff, 0, n);
                        received += nb;

                        await fs.WriteAsync(buff, 0, nb);
                    }
                }
                stream.Close();
                tc.Close();
            }
        }
    }
}
