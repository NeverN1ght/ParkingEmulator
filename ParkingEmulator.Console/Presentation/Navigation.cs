using ParkingEmulator.Core.Kernel;
using System;
using static System.Console;
using static ParkingEmulator.Console.Presentation.Menu;
using static ParkingEmulator.Console.Decoration.MenuDecoration;
using ParkingEmulator.Console.Facades;
using ParkingEmulator.Console.Exceptions;

namespace ParkingEmulator.Console.Presentation
{
    public static class Navigation
    {
        private static bool isExit = false;
        private static ParkingFacade facade;

        public static void RunMenu(Parking parking)
        {
            facade = new ParkingFacade(parking);

            while (!isExit)
            {
                ShowMainSections();
                Write("Select section: ");
                int section = 0;
                try
                {
                    section = int.Parse(ReadLine());
                    switch (section)
                    {
                        case 1:
                            SelectedCars();
                            break;
                        case 2:
                            SelectedTransactions();
                            break;
                        case 3:
                            SelectedSettings();
                            break;
                        case 4:
                            SelectedAbout();
                            break;
                        case 5:
                            isExit = true;
                            break;
                        default:
                            throw new WrongSwitchItemException("Wrong menu section!");
                    }
                }
                catch (WrongSwitchItemException ex)
                {
                    WriteLineError("Error: " + ex.Message);
                    WriteLine("\nPlease enter any key to continue...");
                    ReadKey();
                }
                catch (FormatException)
                {
                    WriteLineError("Error: Invalid value");
                    WriteLine("\nPlease enter any key to continue...");
                    ReadKey();
                }
            }
        }

        public static void SelectedCars()
        {
            ShowCarOperations();
            Write("Select operation: ");
            int operation = 0;
            try
            {
                operation = int.Parse(ReadLine());
                switch (operation)
                {
                    case 1:
                        facade.AddNewCar();
                        break;
                    case 2:
                        facade.RemoveExistingCar();
                        break;
                    case 3:
                        facade.AddCarBalance();
                        break;
                    case 4:
                        facade.ShowCarsList();
                        break;
                    case 5:
                        facade.ShowFreeParkingPlaces();
                        break;
                    case 6:
                        break;
                    default:
                        throw new WrongSwitchItemException("Wrong operation!");
                }
            }
            catch (WrongSwitchItemException ex)
            {
                WriteLineError("Error: " + ex.Message);
                WriteLine("\nPlease enter any key to continue...");
                ReadKey();
                SelectedCars();
            }
            catch (FormatException)
            {
                WriteLineError("Error: Invalid value");
                WriteLine("\nPlease enter any key to continue...");
                ReadKey();
                SelectedCars();
            }
        }

        public static void SelectedTransactions()
        {
            ShowTransactionOperations();
            Write("Select operation: ");
            int operation = 0;
            try
            {
                operation = int.Parse(ReadLine());

                switch (operation)
                {
                    case 1:
                        facade.ShowLastMinuteTransactions();
                        break;
                    case 2:
                        facade.ShowTransactionsHistory();
                        break;
                    case 3:
                        facade.ShowEarnedBalance();
                        break;
                    case 4:
                        break;
                    default:
                        throw new WrongSwitchItemException("Wrong operation!");
                }
            }
            catch (WrongSwitchItemException ex)
            {
                WriteLineError("Error: " + ex.Message);
                WriteLine("\nPlease enter any key to continue...");
                ReadKey();
                SelectedTransactions();
            }
            catch (FormatException)
            {
                WriteLineError("Error: Invalid value");
                WriteLine("\nPlease enter any key to continue...");
                ReadKey();
                SelectedTransactions();
            }

        }

        public static void SelectedSettings()
        {
            ShowSettingsOperations();
            Write("Select operation: ");
            int operation = 0;
            try
            {              
                operation = int.Parse(ReadLine());

                switch (operation)
                {
                    case 1:
                        facade.ChangePrices();
                        break;
                    case 2:
                        facade.ChangeParkingSpace();
                        break;
                    case 3:
                        facade.ChangeFine();
                        break;
                    case 4:                    
                        break;
                    default:
                        throw new WrongSwitchItemException("Wrong operation!");
                }
            }
            catch (WrongSwitchItemException ex)
            {
                WriteLineError("Error: " + ex.Message);
                WriteLine("\nPlease enter any key to continue...");
                ReadKey();
                SelectedSettings();
            }
            catch (FormatException)
            {
                WriteLineError("Error: Invalid value");
                WriteLine("\nPlease enter any key to continue...");
                ReadKey();
                SelectedSettings();
            }
        }

        public static void SelectedAbout()
        {
            ShowAbout();
            WriteLine("\nPlease enter any key to continue...");
            ReadKey();
        }
    }
}
