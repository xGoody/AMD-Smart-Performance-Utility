// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace AMD_Smart_Performance_Utility
{
    class Program
    {
        static void Main(string[] args)
        {
            ASPU Utility = new ASPU();
            Utility.Start();
        }
    }
}