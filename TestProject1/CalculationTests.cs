using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ScooterRental.Main.Calculations;
using ScooterRental.Main.Models;

namespace CalculationTests
{
    [TestClass]
    public class CalculationTests
    {        
        private  RentCalculator _calculator;

        [TestInitialize]
        public void Setup()
        {
               
            _calculator = new RentCalculator();
        }

        [TestMethod]
        public void CalculateRentCost_10MinutesRent()
        {                
              var scooter = new RentedScooters(1, DateTime.UtcNow.AddMinutes(-10), 0.2m);
            _calculator.Calculation(scooter);
        }

        [TestMethod]
        public void CalculateRentCost_60MinutesRent()
        {           
            var scooter = new RentedScooters(1, DateTime.UtcNow.AddMinutes(-60), 0.2m);
            _calculator.Calculation(scooter);
        }

        [TestMethod]
        public void CalculateRentCost_24hoursRent()
        {           
            var scooter = new RentedScooters(1, DateTime.UtcNow.AddMinutes(-1440), 0.2m);
            _calculator.Calculation(scooter);
        }

        [TestMethod]
        public void CalculateRentCost_1WeekRent()
        {           
            var scooter = new RentedScooters(1, DateTime.UtcNow.AddDays(-7), 0.2m);
            _calculator.Calculation(scooter);
        }
    }
}

