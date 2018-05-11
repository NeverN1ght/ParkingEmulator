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

        public override string ToString()
        {
            string transaction = null;
            switch(Type)
            {
                case TransactionType.Deposit:
                    transaction = $"{TransactionTime}|{CarId}     |{Type}|+{Funds}$";
                    break;
                case TransactionType.Debit:
                    transaction = $"{TransactionTime}|{CarId}     |{Type}  |-{Funds}$";
                    break;
                case TransactionType.Fine:
                    transaction = $"{TransactionTime}|{CarId}     |{Type}   |-{Funds}$";
                    break;
            }
            return transaction;
        }
    }
}
