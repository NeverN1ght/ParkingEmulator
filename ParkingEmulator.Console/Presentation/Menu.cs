using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace ParkingEmulator.Console.Presentation
{
    public static class Menu
    {
        public static void ShowMainSections()
        {
            Clear();
            WriteLine("1 - Cars");
            WriteLine("2 - Transactions");
            WriteLine("3 - Settings");
            WriteLine("4 - Quit");
        }

        public static void ShowCarOperations()
        {
            Clear();
            WriteLine("1 - Add car");
            WriteLine("2 - Remove car");
            WriteLine("3 - Add balance");
            WriteLine("4 - Get cars list");
            WriteLine("5 - Get free places");
            WriteLine("6 - Go back");
        }

        public static void ShowTransactionOperations()
        {
            Clear();
            WriteLine("1 - GetFromLastMin");
            WriteLine("2 - GetAll");
            WriteLine("3 - GetTotalProfit");
            WriteLine("4 - Go back");
        }

        public static void ShowSettingsOperations()
        {
            Clear();
            WriteLine("1 - Change timeout");
            WriteLine("2 - Change prices");
            WriteLine("3 - Change space");
            WriteLine("4 - Change fine");
            WriteLine("5 - Go back");
        }

        public static void ShowAbout()
        {
            Clear();
            WriteLine("Hello world!");
            WriteLine("Press any key to go back");
        }
    }
}
