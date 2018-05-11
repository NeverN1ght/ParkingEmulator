using System;

namespace ParkingEmulator.Core.Exceptions
{
    public class FinedCarException: Exception
    {
        public FinedCarException()
        {
        }

        public FinedCarException(string message)
            : base(message)
        {
        }

        public FinedCarException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
