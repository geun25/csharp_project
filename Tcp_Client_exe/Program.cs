using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Tcp_Client_exe
{
    class Program
    {
        static string name = "";
        static string path = @"C:\Users\jin yeong\.vscode\csharp_project\Tcp_Client_exe\bin\Debug";

        static void Main(string[] args)
        {
            Console.WriteLine("전송할 파일의 이름을 입력하세요.");
            name = Console.ReadLine();
            path = path + name + ".exe";

            SendData();
        }

        static void SendData()
        {
            int port = 9999;
            string server = "127.0.0.1";
            int buff_size = 1024;

            FileStream file = new FileStream(@"" + path, FileMode.Open);
            int filelength = Convert.ToInt32(file.Length);
            byte[] data = new byte[filelength];
            file.Read(data, 0, filelength);

            TcpClient tcpClient = new TcpClient();
            tcpClient.Connect(server, port);
            byte[] filesize = BitConverter.GetBytes(data.Length);

            using(NetworkStream stream = tcpClient.GetStream())
            {
                stream.Write(filesize, 0, filesize.Length);

                int end = data.Length;
                int start = 0;

                while (start < end)
                {
                    int index = end - start >= buff_size ? buff_size : end - start;
                    stream.Write(data, start, index);
                    start += index;
                }
            }
            file.Close();
            tcpClient.Close();
        }
    }
}
