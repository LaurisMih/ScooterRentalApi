using Microsoft.EntityFrameworkCore;
using ScooterRental.Main.Models;
using System.Threading.Tasks;

namespace ScooterRental.Data
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
