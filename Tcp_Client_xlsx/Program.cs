using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using System.Net.Sockets;
using System.IO;
using Microsoft.Office.Interop.Excel;

namespace Tcp_Client_xlsx
{
    class Program
    {
        static void Main(string[] args)
        {
            int BUFF_SIZE = 1024;
            string server = "127.0.0.1";
            int port = 9999;

            List<string> testData = new List<string> { "Excel", "Access", "Word", "OneNote" };

            // 엑셀에 필요한 변수들 초기화
            Excel.Application excelApp = null;
            Excel.Workbook wb = null;
            Excel.Worksheet ws = null;

            // Excel 첫번째 Worksheet 가져오기
            excelApp = new Excel.Application();
            wb = excelApp.Workbooks.Add();
            ws = wb.Worksheets.get_Item(1) as Excel.Worksheet;

            // 데이터 넣기
            int r = 1;
            foreach (var d in testData)
            {
                ws.Cells[r, 1] = d;
                r++;
            }

            // 엑셀 파일 저장
            wb.SaveAs(@"C:\Users\jin yeong\.vscode\csharp_project\Tcp_Client_xlsx\test.xlsx", Excel.XlFileFormat.xlWorkbookNormal);

            wb.Close(true);
            excelApp.Quit();
            ReleaseExcelObject(ws);
            ReleaseExcelObject(wb);
            ReleaseExcelObject(excelApp);

            byte[] fileBytes = ReadFile(@"C:\Users\jin yeong\.vscode\csharp_project\Tcp_Client_xlsx\test.xlsx");

            TcpClient tc = new TcpClient(server, port);
            byte[] nbytes = BitConverter.GetBytes(fileBytes.Length);

            using (NetworkStream stream = tc.GetStream())
            {
                // 데이터 크기 전달
                stream.Write(nbytes, 0, nbytes.Length);

                // 실제 데이터 전달
                int end = fileBytes.Length;
                int start = 0;
                while (start < end)
                {
                    int n = end - start >= BUFF_SIZE ? BUFF_SIZE : end - start;
                    stream.Write(fileBytes, start, n);
                    start += n;
                }

                // 결과 수신
                byte[] result = new byte[1];
                stream.Read(result, 0, result.Length);
                Console.WriteLine(result[0]);
            }
            
            tc.Close();
        }

        private static void ReleaseExcelObject(object obj)
        {
            try
            {
                if (obj != null)
                {
                    Marshal.ReleaseComObject(obj);
                    obj = null;
                }
            }
            catch(Exception ex)
            {
                obj = null;
                throw ex;
            }
            finally
            {
                GC.Collect();
            }
        }

        private static byte[] ReadFile(string filePath)
        {
            FileStream fs = new FileStream(filePath, FileMode.Open);
            int length = Convert.ToInt32(fs.Length); // 파라미터가 null일때 int.Parse는 예외처리하는 반면 Convert.TOInt32는 0을 반환한다.
            byte[] data = new byte[length];
            fs.Read(data, 0, length);
            fs.Close();
            return data;
        }
    }
}
