using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace AMD_Smart_Performance_Utility
{
    class Proc
    {
        public static void RyzenADJ(String Args, bool dev)
        {
            Process process = new Process();
            process.StartInfo.Arguments = Args;
            if (dev == true)
            {
                process.StartInfo.FileName = "../../../ryzenadj/ryzenadj.exe";
            }
            else
            {
                process.StartInfo.FileName = "ryzenadj/ryzenadj.exe";
            }
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.CreateNoWindow = true;
            process.Start();

            string output = process.StandardOutput.ReadToEnd();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\n {output}");
            process.WaitForExit();

        }

        public static void InstallService(bool dev)
        {
            Process process2 = new Process();
            if (dev == true)
            {
                process2.StartInfo.FileName = "../../../ryzenadj/installServiceTask.bat";
            }
            else
            {
                process2.StartInfo.FileName = "ryzenadj/ryzenadj.installServiceTask.bat";
            }
            process2.StartInfo.Verb = "runas";
            process2.Start();
            process2.WaitForExit();
        }

    }
}