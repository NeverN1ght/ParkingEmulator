using ParkingEmulator.Console.Presentation;
using ParkingEmulator.Core.Kernel;
using ParkingEmulator.Log.Logging;

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
