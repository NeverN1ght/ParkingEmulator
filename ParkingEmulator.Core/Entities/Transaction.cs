using System;

namespace ParkingEmulator.Core.Entities
{
    public class Transaction
    {
        public DateTime TransactionTime { get; set; }

        public int CarId { get; set; }

        public decimal DebitedFunds { get; set; }
    }
}
