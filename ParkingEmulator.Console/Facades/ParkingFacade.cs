using ParkingEmulator.Console.Exceptions;
using ParkingEmulator.Console.Presentation;
using ParkingEmulator.Core.Entities;
using ParkingEmulator.Core.Exceptions;
using ParkingEmulator.Core.Kernel;
using ParkingEmulator.Log.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

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
            CarType carType = CarType.Passenger; //by default
            WriteLine($"1 - {CarType.Passenger.ToString()}; 2 - {CarType.Truck.ToString()}; 3 - {CarType.Bus.ToString()}; 4 - {CarType.Motorcycle.ToString()}");
            Write("Enter car type: ");
            try
            {
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
                _parking.AddCar(new Car(startBalance, carType));
                WriteLine("Success!");
                WriteLine("Please enter any key to continue...");
                ReadKey();
                Navigation.SelectedCars();
            }
            catch (WrongSwitchItemException ex)
            {
                WriteLine("Error: " + ex.Message);
                WriteLine("Please enter any key to continue...");
                ReadKey();
                Navigation.SelectedCars();
            }
            catch (FormatException)
            {
                WriteLine("Error: Invalid value");
                WriteLine("Please enter any key to continue...");
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
                WriteLine("Success!");
            }
            catch (FormatException)
            {
                WriteLine("Error: Invalid value");
                WriteLine("Please enter any key to continue...");
                ReadKey();
                Navigation.SelectedCars();
            }
            catch (NotExistException ex)
            {
                WriteLine(ex.Message);
                WriteLine("Please enter any key to continue...");
                ReadKey();
                Navigation.SelectedCars();
            }
            catch (FinedCarException ex)
            {
                WriteLine(ex.Message);
                WriteLine("Please enter any key to continue...");
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
                WriteLine("Success!");
            }
            catch (FormatException)
            {
                WriteLine("Error: Invalid value");
                WriteLine("Please enter any key to continue...");
                ReadKey();
                Navigation.SelectedCars();
            }
            catch (NotExistException ex)
            {
                WriteLine(ex.Message);
                WriteLine("Please enter any key to continue...");
                ReadKey();
                Navigation.SelectedCars();
            }
            catch (ArgumentException ex)
            {
                WriteLine(ex.Message);
                WriteLine("Please enter any key to continue...");
                ReadKey();
                Navigation.SelectedCars();
            }
        }

        public void ShowCarsList()
        {
            foreach (var car in _parking.Cars)
            {
                WriteLine(car.ToString());
            }
            WriteLine("Please enter any key to continue...");
            ReadKey();
            Navigation.SelectedCars();
        }

        public void ShowFreeParkingPlaces()
        {
            WriteLine($"{_parking.GetFreeParkingPlaces()} places available!");
            WriteLine("Please enter any key to continue...");
            ReadKey();
            Navigation.SelectedCars();
        }

        public void ShowLastMinuteTransactions()
        {
            foreach(var transaction in _parking.GetLastMinuteTransactions())
            {
                WriteLine(transaction.ToString());
            }
            WriteLine("Please enter any key to continue...");
            ReadKey();
            Navigation.SelectedTransactions();
        }

        public void ShowTransactionsHistory()
        {
            foreach(var transaction in TransactionLogger.ReadTransactionLog())
            {
                WriteLine(transaction.ToString());
            }
            WriteLine("Please enter any key to continue...");
            ReadKey();
            Navigation.SelectedTransactions();
        }

        public void ShowEarnedBalance()
        {
            WriteLine($"Total earned: {_parking.EarnedBalance}");
            WriteLine("Please enter any key to continue...");
            ReadKey();
            Navigation.SelectedTransactions();
        }

        public void ChangeTimeout()
        {
            Write($"Enter new timeout value(current: {Settings.Timeout}): ");
            var timeout = int.Parse(ReadLine());
            if (timeout <= 0)
                throw new FormatException("Wrong value!");
            Settings.Timeout = timeout;
            WriteLine("Success!");
            WriteLine("Please enter any key to continue...");
            ReadKey();
            Navigation.SelectedSettings();
        }

        public void ChangePrices()
        {
            Write($"Current prices per {Settings.Timeout} seconds:");
            Write($"1.{CarType.Truck} = {Settings.Prices[CarType.Truck]}$");
            Write($" 2.{CarType.Passenger} = {Settings.Prices[CarType.Passenger]}$");
            Write($" 3.{CarType.Bus} = {Settings.Prices[CarType.Bus]}$");
            Write($" 4.{CarType.Motorcycle} = {Settings.Prices[CarType.Motorcycle]}$");
            var type = int.Parse(ReadLine());
            switch(type)
            {
                //some actions
            }
            WriteLine("Please enter any key to continue...");
            ReadKey();
            Navigation.SelectedSettings();
        }

        public void ChangeParkingSpace()
        {
            Write($"Enter new parking space value(current: {Settings.ParkingSpace}): ");
            var space = uint.Parse(ReadLine());
            Settings.ParkingSpace = space;
            WriteLine("Success!");
            WriteLine("Please enter any key to continue...");
            ReadKey();
            Navigation.SelectedSettings();
        }

        public void ChangeFine()
        {
            Write($"Enter new fine value(current: {Settings.Fine}): ");
            var fine = double.Parse(ReadLine());
            Settings.Fine = fine;
            WriteLine("Success!");
            WriteLine("Please enter any key to continue...");
            ReadKey();
            Navigation.SelectedSettings();
        }


    }
}
