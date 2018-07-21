using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Threading;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace FNTrackerRefresh
{
    class Program
    {
        private static readonly HttpClient client = new HttpClient();
        static string platform = "pc";
        static string username = "username";

        public static void LogProcesses()
        {
            foreach (Process clsProcess in Process.GetProcesses())
            {
                Console.WriteLine(clsProcess.ProcessName);
            }
        }

        public static bool IsProcessOpen(string name)
        {
            foreach (Process clsProcess in Process.GetProcesses())
            {
                if (clsProcess.ProcessName.Contains(name))
                {
                    return true;
                }
            }

            return false;
        }

        async static void TryRefresh()
        {
            var responseString = await client.GetStringAsync("https://fortnitetracker.com/profile/pc/jam1garner");
        }

        static void Main(string[] args)
        {
            if (args.Length > 0 && args[0] == "install") {
                string appPath = new Uri(Assembly.GetAssembly(typeof(Program)).CodeBase).LocalPath;
                File.Copy(appPath,
                    Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Startup), Path.GetFileName(Assembly.GetAssembly(typeof(Program)).CodeBase)),
                    true);
                return;
            }
            string appDir = Path.GetDirectoryName(
                     Assembly.GetAssembly(typeof(Program)).CodeBase);
            string txtPath = Path.Combine(appDir, "fortnite_info.txt");
            if(!File.Exists(txtPath))
                txtPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "fortnite_info.txt");
            if (File.Exists(txtPath))
            {
                var lines = File.ReadAllLines(txtPath);
                if(lines.Length >= 2)
                {
                    platform = lines[0];
                    username = lines[1];
                }
            }
            var pauseSeconds = 60;
            for(int i=0;i < 10; i++)
            {
                if(IsProcessOpen("FortniteClient"))
                    TryRefresh();
                Thread.Sleep(1000 * pauseSeconds);
            }
        }
    }
}
