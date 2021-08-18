using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Tcp_Client
{
    class Program
    {
        static void Main(string[] args)
        {
            int BUFF_SIZE = 1024;
            string server = "127.0.0.1";
            int port = 9999;

            TcpClient tc = new TcpClient(server, port);
            Bitmap bmp = ScreenCapture();

            var imgconv = new ImageConverter();
            byte[] imgbytes = (byte[])imgconv.ConvertTo(bmp, typeof(byte[])); // bitmap 파일을 byte배열로 변환
            byte[] nbytes = BitConverter.GetBytes(imgbytes.Length);

            using (NetworkStream stream = tc.GetStream())
            {
                // 데이터 크기 전달
                stream.Write(nbytes, 0, nbytes.Length);

                // 실제 데이터 전달
                int end = imgbytes.Length;
                int start = 0;
                while(start < end)
                {
                    int n = end - start >= BUFF_SIZE ? BUFF_SIZE : end - start;
                    stream.Write(imgbytes, start, n);
                    start += n;
                }

                // 결과 수신
                byte[] result = new byte[1];
                stream.Read(result, 0, result.Length);
                Console.WriteLine(result[0]);
            }
            tc.Close();
        }
        static Bitmap ScreenCapture() // 개체를 따로 만들지 않아도 되는 메서드
        {
            Rectangle rect = Screen.PrimaryScreen.Bounds;
            Bitmap scrbmp = new Bitmap(rect.Width, rect.Height);
            using (Graphics g = Graphics.FromImage(scrbmp))
            {
                g.CopyFromScreen(rect.X, rect.Y, 0, 0, scrbmp.Size, CopyPixelOperation.SourceCopy);
            }
            return scrbmp;
        }
    }
}
