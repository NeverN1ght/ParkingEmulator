using System;

namespace ParkingEmulator.Console.Exceptions
{
    public class WrongSwitchItemException: Exception
    {
        public WrongSwitchItemException()
        {
        }

        public WrongSwitchItemException(string message)
            : base(message)
        {
        }

        public WrongSwitchItemException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
