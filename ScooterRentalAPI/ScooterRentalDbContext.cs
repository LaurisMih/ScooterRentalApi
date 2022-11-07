using Microsoft.EntityFrameworkCore;
using ScooterRental;
using ScooterRentalAPI.ScooterRental.Interfaces;
using System.Threading.Tasks;

namespace ScooterRentalAPI
{
    public class ScooterRentalDbContext : DbContext, IScooterRentalDbContext
    {
        public ScooterRentalDbContext()
        {
        }

        public ScooterRentalDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Scooter> Scooter { get; set; }
        public DbSet<RentedScooters> RentedScooters { get; set; }
        

        public Task<int> SaveChangesAsync()
        {
            return base.SaveChangesAsync();
        }
    }
}
