using Microsoft.VisualStudio.TestTools;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ScooterRental.Main.Models;

namespace ScooterRentalS.Tests
{
    [TestClass]
    public class ScooterTests
    {
        private Scooter _scooter;

        [TestMethod]
        public void ScooterCreation_IDAndPricePerMinuteSetCorrectly()
        {
            _scooter = new Scooter(1, 0.2m);
            _scooter.Id.Should().Be(1);
            _scooter.PricePerMinute.Should().Be(0.2m);
            _scooter.IsRented.Should().BeFalse();
        }

        [TestMethod]
        public void RentalCreation_RentStartShouldBeDateTimeNowAndRentEndShouldBeNull()
        {
            var rental = new RentedScooters(0.2m, 1);
            rental.StartTime.Should().BeCloseTo(DateTime.Now, TimeSpan.FromMilliseconds(100));
            rental.EndTime.Should().BeNull();
        }
    }
}