using ParkingEmulator.Core.Interfaces;
using System;

namespace ParkingEmulator.Core.Entities
{
    public class Transaction: ITransaction
    {
        public DateTime TransactionTime { get; set; }

        public int CarId { get; set; }

        public decimal Funds { get; set; }

        public TransactionType Type { get; set; }


        public Transaction(DateTime transactionTime, int carId, decimal funds, TransactionType type)
        {
            TransactionTime = transactionTime;
            CarId = carId;
            Funds = funds;
            Type = type;
        }
    }
}
