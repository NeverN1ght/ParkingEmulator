using ParkingEmulator.Console.Exceptions;
using ParkingEmulator.Console.Presentation;
using ParkingEmulator.Core.Entities;
using ParkingEmulator.Core.Exceptions;
using ParkingEmulator.Core.Kernel;
using ParkingEmulator.Log.Logging;
using System;
using System.IO;
using static System.Console;
using static ParkingEmulator.Console.Decoration.MenuDecoration;

namespace ParkingEmulator.Console.Facades
{
    public class ParkingFacade
    {
        private readonly Parking _parking;

        public ParkingFacade(Parking parking)
        {
            _parking = parking;
        }

        public void AddNewCar()
        {
            CarType carType = CarType.Passenger; 
            WriteLine($"1 - {CarType.Passenger.ToString()}; 2 - {CarType.Truck.ToString()}; 3 - {CarType.Bus.ToString()}; 4 - {CarType.Motorcycle.ToString()}");
            Write("Enter car type: ");
            var type = int.Parse(ReadLine());
            switch (type)
            {
                case 1:
                    carType = CarType.Passenger;
                    break;
                case 2:
                    carType = CarType.Truck;
                    break;
                case 3:
                    carType = CarType.Bus;
                    break;
                case 4:
                    carType = CarType.Motorcycle;
                    break;
                default:
                    throw new WrongSwitchItemException("Wrong car type!");
            }
            Write("Enter start balance: ");
            var startBalance = decimal.Parse(ReadLine());
            if (startBalance <= 0)
                throw new FormatException();
            try
            {
                _parking.AddCar(new Car(startBalance, carType));
                WriteLineSuccess("Success!");
                WriteLine("\nPlease enter any key to continue...");
                ReadKey();
                Navigation.SelectedCars();
            }
            catch (NotEnoughParkingSpaceException ex)
            {
                WriteLineError("Error: " + ex.Message);
                WriteLine("\nPlease enter any key to continue...");
                ReadKey();
                Navigation.SelectedCars();
            }     
        }

        public void RemoveExistingCar()
        {
            Write("Enter car id: ");
            try
            {
                var id = int.Parse(ReadLine());
                _parking.RemoveCar(_parking.FindCarById(id));
                WriteLineSuccess("Success!");
                WriteLine("\nPlease enter any key to continue...");
                ReadKey();
                Navigation.SelectedCars();
            }
            catch (NotExistException ex)
            {
                WriteLineError("Error: " + ex.Message);
                WriteLine("\nPlease enter any key to continue...");
                ReadKey();
                Navigation.SelectedCars();
            }
            catch (FinedCarException ex)
            {
                WriteLineError("Error: " + ex.Message);
                WriteLine("\nPlease enter any key to continue...");
                ReadKey();
                Navigation.SelectedCars();
            }
        }

        public void AddCarBalance()
        {
            Write("Enter car id: ");
            try
            {
                var id = int.Parse(ReadLine());
                Write("Enter funds: ");
                var funds = decimal.Parse(ReadLine());
                _parking.AddBalance(id, funds);
                WriteLineSuccess("Success!");
                WriteLine("\nPlease enter any key to continue...");
                ReadKey();
                Navigation.SelectedCars();
            }
            catch (NotExistException ex)
            {
                WriteLineError("Error: " + ex.Message);
                WriteLine("\nPlease enter any key to continue...");
                ReadKey();
                Navigation.SelectedCars();
            }
            catch (ArgumentException ex)
            {
                WriteLineError("Error: " + ex.Message);
                WriteLine("\nPlease enter any key to continue...");
                ReadKey();
                Navigation.SelectedCars();
            }
        }

        public void ShowCarsList()
        {
            WriteLine("Car id|Type      |Balance");
            WriteLine("----------------------------------------");
            foreach (var car in _parking.Cars)
            {
                WriteLine(car.ToString());
            }
            WriteLine("\nPlease enter any key to continue...");
            ReadKey();
            Navigation.SelectedCars();
        }

        public void ShowFreeParkingPlaces()
        {
            WriteLine($"{_parking.GetFreeParkingPlaces()} places available!");
            WriteLine("\nPlease enter any key to continue...");
            ReadKey();
            Navigation.SelectedCars();
        }

