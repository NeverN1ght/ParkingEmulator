﻿using ParkingEmulator.Core.Entities;
using System.Collections.Generic;

namespace ParkingEmulator.Core.Kernel
{
    public static class Settings
    {
        public static int Timeout { get; set; }

        public static Dictionary<CarType, decimal> Prices { get; set; }

        public static uint ParkingSpace { get; set; }

        public static decimal Fine { get; set; }

        public static string LogFileName { get; set; }


        static Settings()
        {
            Timeout = 3;
            Prices = new Dictionary<CarType, decimal>
            {
                {CarType.Truck, 5 },
                {CarType.Passenger, 3 },
                {CarType.Bus, 2 },
                {CarType.Motorcycle, 1 }
            };
            ParkingSpace = 10;
            Fine = 1.5m;
            LogFileName = "Transactions.log";
        }
    }
}
