using ScooterRental;
using ScooterRentalAPI.ScooterRental.Interfaces;

namespace ScooterRentalAPI.Validations
{
    public class RentedScooterValidation : IScooterValidator
    {
        public bool IsValid(Scooter scooter)
        {
            if (scooter.IsRented)
            {
                return false;
            }

            return true;
        }
    }
}

