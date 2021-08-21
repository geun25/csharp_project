using System.IO;
using System.ServiceProcess;
using System.Timers;

namespace WindowsService
{
    public partial class Service1 : ServiceBase
    {
        private Timer timer;
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            timer = new Timer();
            timer.Interval = 1000;
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            // 실행로직
            File.AppendAllText(@"C:\Users\jin yeong\.vscode\csharp_project\WindowsService\test.txt", "안녕하세요\n");
        }

        protected override void OnStop()
        {
            timer.Stop();
        }
    }
}
