using ParkingEmulator.Core.Entities;
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
            Cars = new List<ICar>(); //need to load from db;
            //EarnedBalance load or 0
            Transactions = new List<ITransaction>();
            DebitInit();
        }
       
        //----

        public void AddCar(ICar car)
        {
            if (Cars.Count + 1 <= Settings.ParkingSpace)
            {
                Cars.Add(car);
            }
            else
            {
                throw new Exception(); //implement
            }
        }

        public void RemoveCar(ICar car)
        {
            if (IsCarExist(car.Id))
            {
                Cars.Remove(car);
            }
            else
            {
                throw new Exception();//implement
            }
        }

        public void AddBalance(int carId, decimal funds)
        {
            if (IsCarExist(carId))
            {
                Cars.Find(c => c.Id == carId).CarBalance += funds;
                AddTransaction(new Transaction(DateTime.Now, carId, funds, TransactionType.Deposit));
            }
            else
            {
                throw new Exception(); //need to add NotFoundException
            }
        }

        public IEnumerable<ITransaction> GetLastMinuteTransactions()
        {
            return Transactions.FindAll(t => DateTime.Now - t.TransactionTime <= TimeSpan.FromMinutes(1));
        }

        public string[] GetAllTransactionsFromLog()
        {
            return null;
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
                car.CarBalance -= (decimal)((double)Settings.Prices[car.Type] * Settings.Fine);//fix
                EarnedBalance += (decimal)((double)Settings.Prices[car.Type] * Settings.Fine);
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
                    Console.WriteLine(car.CarBalance);
                }
            }

        }
        
        private void DebitInit()
        {
            var timer = new Timer();
            timer.Interval = Settings.Timeout * 1000;//fix
            timer.Elapsed += new ElapsedEventHandler(DebitAllCars);
            timer.Enabled = true;
        }
    }
}
