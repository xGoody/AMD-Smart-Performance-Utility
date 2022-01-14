using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AMD_Smart_Performance_Utility
{
    class ASPU
    {
        bool devMode = false;
        public void Start()
        {
            Console.Title = "AMD Smart Performance Utility";
            RunMainMenu();
        }

        private void RunMainMenu()
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
            string[] options = { "Back\n\n", "Power Options", "Developer Options" };
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
            }

        }
        private void NoiseProfiles()
        {
            string QuietMode = "--tctl-temp=50";
            string BalancedMode = "--tctl-temp=70";
            string LoudMode = "--tctl-temp=85";
            string VeryLoudMode = "--tctl-temp=95";
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
                    Console.WriteLine("Quiet Mode is now Set!\n");
                    Console.ReadKey();
                    NoiseProfiles();
                    break;
                case 2:
                    Proc.RyzenADJ(BalancedMode, devMode);
                    Console.WriteLine("Balanced Mode is now Set!\n");
                    Console.ReadKey();
                    NoiseProfiles();
                    break;
                case 3:
                    Proc.RyzenADJ(LoudMode, devMode);
                    Console.WriteLine("Loud Mode is now Set!\n");
                    Console.ReadKey();
                    NoiseProfiles();
                    break;
                case 4:
                    Proc.RyzenADJ(VeryLoudMode, devMode);
                    Console.WriteLine("Very Loud Mode is now Set!\n");
                    Console.ReadKey();
                    NoiseProfiles();
                    break;

            }

        }
        private void PowerConfig()
        {

            string prompt = "PowerConfig\n\n\n\n";
            string[] options = { "Back\n", "Temp Limit", "Skin Temp Limit\n", "TDP/STAPM", "Slow Boost", "Fast Boost\n", "Slow Boost Duration", "Fast Boost Duration" };
            Menu PowerConfigMenu = new Menu(prompt, options);
            int selectedIndex = PowerConfigMenu.Run();
            switch (selectedIndex)
            {
                case 0:
                    RunMainMenu();
                    break;
                case 1:
                    tempPowerConfig();
                    break;
                case 2:
                    tempPowerConfig();
                    break;
                case 3:
                    tempPowerConfig();
                    break;
                case 4:
                    tempPowerConfig();
                    break;
                case 5:
                    tempPowerConfig();
                    break;
                case 6:
                    tempPowerConfig();
                    break;
                case 7:
                    tempPowerConfig();
                    break;
            }

        }
        private void Credits()
        {

            string prompt = "Credits\n\n\n\nASPU was made by xGoody using FlyGoat's ryzen adj.\n";
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
        private void tempPowerConfig()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n\nSorry this doesnt work yet.");
            Console.ReadKey();
            PowerConfig();
        }
    }
}