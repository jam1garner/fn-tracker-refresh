using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Threading;
using System.Diagnostics;

namespace FNTrackerRefresh
{
    class Program
    {
        private static readonly HttpClient client = new HttpClient();
        const string platform = "pc";
        const string username = "jam1garner";

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
            Console.WriteLine("Refreshing");
            var responseString = await client.GetStringAsync("https://fortnitetracker.com/profile/pc/jam1garner");
        }

        static void Main(string[] args)
        {
            var pauseSeconds = 60;
            for(int i=0;i < 10; i++)
            {
                Console.WriteLine("isFortniteOpen: "+IsProcessOpen("FortniteClient").ToString());
                if(IsProcessOpen("FortniteClient"))
                    TryRefresh();
                Thread.Sleep(1000 * pauseSeconds);
            }
        }
    }
}
