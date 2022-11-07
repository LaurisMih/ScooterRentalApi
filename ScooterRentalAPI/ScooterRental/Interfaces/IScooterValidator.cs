using ScooterRental;

namespace ScooterRentalAPI.ScooterRental.Interfaces
{
    public interface IScooterValidator
    {
        bool IsValid(Scooter scooter);
    }
}