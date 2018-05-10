using ParkingEmulator.Core.Entities;
using System;
using System.Collections.Generic;

namespace ParkingEmulator.Core.Kernel
{
    public static class Settings
    {
        public static TimeSpan Timeout { get; set; }

        public static Dictionary<CarType, decimal> Prices { get; set; }

        public static uint ParkingSpace { get; set; } = 10; //fix

        public static int Fine { get; set; } = 2;// fix
    }
}
