using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ScooterRental;
using ScooterRental.Interfaces;
using ScooterRentalAPI.ScooterRental.Interfaces;

namespace TestProject1
{
    [TestClass]
    public class RentTests
    {
        private IScooterService _scooterService;
        private IRentalCompany _company;
        private IScooterRentalDbContext _dbContext;
        private IDbService _dbService;
        private IEntityService<Scooter> entityService;
        [TestInitialize]
        public void Setup()
        {
            _company = new RentalCompany();
           // _scooterService = new ScooterService();           
        }
                
        [TestMethod]
        public void StartRent_CanStartRent()
        {
            // var scooter = _dbService.Create<Scooter>(new Scooter(1, 0.2m));
            Scooter scooter = new Scooter(1, 0.2m);
            _company.StartRent(scooter);
            _scooterService.GetScooterById(scooter.Id).IsRented.Should().BeTrue();
        }

        [TestMethod]
        public void StartRent_CanEndRent()
        {
            Scooter scooter = new Scooter(1, 0.2m);
            //_company.StartRent(scooter);
            scooter.IsRented = false;
            _scooterService.GetScooterById(scooter.Id).IsRented.Should().BeFalse();
        }
    }
}
