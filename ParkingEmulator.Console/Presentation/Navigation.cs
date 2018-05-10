using ParkingEmulator.Core.Kernel;
using System;
using static System.Console;
using static ParkingEmulator.Console.Presentation.Menu;

namespace ParkingEmulator.Console.Presentation
{
    public static class Navigation
    {
        private static bool isExit = false;

        public static void Run(Parking parking)
        {
            while (!isExit)
            {
                ShowMainSections();
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
                            isExit = true;
                            break;
                        default:
                            throw new NullReferenceException("message");//implement
                    }
                }
                catch (NullReferenceException ex)
                {
                    WriteLine(ex.Message);
                }
                catch (FormatException ex)
                {
                    WriteLine(ex.Message);
                }
                finally
                {
                    ReadKey();
                }
            }
        }

        private static void SelectedCars()
        {
            ShowCarOperations();
            int operation = 0;
            try
            {
                operation = int.Parse(ReadLine());
                switch (operation)
                {
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
                    default:
                        throw new NullReferenceException("message");//implement
                }
            }
            catch (NullReferenceException ex)
            {
                WriteLine(ex.Message);
            }
            catch (FormatException ex)
            {
                WriteLine(ex.Message);
            }
            finally
            {
                ReadKey();
            }
        }

        private static void SelectedTransactions()
        {
            ShowTransactionOperations();
            int operation = 0;
            try
            {
                operation = int.Parse(ReadLine());

                switch (operation)
                {
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    default:
                        throw new NullReferenceException("message");//implement
                }
            }
            catch (NullReferenceException ex)
            {
                WriteLine(ex.Message);
            }
            catch (FormatException ex)
            {
                WriteLine(ex.Message);
            }
            finally
            {
                ReadKey();
            }

        }

        private static void SelectedSettings()
        {
            ShowSettingsOperations();
            int operation = 0;
            try
            {
                operation = int.Parse(ReadLine());

                switch (operation)
                {
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
                    default:
                        throw new NullReferenceException("message");//implement
                }
            }
            catch (NullReferenceException ex)
            {
                WriteLine(ex.Message);
            }
            catch (FormatException ex)
            {
                WriteLine(ex.Message);
            }
            finally
            {
                ReadKey();
            }
        }

        private static void SelectedAbout()
        {
            ShowAbout(); 
        }
    }
}
