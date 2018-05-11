using System;

namespace ParkingEmulator.Core.Exceptions
{
    public class NotEnoughParkingSpaceException: Exception
    {
        public NotEnoughParkingSpaceException()
        {
        }

        public NotEnoughParkingSpaceException(string message)
            : base(message)
        {
        }

        public NotEnoughParkingSpaceException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
