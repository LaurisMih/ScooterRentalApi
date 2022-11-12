
using ScooterRental.Main.Interfaces;
using ScooterRental.Main.Models;

namespace ScooterRental.Main.Validations
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
