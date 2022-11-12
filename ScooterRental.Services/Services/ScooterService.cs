using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScooterRental.Services.Interfaces;
using ScooterRental.Main.Models;
using ScooterRental.Data;
using ScooterRental.Main.Interfaces;
using ScooterRental.Services.Services;

namespace ScooterRental.Services
{
    public class ScooterService : EntityService<Scooter>,IScooterService
    {
        private readonly IDbService _dbService;
        private readonly IScooterRentalDbContext _context;

        public ScooterService(IDbService dbService, IScooterRentalDbContext scooterRentalDbContext, ScooterRentalDbContext context) : base(context)
        {
            _dbService = dbService;
            _context = scooterRentalDbContext;
        }

        public ScooterService(ScooterRentalDbContext context) : base(context)
        {
        }
        
        public ServiceResults AddScooter( decimal pricePerMinute)
        {           
            return Create(new Scooter( pricePerMinute));                 
        }

        public ServiceResults RemoveScooter(int id)
        {
           var scooterId = GetById(id);
           return Delete(scooterId);
                         
        }

        public IList<Scooter> GetScooters()
        {
            List<Scooter> aviableScooters = null;

            foreach (var item in aviableScooters)
            {
                if (!item.IsRented)
                {
                    aviableScooters.Add(item);
                }
            }       
            return aviableScooters;
        }

        public Scooter GetScooterById(int scooterId)
        {
            return GetById(scooterId);           
        }
    }
}
