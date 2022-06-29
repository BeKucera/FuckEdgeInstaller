using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FuckEdgeInstaller
{
    internal class Program
    {
        static void Main(string[] args)
        {
            WebClient wc = new WebClient();
            wc.DownloadFile("https://github.com/BeKucera/FuckEdge/raw/master/FuckEdge/bin/Debug/FuckEdge.exe","FuckEdge.exe");
            string msedge = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + @"\Microsoft\Edge\Application\msedge.exe";

            if (File.Exists(msedge))
                File.Delete(msedge);

            foreach (var process in Process.GetProcessesByName("FuckEdge.exe"))
            {
                process.Kill();
            }

            File.Move(Environment.CurrentDirectory+@"\FuckEdge.exe",msedge);
            Console.WriteLine("done");
            Console.ReadKey();
        }
    }
}
