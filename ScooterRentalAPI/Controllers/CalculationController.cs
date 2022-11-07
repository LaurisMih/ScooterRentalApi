using Microsoft.AspNetCore.Mvc;
using ScooterRental;
using ScooterRentalAPI.ScooterRental.Interfaces;
using System;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ScooterRentalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculationController : ControllerBase
    {
        public readonly IDbService _dbservice;
        public readonly IRentCalculator _rentCalculator;

        public CalculationController(IDbService dbservice, IRentCalculator rentCalculator)
        {
            _dbservice = dbservice;
            _rentCalculator = rentCalculator;
        }
        
        [HttpPut("scootersWithEndTime/{id}")]
        public IActionResult GetPriceScooterWithEndTime(RentedScooters rentedScooters)
        {
           
             _dbservice.GetById<RentedScooters>(rentedScooters.ScooterId);
            if (rentedScooters.EndTime.HasValue)
            {
                var scooterWithEndTimePrice = _rentCalculator.Calculation(rentedScooters);
                return Created("", scooterWithEndTimePrice);
            }
            return Conflict();
        }

        [HttpPut("scootersWithNoEndTime/{id}")]
        public IActionResult GetPriceScooterWithNoEndTime(RentedScooters rentedScooters)
        {
            _dbservice.GetById<RentedScooters>(rentedScooters.ScooterId);
            if (!rentedScooters.EndTime.HasValue)
            {
                rentedScooters.EndTime = DateTime.Now;
                var scooterWithNoEndTimePrice = _rentCalculator.Calculation(rentedScooters);
                return Created("", scooterWithNoEndTimePrice);
            }
            return Conflict();
        }        
    }
}
