using System;

namespace ParkingEmulator.Core.Interfaces
{
    public interface ITransaction
    {
        DateTime TransactionTime { get; set; }

        int CarId { get; set; }

        decimal DebitedFunds { get; set; }
    }
}
