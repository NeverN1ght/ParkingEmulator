using System;

namespace ParkingEmulator.Core.Exceptions
{
    public class NotExistException: Exception
    {
        public NotExistException()
        {
        }

        public NotExistException(string message)
            : base(message)
        {
        }

        public NotExistException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
