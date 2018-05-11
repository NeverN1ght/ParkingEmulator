using ParkingEmulator.Console.Presentation;
using ParkingEmulator.Core.Entities;
using ParkingEmulator.Core.Kernel;
using ParkingEmulator.Log.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ParkingEmulator.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var parking = Parking.GetInstance;

            TransactionLogger.LogInit();
            Navigation.RunMenu(parking);
            
        }
    }
}
