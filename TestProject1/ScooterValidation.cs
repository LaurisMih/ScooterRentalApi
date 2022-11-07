using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ScooterRental;
using ScooterRentalAPI;
using ScooterRentalAPI.ScooterRental.Interfaces;
using ScooterRentalAPI.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScooterValidations
{
    [TestClass]
    public class ScooterValidations
    {
        private  IScooterValidator _priceValidator;
        private  IScooterValidator _isRentedValidator;

        [TestInitialize]
        public void Setup()
        {
            _priceValidator = new ScooterPriceValidator();
            _isRentedValidator = new RentedScooterValidation();
        }
        [TestMethod]
        public void ScooterValidation_ShouldReturnFalseIfGivenZeroOrNegativePricePerMinute()
        {
            var scooter = new Scooter(0);
            var scooter2 = new Scooter(-2);

            _priceValidator.IsValid(scooter).Should().BeFalse();
            _priceValidator.IsValid(scooter2).Should().BeFalse();
        }

        [TestMethod]
        public void ScooterValidation_ShouldReturnTrueIfGivenPositivePricePerMinute()
        {
            var scooter = new Scooter(0.2m);            
            _priceValidator.IsValid(scooter).Should().BeTrue();
           
        }

        [TestMethod]
        public void ScooterValidation_ShouldReturnFalseIfIsRentedIsTrue()
        {
            var scooter = new Scooter(0.2m);
            scooter.IsRented = true;
            _isRentedValidator.IsValid(scooter).Should().BeFalse();
        }

        [TestMethod]
        public void ScooterValidation_ShouldReturnTrueIfIsRentedIsFalse()
        {
            var scooter = new Scooter(0.2m);
            _isRentedValidator.IsValid(scooter).Should().BeTrue();
        }        
    }
}
