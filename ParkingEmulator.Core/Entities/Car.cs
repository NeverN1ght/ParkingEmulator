using ParkingEmulator.Core.Interfaces;

namespace ParkingEmulator.Core.Entities
{
    public class Car: ICar
    {
        public int Id { get; set; }

        public decimal CarBalance { get; set; }

        public CarType Type { get; set; }

        public Car(int id, decimal carBalance, CarType type)
        {
            Id = id;
            CarBalance = carBalance;
            Type = type;
        }

        public override string ToString()
        {
            return $"{Id}|{CarBalance}|{Type}";
        }
    }
}
