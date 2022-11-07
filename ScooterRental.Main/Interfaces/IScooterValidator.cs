using ScooterRental.Main.Models;

namespace ScooterRental.Main.Interfaces
{
    public interface IScooterValidator
    {
        bool IsValid(Scooter scooter);
    }
}