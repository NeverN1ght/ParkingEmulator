using ParkingEmulator.Core.Entities;
using ParkingEmulator.Core.Interfaces;
using System;
using System.Collections.Generic;

namespace ParkingEmulator.Core.Kernel
{
    public class Parking
    {
        private static readonly Lazy<Parking> lazy = new Lazy<Parking>(() => new Parking());

        public static Parking GetInstance { get { return lazy.Value; } }

        private Parking()
        {
            this.Cars = new List<ICar>();
            this.Transactions = new List<ITransaction>();
        }

        //----
        public List<ICar> Cars { get; private set; }

        public List<ITransaction> Transactions { get; private set; }

        public decimal EarnedBalance { get; private set; }

        //----
        public void AddCar(ICar car)
        {
            this.Cars.Add(car);
        }

        public void RemoveCar(ICar car)
        {
            this.Cars.Remove(car);
        }

        public bool IsCarExist(int carId)
        {
            return this.Cars.Exists(c => c.Id == carId);
        }

        public void AddBalance(int carId, decimal funds)
        {
            var car = this.Cars.Find(c => c.Id == carId);
            car.CarBalance += funds;
        }

        public void DebitFunts(ICar car) //can be extension
        {
            if (car.CarBalance - Settings.Prices[car.Type] >= 0)
            {
                car.CarBalance -= Settings.Prices[car.Type];
            }
            else
            {
                car.CarBalance -= Settings.Prices[car.Type] * Settings.Fine;
            }
        }

        public IEnumerable<ITransaction> GetLastMinuteTransactions()
        {
            return this.Transactions.FindAll(t => DateTime.Now - t.TransactionTime <= TimeSpan.FromMinutes(1));
        }

        public decimal GetTotalIncome()
        {
            return this.EarnedBalance;
        }

        public uint GetFreeParkingPlaces()
        {
            return Settings.ParkingSpace - (uint)this.Cars.Count;
        }

        private void LogLastMinuteTransactions()
        {
            //implement
        }
    }
}
