
using ScooterRental.Main.Interfaces;
using ScooterRental.Main.Models;

namespace ScooterRental.Main.Validations
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

