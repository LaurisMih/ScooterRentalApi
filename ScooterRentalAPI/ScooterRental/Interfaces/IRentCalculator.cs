using ScooterRental;

namespace ScooterRentalAPI.ScooterRental.Interfaces
{
    public interface IRentCalculator
    {
        decimal Calculation(RentedScooters rentedScooter);
    }
}
