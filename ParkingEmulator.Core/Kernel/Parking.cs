using ParkingEmulator.Core.Entities;
using System.Collections.Generic;

namespace ParkingEmulator.Core.Kernel
{
    public class Parking
    {
        public List<Car> Cars { get; set; }

        public List<Transaction> Transactions { get; set; }

        public decimal EarnedBalance { get; set; }
    }
}
