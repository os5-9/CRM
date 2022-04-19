using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgencyCRM
{
    public static class Logger
    {

        private static string log;
        public static void Log(string logText)
        {
            log = $"{DateTime.Now} | {logText}\n";
            File.AppendAllText(Environment.CurrentDirectory + "//log.txt", log);
        }
    }
}
