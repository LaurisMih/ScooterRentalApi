using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Exchange.WebServices.Data;
using ScooterRental.Interfaces;
using ScooterRentalAPI.ScooterRental.Interfaces;
using ScooterRentalAPI;

namespace ScooterRental
{
    public class RentalCompany : IRentalCompany 
    {
        public string Name { get; }      

        private readonly IEntityService<RentedScooters> _entityService;      
        private IScooterService _scooterName;
        
        public RentalCompany(IEntityService<RentedScooters> entityService, IScooterService scooterName)
        {
            Name = "text";
            _entityService = entityService;
            _scooterName = scooterName;
        }

        public RentalCompany()
        {
        }

        public ScooterRentalAPI.ServiceResult StartRent(Scooter scooter)
        {
            var scootersId = _scooterName.GetScooterById(scooter.Id);           
            scooter.IsRented = true;
            return _entityService.Create(new RentedScooters(scooter.Id, DateTime.UtcNow, 
                scooter.PricePerMinute));                      
        }

      
        public ScooterRentalAPI.ServiceResult EndRent(Scooter scooter)
        {
            var scootersId = _scooterName.GetScooterById(scooter.Id);
            var rentedScooter = _entityService.Query().FirstOrDefault(s => s.ScooterId == scootersId.Id && !s.EndTime.HasValue);
            rentedScooter.EndTime = DateTime.UtcNow;
            scootersId.IsRented = false;
            return _entityService.Update(rentedScooter);

        }

    
        
        public decimal CalculateIncome(int? year, bool includeNotCompletedRentals)
        {
            RentCalculator rentCalculator = new RentCalculator();
            decimal totalYearIncome = 0;
            var rentedScootersList = new List<RentedScooters>();
            

            if (!year.HasValue && includeNotCompletedRentals == false)//ja gads ir null un bool ir false
            {
              rentedScootersList = _entityService.Query().Where(s => s.EndTime.HasValue).ToList();
            }

            if (year.HasValue && includeNotCompletedRentals == false)//ja bool ir false un ja gads nav null
            {
                   
              rentedScootersList = _entityService.Query().Where(s => s.EndTime.HasValue && 
                    s.EndTime.Value.Year == year).ToList();
            }

            if (!year.HasValue && includeNotCompletedRentals == true)//ja gads ir null un bool ir true
            {
               rentedScootersList = _entityService.Query().Where(s => !s.EndTime.HasValue).ToList();
            }

            if (year.HasValue && includeNotCompletedRentals == true) //ja bool ir true un ja gads nav null
            {
                   
                rentedScootersList = _entityService.Query().Where(s => !s.EndTime.HasValue && 
                        s.EndTime.Value.Year == year).ToList();
            }

            foreach (var item in rentedScootersList)
            {

                totalYearIncome += rentCalculator.Calculation(item);
            }

            return totalYearIncome;
                           
        }
    }
}
