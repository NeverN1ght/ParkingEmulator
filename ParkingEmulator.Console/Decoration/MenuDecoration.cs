using System;
using static System.Console;

namespace ParkingEmulator.Console.Decoration
{
    public static class MenuDecoration
    {
        public static void WriteWithColor(string str, ConsoleColor color)
        {
            ForegroundColor = color;
            Write(str);
            ResetColor();
        }

        public static void WriteLineWithColor(string str, ConsoleColor color)
        {
            ForegroundColor = color;
            WriteLine(str);
            ResetColor();
        }

        public static void WriteLineError(string str)
        {
            ForegroundColor = ConsoleColor.Red;
            WriteLine(str);
            ResetColor();
        }

        public static void WriteLineSuccess(string str)
        {
            ForegroundColor = ConsoleColor.Green;
            WriteLine(str);
            ResetColor();
        }
    }
}
