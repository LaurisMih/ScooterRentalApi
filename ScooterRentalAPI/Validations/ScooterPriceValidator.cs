using ScooterRental;
using ScooterRentalAPI.ScooterRental.Interfaces;

namespace ScooterRentalAPI.Validations
{
    public class ScooterPriceValidator : IScooterValidator
    {
        public bool IsValid(Scooter scooter)
        {
            if (scooter.PricePerMinute <= 0)
            {
                return false;
            }

            return true;
        }
    }
}
