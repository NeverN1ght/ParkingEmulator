using System;
using static System.Console;
using static ParkingEmulator.Console.Decoration.MenuDecoration;

namespace ParkingEmulator.Console.Presentation
{
    public static class Menu
    {
        public static void ShowMainSections()
        {
            Clear();
            ShowSignboard();
            WriteLine("┌───────────────────┐");
            WriteLine("│1 - Cars           │");
            WriteLine("│2 - Transactions   │");
            WriteLine("│3 - Settings       │");
            WriteLine("│4 - About          │");
            WriteLine("│5 - Quit           │");
            WriteLine("└───────────────────┘");
        }

        public static void ShowCarOperations()
        {
            Clear();
            ShowSignboard();
            WriteLine("┌────────────────────┐");
            WriteLine("│1 - Add new car     │");
            WriteLine("│2 - Remove car      │");
            WriteLine("│3 - Add balance     │");
            WriteLine("│4 - Get cars list   │");
            WriteLine("│5 - Get free places │");
            WriteLine("│6 - Go back         │");
            WriteLine("└────────────────────┘");
        }

        public static void ShowTransactionOperations()
        {
            Clear();
            ShowSignboard();
            WriteLine("┌─────────────────────────────────┐");
            WriteLine("│1 - Get last minute transactions │");
            WriteLine("│2 - Get all transactions         │");
            WriteLine("│3 - Get total profit             │");
            WriteLine("│4 - Go back                      │");
            WriteLine("└─────────────────────────────────┘");

        }

        public static void ShowSettingsOperations()
        {
            Clear();
            ShowSignboard();
            WriteLine("┌─────────────────────────┐");
            WriteLine("│1 - Change prices        │");
            WriteLine("│2 - Change parking space │");
            WriteLine("│3 - Change fine          │");
            WriteLine("│4 - Go back              │");
            WriteLine("└─────────────────────────┘");
        }

        public static void ShowAbout()
        {
            Clear();
            ShowSignboard();
            WriteLine("┌─────────────────────────────────────┐");
            WriteLine("│Parking emulator v.1                 │");
            WriteLine("│Created by Mykola Kobets             │");
            WriteLine("│Visit: https://github.com/NeverN1ght │");
            WriteLine("└─────────────────────────────────────┘");
        }

        public static void ShowSignboard()
        {
            WriteLineWithColor("╔═════════════════════════════════════════╗", ConsoleColor.DarkRed);
            WriteWithColor("║", ConsoleColor.DarkRed);
            WriteWithColor(" ████──████──████──█──█──███──█──█──████ ", ConsoleColor.DarkCyan);
            WriteLineWithColor("║", ConsoleColor.DarkRed);
            WriteWithColor("║", ConsoleColor.DarkRed);
            WriteWithColor(" █──█──█──█──█──█──█─█────█───██─█──█    ", ConsoleColor.DarkCyan);
            WriteLineWithColor("║", ConsoleColor.DarkRed);
            WriteWithColor("║", ConsoleColor.DarkRed);
            WriteWithColor(" ████──████──████──██─────█───█─██──█─██ ", ConsoleColor.DarkCyan);
            WriteLineWithColor("║", ConsoleColor.DarkRed);
            WriteWithColor("║", ConsoleColor.DarkRed);
            WriteWithColor(" █─────█──█──█─█───█─█────█───█──█──█──█ ", ConsoleColor.DarkCyan);
            WriteLineWithColor("║", ConsoleColor.DarkRed);
            WriteWithColor("║", ConsoleColor.DarkRed);
            WriteWithColor(" █─────█──█──█─█───█──█──███──█──█──████ ", ConsoleColor.DarkCyan);
            WriteLineWithColor("║", ConsoleColor.DarkRed);
            WriteLineWithColor("╚═════════════════════════════════════════╝", ConsoleColor.DarkRed);
        }
    }
}
