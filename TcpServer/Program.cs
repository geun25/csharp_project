using System;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace Tcp_Server
{
    class Program
    {
        static void Main(string[] args)
        {
            RunServer();
            Console.ReadLine();
        }

        async static void RunServer()
        {
            int BUFF_SIZE = 1024;
            TcpListener listener = new TcpListener(IPAddress.Any, 9999);
            listener.Start();

            while(true)
            {
                TcpClient tc = await listener.AcceptTcpClientAsync(); // await : 해당 구문을 만나면 멈추지 않고 반복 메시지 루프를 계속 돌도록 함.
                                                                      // 이 코드가 종료되지 않아도 그 다음 코드가 동작(비동기 실행)
                NetworkStream stream = tc.GetStream(); // 해당 연결에서 스트림을 가져옴.

                // 데이터 크기 수신
                byte[] bytes = new byte[4];
                int nb = await stream.ReadAsync(bytes, 0, bytes.Length); // stream에서 비동기로 bytes 배열을 가져옴.
                if(nb != 4)
                {
                    throw new ApplicationException("Invalid size");
                }

                int total = BitConverter.ToInt32(bytes, 0);

                // 실제 데이터 수신
                string filename = Guid.NewGuid().ToString("N") + ".png";
                using (var fs = new FileStream(filename, FileMode.CreateNew)) // 자동으로 Dipose 메서드 호출하여 파일을 닫아줌.
                {
                    var buff = new byte[BUFF_SIZE];
                    int received = 0;
                    while(received < total)
                    {
                        int n = total - received >= BUFF_SIZE ? BUFF_SIZE : total - received; // 만약 버퍼 크기보다 수신 받을 데이터가 적을 경우, 그 남은 수신 데이터 양만큼만 받도록 하는 조건문
                        nb = await stream.ReadAsync(buff, 0, n);
                        received += nb;

                        await fs.WriteAsync(buff, 0, nb);
                    }
                }

                byte[] result = new byte[1];
                result[0] = 1;
                await stream.WriteAsync(result, 0, result.Length);
                stream.Close();
                tc.Close();
            }
        }
    }
}
