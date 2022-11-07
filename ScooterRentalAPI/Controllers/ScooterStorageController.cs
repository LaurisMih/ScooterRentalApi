using Microsoft.AspNetCore.Mvc;
using ScooterRental;
using ScooterRental.Interfaces;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ScooterRentalAPI.Controllers
{
    [Route("rentController")]
    [ApiController]
    public class ScooterStorageController : ControllerBase
    {
        private readonly IScooterService _scooterService;

        public ScooterStorageController(IScooterService scooterService)
        {
            _scooterService = scooterService;
        }

        
        [Route("/addScooter")]
        [HttpPut]
        public IActionResult AddScooterApi(decimal pricePerMinute)
        {
            var result = _scooterService.AddScooter(pricePerMinute);
            if (result.Success)
            {
               
                return Created("", result.Entity);
            
            }
            return BadRequest(result);
        }
        
        [HttpDelete("{id}")]
        public IActionResult DeleteScooterById(int id)
        {
            Scooter scooter = _scooterService.GetById(id);
            if (scooter != null)
            {
                var result = _scooterService.Delete(scooter);
                if (result.Success)
                {
                    return Ok();
                }
                return Problem(result.FormatedErrors);
            }
            return Problem();
        }
    }
}
