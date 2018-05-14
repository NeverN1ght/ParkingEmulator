using ParkingEmulator.Core.Interfaces;
using ParkingEmulator.Core.Kernel;
using System.Collections.Generic;
using System.IO;
using System.Timers;

namespace ParkingEmulator.Log.Logging
{
    public static class TransactionLogger
    {
        private static void WriteTransactionLog(List<ITransaction> transactions)
        {
            using (StreamWriter sw = new StreamWriter("../../../" + Settings.LogFileName, true))
            {
                foreach (var transaction in transactions)
                {
                    sw.WriteLine(transaction.ToString());
                }
            }
        }

        public static List<string> ReadTransactionLog()
        {
            var transactions = new List<string>();
            string line;
            using (StreamReader sr = new StreamReader("../../../" + Settings.LogFileName))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    transactions.Add(line);
                }
            }
            return transactions;
        }

        private static void LogTransactions(object source, ElapsedEventArgs e)
        {
            var parking = Parking.GetInstance;
            if (parking.Transactions.Count > 0)
            {
                WriteTransactionLog(parking.GetLastMinuteTransactions());      
            }
        }

        public static void LogInit()
        {
            var timer = new Timer();
            timer.Interval = 60000;
            timer.Elapsed += new ElapsedEventHandler(LogTransactions);
            timer.Enabled = true;
        }
    }
}
