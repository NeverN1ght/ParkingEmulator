using ParkingEmulator.Core.Interfaces;

namespace ParkingEmulator.Core.Entities
{
    public class Car: ICar
    {
        public int Id { get; set; }

        public decimal CarBalance { get; set; }

        public CarType Type { get; set; }

        public Car(decimal carBalance, CarType type)
        {
            CarBalance = carBalance;
            Type = type;
        }

        public override string ToString()
        {
            string car = null;
            switch (Type)
            {
                case CarType.Bus:
                    car = $" {Id}    |{Type}       |{CarBalance}$";
                    break;
                case CarType.Motorcycle:
                    car = $" {Id}    |{Type}|{CarBalance}$";
                    break;
                case CarType.Passenger:
                    car = $" {Id}    |{Type} |{CarBalance}$";
                    break;
                case CarType.Truck:
                    car = $" {Id}    |{Type}     |{CarBalance}$";
                    break;
            }
            return car;
        }
    }
}
