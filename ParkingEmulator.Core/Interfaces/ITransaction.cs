using ParkingEmulator.Core.Entities;
using System;

namespace ParkingEmulator.Core.Interfaces
{
    public interface ITransaction
    {
        DateTime TransactionTime { get; set; }

        int CarId { get; set; }

        decimal Funds { get; set; }

        TransactionType Type { get; set; }
    }
}
