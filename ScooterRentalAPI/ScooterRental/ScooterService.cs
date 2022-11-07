using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScooterRental.Interfaces;
using ScooterRentalAPI;
using ScooterRentalAPI.Exceptions;
using ScooterRentalAPI.ScooterRental.Interfaces;

namespace ScooterRental
{
    public class ScooterService : EntityService<Scooter>, IScooterService
    {
        private readonly IDbService dbService;
        private readonly IScooterRentalDbContext _context;

        public ScooterService(IDbService dbService, IScooterRentalDbContext scooterRentalDbContext, ScooterRentalDbContext context) : base(context)
        {
            this.dbService = dbService;
            _context = scooterRentalDbContext;
        }

        public ScooterService(ScooterRentalDbContext context) : base(context)
        {
        }
        

        public ServiceResult AddScooter( decimal pricePerMinute)
        {
            
            return Create(new Scooter( pricePerMinute));                 
        }

        public ServiceResult RemoveScooter(int id)
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
