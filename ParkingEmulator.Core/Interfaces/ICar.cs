using ParkingEmulator.Core.Entities;

namespace ParkingEmulator.Core.Interfaces
{
    public interface ICar
    {
        int Id { get; set; }

        decimal CarBalance { get; set; }

        CarType Type { get; set; }
    }
}
