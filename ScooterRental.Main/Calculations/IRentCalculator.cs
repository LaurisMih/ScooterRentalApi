using ScooterRental.Main.Models;

namespace ScooterRental.Main.Calculations
{
    public interface IRentCalculator
    {
        decimal Calculation(RentedScooters rentedScooter);
    }
}
