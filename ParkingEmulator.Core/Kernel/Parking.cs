using ParkingEmulator.Core.Entities;
using ParkingEmulator.Core.Exceptions;
using ParkingEmulator.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Timers;

namespace ParkingEmulator.Core.Kernel
{
    public class Parking
    {
        private static readonly Lazy<Parking> lazy = new Lazy<Parking>(() => new Parking());
        public static Parking GetInstance { get { return lazy.Value; } }

        //----

        public List<ICar> Cars { get; private set; }

        public List<ITransaction> Transactions { get; private set; }

        public decimal EarnedBalance { get; private set; }

        //----

        private Parking()
        {
            Cars = new List<ICar>();
            Transactions = new List<ITransaction>();
            DebitInit();
            RemoveOldInit();
        }
       
        //----

        public void AddCar(ICar car)
        {
            if (Cars.Count != Settings.ParkingSpace)
            {
                if (Cars.Count > 0)
                {
                    var lastCarIndex = Cars.FindLastIndex(c => c is ICar);
                    car.Id = lastCarIndex + 1;
                }
                else
                {
                    car.Id = 1;
                }
                Cars.Add(car);
            }
            else
            {
                throw new NotEnoughParkingSpaceException("Not enough parking space!");
            }
        }

        public void RemoveCar(ICar car)
        {
            if (car.CarBalance > 0)
            {
                Cars.Remove(car);
            }
            else
            {
                throw new FinedCarException("Can't remove fined car!");
            }
        }

        public ICar FindCarById(int id)
        {
            if (IsCarExist(id))
            {
                return Cars.Find(c => c.Id == id);
            }
            else
            {
                throw new NotExistException("Car not found!");
            }
        }

        public void AddBalance(int carId, decimal funds)
        {
            if (funds > 0)
            {
                if (IsCarExist(carId))
                {
                    Cars.Find(c => c.Id == carId).CarBalance += funds;
                    AddTransaction(new Transaction(DateTime.Now, carId, funds, TransactionType.Deposit));
                }
                else
                {
                    throw new NotExistException("Car not found!");
                }
            }
            else
            {
                throw new ArgumentException("Wrong funds value!");
            }
        }

        public List<ITransaction> GetLastMinuteTransactions()
        {
            return Transactions.FindAll(t => DateTime.Now - t.TransactionTime <= TimeSpan.FromMinutes(1));
        }

        public uint GetFreeParkingPlaces()
        {
            return Settings.ParkingSpace - (uint)Cars.Count;
        }

        //----

        private bool IsCarExist(int carId)
        {
            return Cars.Exists(c => c.Id == carId);
        }

        private void AddTransaction(ITransaction transaction)
        {
            Transactions.Add(transaction);
        }

        private void DebitCar(ICar car)
        {
            if (car.CarBalance - Settings.Prices[car.Type] >= 0)
            {
                car.CarBalance -= Settings.Prices[car.Type];
                EarnedBalance += Settings.Prices[car.Type];
                AddTransaction(new Transaction(
                    DateTime.Now, 
                    car.Id, 
                    Settings.Prices[car.Type], 
                    TransactionType.Debit));   
            }
            else
            {
                car.CarBalance -= Settings.Prices[car.Type] * Settings.Fine;
                AddTransaction(new Transaction(
                    DateTime.Now, 
                    car.Id, 
                    Settings.Prices[car.Type], 
                    TransactionType.Fine));                
            }
        }

        private void DebitAllCars(object source, ElapsedEventArgs e)
        {
            if(Cars.Count > 0)
            {
                foreach (var car in Cars)
                {
                    DebitCar(car);
                }
            }
        }

        private void DebitInit()
        {
            var timer = new Timer();
            timer.Interval = Settings.Timeout * 1000;
            timer.Elapsed += new ElapsedEventHandler(DebitAllCars);
            timer.Enabled = true;
        }

        private void RemoveAllOldTransactions(object source, ElapsedEventArgs e)
        {
            if(Transactions.Count > 0)
            {
                Transactions.RemoveAll(t => DateTime.Now - t.TransactionTime >= TimeSpan.FromMinutes(2));
            }
        }

        private void RemoveOldInit()
        {
            var timer = new Timer();
            timer.Interval = 180000;
            timer.Elapsed += new ElapsedEventHandler(RemoveAllOldTransactions);
            timer.Enabled = true;
        }
    }
}
