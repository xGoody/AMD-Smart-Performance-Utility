using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMD_Smart_Performance_Utility
{
    class ASPU
    {
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
            string[] options = { "PowerProfiles", "Advanced", "Credits", "License", "Exit"};
            Menu mainMenu = new Menu(prompt, options);
            int selectedIndex = mainMenu.Run();

            switch (selectedIndex)
            {
                case 0:
                    PowerProfiles();
                    break;
                case 1:
                    PowerConfig();
                    break;
                case 2:
                    Credits();
                    break;
                case 3:
                    License();
                    break;
                case 4:
                    Exit();
                    break;
            }
        }
        private void PowerProfiles()
        {
            string QuietMode = "--help";
            string BalancedMode = "--help";
            string LoudMode = "--help";
            string ExtremeMode = "--help";
            string prompt = "Power Profiles\n\n\n\n";
            string[] options = { "Back\n", "Quiet", "Balanced", "Loud", "Very Loud"};
            Menu ProfileMenu = new Menu(prompt, options);
            int selectedIndex = ProfileMenu.Run();
            switch (selectedIndex)
            {
                case 0:
                    RunMainMenu();
                    break;

                case 1:
                    Proc.RyzenADJ(QuietMode);
                    Console.WriteLine("Quiet Mode is now Set!\n");
                    Console.ReadKey();
                    PowerProfiles();
                    break;
                case 2:
                    Proc.RyzenADJ(BalancedMode);
                    Console.WriteLine("Balanced Mode is now Set!\n");
                    Console.ReadKey();
                    PowerProfiles();
                    break;
                case 3:
                    Proc.RyzenADJ(LoudMode);
                    Console.WriteLine("Loud Mode is now Set!\n");
                    Console.ReadKey();
                    PowerProfiles();
                    break;
                case 4:
                    Proc.RyzenADJ(ExtremeMode);
                    Console.WriteLine("Very Loud Mode is now Set!\n");
                    Console.ReadKey();
                    PowerProfiles();
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
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    break;
                case 6:
                    break;
                case 7:
                    break;
            }

        }
        private void Credits()
        {

            string prompt = "Credits\n\n\n\nASPU was made by xGoody using sbski's custom ryzen adj.\n";
            string[] options = { "Back" };
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

            string prompt = "License\n\n\n\nASPU has a MIT License.\n";
            string[] options = { "Back" };
            Menu LicenseMenu = new Menu(prompt, options);
            int selectedIndex = LicenseMenu.Run();
            switch (selectedIndex)
            {
                case 0:
                    RunMainMenu();
                    break;
            }

        }
        private void Exit()
        {
            Environment.Exit(0);
        }

    }
}