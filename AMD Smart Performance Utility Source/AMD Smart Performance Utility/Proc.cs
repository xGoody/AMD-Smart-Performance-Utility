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
        public static void RyzenADJ(String Args)
        {
            Process process = new Process();
            process.StartInfo.FileName = "../../../ryzenadj/ryzenadj.exe";
            process.StartInfo.Arguments = Args;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.CreateNoWindow = true;
            process.Start();

            string output = process.StandardOutput.ReadToEnd();
            Console.WriteLine(output);
            process.WaitForExit();

        }
    }
}
