using Microsoft.AspNetCore.Mvc;
using ScooterRental.Main.Interfaces;
using ScooterRental.Main.Models;
using ScooterRental.Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ScooterRentalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentController : ControllerBase
    {

        public readonly IDbService _dbService;
        public readonly IRentalCompany _rentalCompany;
        

        public RentController(IDbService dbService, IRentalCompany rentalCompany)
        {
            _dbService = dbService;
            _rentalCompany = rentalCompany;
            
        }

        [HttpPut("startRent{id}")]
        public IActionResult StartRent(int id)
        {
            var scooter = _dbService.GetById<Scooter>(id);
            if (scooter.IsRented)
            {
                return Conflict();
            }
            var rentedScooter = _rentalCompany.StartRent(scooter);
            return Created("", rentedScooter);
        }

        [HttpPut("endRent{id}")]
        public IActionResult EndRent(int id)
        {
            var scooter = _dbService.GetById<Scooter>(id);
            if (scooter.IsRented)
            {
                var rentedScooter = _rentalCompany.EndRent(scooter);
                return Created("", rentedScooter);
            }           
                return Conflict();            
        }
    }
}
