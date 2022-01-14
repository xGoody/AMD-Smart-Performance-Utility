using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMD_Smart_Performance_Utility
{
    class ASPU
    {
        String TempLimit = "";
        String SkinTemp = "";
        String TDP = "";
        String SlowBoost = "";
        String FastBoost = "";
        String SlowBoostDuration = "";
        String FastBoostDuration = "";
        bool devMode = false;
        public void Start()
        {
            Console.Title = "AMD Smart Performance Utility";
            RunMainMenu();
        }

        void RunMainMenu()
        {
            string prompt = @"
  █████╗ ███████╗██████╗ ██╗   ██╗
 ██╔══██╗██╔════╝██╔══██╗██║   ██║
 ███████║███████╗██████╔╝██║   ██║
 ██╔══██║╚════██║██╔═══╝ ██║   ██║
 ██║  ██║███████║██║     ╚██████╔╝
 ╚═╝  ╚═╝╚══════╝╚═╝      ╚═════╝";
            string[] options = { "Profiles", "Advanced", "Credits", "License", "Exit" };
            Menu mainMenu = new Menu(prompt, options);
            int selectedIndex = mainMenu.Run();

            switch (selectedIndex)
            {
                case 0:
                    Profiles();
                    break;
                case 1:
                    Advanced();
                    break;
                case 2:
                    Credits();
                    break;
                case 3:
                    License();
                    break;
                case 4:
                    return;
            }
        }
        private void Profiles()
        {

            string prompt = "Profiles & Presets\n\n\n\n";
            string[] options = { "Back\n\n", "Noise Profiles" };
            Menu ProfileMenu = new Menu(prompt, options);
            int selectedIndex = ProfileMenu.Run();
            switch (selectedIndex)
            {
                case 0:
                    RunMainMenu();
                    break;
                case 1:
                    NoiseProfiles();
                    break;
            }

        }
        private void Advanced()
        {

            string prompt = "Advanced Options\n\n";
            string[] options = { "Back\n\n", "Power Options", "Developer Options", "Install Required Service" };
            Menu AdvancedMenu = new Menu(prompt, options);
            int selectedIndex = AdvancedMenu.Run();
            switch (selectedIndex)
            {
                case 0:
                    RunMainMenu();
                    break;
                case 1:
                    PowerConfig();
                    break;
                case 2:
                    Developer();
                    break;
                case 3:
                    Proc.InstallService(devMode);
                    Advanced();
                    break;
                
            }

        }
        private void NoiseProfiles()
        {
            String QuietMode = "--tctl-temp=50";
            String BalancedMode = "--tctl-temp=70";
            String LoudMode = "--tctl-temp=85";
            String VeryLoudMode = "--tctl-temp=95";
            string prompt = "Noise Profiles\n\n";
            string[] options = { "Back\t Temp Limits\n", "Quiet \t 50c", "Balanced\t 70c", "Loud \t 85c", "Extreme\t 95c" };
            Menu ProfileMenu = new Menu(prompt, options);
            int selectedIndex = ProfileMenu.Run();
            switch (selectedIndex)
            {
                case 0:
                    RunMainMenu();
                    break;

                case 1:
                    Proc.RyzenADJ(QuietMode, devMode);
                    Console.ReadKey();
                    NoiseProfiles();
                    break;
                case 2:
                    Proc.RyzenADJ(BalancedMode, devMode);
                    Console.ReadKey();
                    NoiseProfiles();
                    break;
                case 3:
                    Proc.RyzenADJ(LoudMode, devMode);
                    Console.ReadKey();
                    NoiseProfiles();
                    break;
                case 4:
                    Proc.RyzenADJ(VeryLoudMode, devMode);
                    Console.ReadKey();
                    NoiseProfiles();
                    break;

            }

        }
        private void PowerConfig()
        {
            String Args;
            string prompt = "PowerConfig\n\n\n\n";
            string[] options = { "Back\n", "Temp Limit", "Skin Temp Limit\n", "TDP/STAPM", "Slow Boost", "Fast Boost\n", "Slow Boost Duration", "Fast Boost Duration\n", "Set Changes" };
            Menu PowerConfigMenu = new Menu(prompt, options);
            int selectedIndex = PowerConfigMenu.Run();
            switch (selectedIndex)
            {
                case 0:
                    RunMainMenu();
                    break;
                case 1:
                    temp2();
                    if (int.TryParse(Console.ReadLine(), out int Input1) && Input1 <= 100 && Input1 >= 30)
                    {

                        TempLimit = $"{ " --tctl-temp="+ (Input1)}";
                        Console.WriteLine($"{TempLimit + " In (celcius)"}");
                        Console.ReadKey();
                        PowerConfig();
                    }
                    else
                    {
                        Console.WriteLine("You didn't give me a valid number.");
                        Console.WriteLine("Or you exceeded 100c TempLimit which is too dangerous");
                        Console.WriteLine("You can only use values from 30 to 100 (celcius)");
                        Console.ReadKey();
                        PowerConfig();
                    }
                    break;
                case 2:
                    temp2();
                    if (int.TryParse(Console.ReadLine(), out int Input2) && Input2 <= 105 && Input2 >= 35)
                    {
                        SkinTemp = $"{ " --apu-skin-temp="+ (Input2)}";
                        Console.WriteLine($"{SkinTemp + " In (celcius)"}");
                        Console.ReadKey();
                        PowerConfig();
                    }
                    else
                    {
                        Console.WriteLine("You didn't give me a valid number.");
                        Console.WriteLine("Or you exceeded 105c SkinTempLimit which is too dangerous.");
                        Console.WriteLine("You can only use values from 35 to 105 (celcius)");
                        Console.ReadKey();
                        PowerConfig();
                    }
                    break;
                case 3:
                    temp2();
                    if (int.TryParse(Console.ReadLine(), out int Input3) && Input3 <= 300 && Input3 >= 0)
                    {
                        TDP = $"{ " --stapm-limit="+ (Input3*1000)}";
                        Console.WriteLine($"{TDP + " In (miliWatts)"}");
                        Console.ReadKey();
                        PowerConfig();
                    }
                    else
                    {
                        Console.WriteLine("You didn't give me a valid number.");
                        Console.WriteLine("You can only use values from 0 to 300 (celcius)");
                        Console.ReadKey();
                        PowerConfig();
                    }
                    break;
                case 4:
                    temp2();
                    if (int.TryParse(Console.ReadLine(), out int Input4) && Input4 <= 300 && Input4 >= 0)
                    {
                        SlowBoost = $"{ " --slow-limit="+ (Input4 * 1000)}";
                        Console.WriteLine($"{SlowBoost + " In (miliWatts)"}");
                        Console.ReadKey();
                        PowerConfig();
                    }
                    else
                    {
                        Console.WriteLine("You didn't give me a valid number.");
                        Console.WriteLine("You can only use values from 0 to 300 (watts)");
                        Console.ReadKey();
                        PowerConfig();
                    }
                    break;
                case 5:
                    temp2();
                    if (int.TryParse(Console.ReadLine(), out int Input5) && Input5 <= 300 && Input5 >= 0)
                    {
                        FastBoost = $"{ " --fast-limit="+ (Input5 * 1000)}";
                        Console.WriteLine($"{FastBoost + " In (miliWatts)"}");
                        Console.ReadKey();
                        PowerConfig();
                    }
                    else
                    {
                        Console.WriteLine("You didn't give me a valid number.");
                        Console.WriteLine("You can only use values from 0 to 300 (watts)");
                        Console.ReadKey();
                        PowerConfig();
                    }
                    break;
                case 6:
                    temp2();
                    if (int.TryParse(Console.ReadLine(), out int Input6) && Input6 <= 1024 && Input6 >= 0)
                    {
                        SlowBoostDuration = $"{ " --slow-time="+ (Input6)}";
                        Console.WriteLine($"{SlowBoostDuration + " In (seconds)"}");
                        Console.ReadKey();
                        PowerConfig();
                    }
                    else
                    {
                        Console.WriteLine("You didn't give me a valid number.");
                        Console.WriteLine("You can only use values from 0 to 1024 (seconds)");
                        Console.ReadKey();
                        PowerConfig();
                    }
                    break;
                case 7:
                    temp2();
                    if (int.TryParse(Console.ReadLine(), out int Input7) && Input7 <= 3600 && Input7 >= 0)
                    {
                        FastBoostDuration = $"{ " --stapm-time=" + (Input7)}";
                        Console.WriteLine($"{FastBoostDuration + " In (seconds)"}");
                        Console.ReadKey();
                        PowerConfig();
                    }
                    else
                    {
                        Console.WriteLine("You didn't give me a valid number.");
                        Console.WriteLine("You can only use values from 0 to 3600 (seconds)");
                        Console.ReadKey();
                        PowerConfig();
                    }
                    break;
                case 8:
                    Args = TempLimit + SkinTemp + TDP + SlowBoost + FastBoost + SlowBoostDuration + FastBoostDuration;
                    Proc.RyzenADJ(Args, devMode);
                    Console.ReadKey();
                    PowerConfig();
                    break;
            }

        }
        private void Credits()
        {

            string prompt = "Credits\n\n\n\nASPU was made by xGoody using FlyGoat's ryzenadj.\n";
            string[] options = { "Back\n\n" };
            Menu CreditMenu = new Menu(prompt, options);
            int selectedIndex = CreditMenu.Run();
            switch (selectedIndex)
            {
                case 0:
                    RunMainMenu();
                    break;
            }

        }
        private void License()
        {

            string prompt = "License\n\n\n\n";
            string[] options = { "Back\n\n", "ASPU has a Apache 2.0 License.\n" };
            Menu LicenseMenu = new Menu(prompt, options);
            int selectedIndex = LicenseMenu.Run();
            switch (selectedIndex)
            {
                case 0:
                    RunMainMenu();
                    break;
                case 1:
                    License();
                    break;
            }

        }
        private void Developer()
        {

            string prompt = "Developer Mode, Seriously Dont enable this it doesnt do anything.\n This changes the directory of ryzenadj specifically for the creator";
            string[] options = { "Back\n\n", "Enable Developer Mode", "Disable Developer Mode" };
            Menu DevMenu = new Menu(prompt, options);
            int selectedIndex = DevMenu.Run();
            switch (selectedIndex)
            {
                case 0:
                    RunMainMenu();
                    break;
                case 1:
                    devMode = true;
                    Console.WriteLine("devMode has been initialized to true");
                    Console.ReadKey();
                    Developer();
                    break;
                case 2:
                    devMode = false;
                    Console.WriteLine("devMode has been initialized to false");
                    Console.ReadKey();
                    Developer();
                    break;
            }

        }
        private void temp()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n\nSorry this doesnt work yet.");
            Console.ReadKey();
            PowerConfig();
        }

        private void temp2()
        {
            Console.ForegroundColor = ConsoleColor.Red;
        }
    }
}