        public void ShowLastMinuteTransactions()
        {
            WriteLine("Transaction time   |Car id|Type   |Funds");
            WriteLine("----------------------------------------");
            foreach(var transaction in _parking.GetLastMinuteTransactions())
            {
                WriteLine(transaction.ToString());
            }
            WriteLine("\nPlease enter any key to continue...");
            ReadKey();
            Navigation.SelectedTransactions();
        }

        public void ShowTransactionsHistory()
        {
            try
            {
                WriteLine("Transaction time   |Car id|Type   |Funds");
                WriteLine("----------------------------------------");
                foreach (var transaction in TransactionLogger.ReadTransactionLog())
                {
                    WriteLine(transaction.ToString());
                }
            }
            catch (FileNotFoundException ex)
            {
                WriteLine("Error: " + ex.Message);
            }
            WriteLine("\nPlease enter any key to continue...");
            ReadKey();
            Navigation.SelectedTransactions();
        }

        public void ShowEarnedBalance()
        {
            WriteLine($"Total earned: {_parking.EarnedBalance}$");
            WriteLine("\nPlease enter any key to continue...");
            ReadKey();
            Navigation.SelectedTransactions();
        }

        public void ChangePrices()
        {
            WriteLine($"Current price per {Settings.Timeout} seconds:");
            WriteLine($"  1.{CarType.Truck} = {Settings.Prices[CarType.Truck]}$");
            WriteLine($"  2.{CarType.Passenger} = {Settings.Prices[CarType.Passenger]}$");
            WriteLine($"  3.{CarType.Bus} = {Settings.Prices[CarType.Bus]}$");
            WriteLine($"  4.{CarType.Motorcycle} = {Settings.Prices[CarType.Motorcycle]}$");
            Write("Select car type: ");
            var type = int.Parse(ReadLine());
            int price;
            switch(type)
            {
                case 1:
                    Write($"Enter new price for {CarType.Truck}: ");
                    price = int.Parse(ReadLine());
                    if (price > 0)
                        Settings.Prices[CarType.Truck] = price;
                    else
                        throw new FormatException();
                    break;
                case 2:
                    Write($"Enter new price for {CarType.Passenger}: ");
                    price = int.Parse(ReadLine());
                    if (price > 0)
                        Settings.Prices[CarType.Passenger] = price;
                    else
                        throw new FormatException();
                    break;
                case 3:
                    Write($"Enter new price for {CarType.Bus}: ");
                    price = int.Parse(ReadLine());
                    if (price > 0)
                        Settings.Prices[CarType.Bus] = price;
                    else
                        throw new FormatException();
                    break;
                case 4:
                    Write($"Enter new price for {CarType.Motorcycle}: ");
                    price = int.Parse(ReadLine());
                    if (price > 0)
                        Settings.Prices[CarType.Motorcycle] = price;
                    else
                        throw new FormatException();
                    break;
                default:
                    throw new WrongSwitchItemException("Wrong car type!");
            }
            WriteLineSuccess("Success!");
            WriteLine("\nPlease enter any key to continue...");
            ReadKey();
            Navigation.SelectedSettings();
        }

        public void ChangeParkingSpace()
        {
            Write($"Enter new parking space value(current: {Settings.ParkingSpace}): ");
            try
            {
                var space = uint.Parse(ReadLine());
                if (space <= 0)
                    throw new FormatException();
                Settings.ParkingSpace = space;
                WriteLineSuccess("Success!");
                WriteLine("\nPlease enter any key to continue...");
                ReadKey();
                Navigation.SelectedSettings();
            }
            catch (OverflowException)
            {
                WriteLineError("Error: Invalid value");
                WriteLine("\nPlease enter any key to continue...");
                ReadKey();
                Navigation.SelectedSettings();
            }
        }

        public void ChangeFine()
        {
            Write($"Enter new fine value(current: {Settings.Fine}): ");
            var fine = decimal.Parse(ReadLine());
            if (fine <= 0)
                throw new FormatException();
            Settings.Fine = fine;
            WriteLineSuccess("Success!");
            WriteLine("\nPlease enter any key to continue...");
            ReadKey();
            Navigation.SelectedSettings();  
        }
    }
}
