using Microsoft.EntityFrameworkCore;
using ScooterRental;
using System.Threading.Tasks;

namespace ScooterRentalAPI.ScooterRental.Interfaces
{
    public interface IScooterRentalDbContext
    {
        DbSet<Scooter> Scooter { get; set; }
        DbSet<RentedScooters> RentedScooters { get; set; }
        Task<int> SaveChangesAsync();
        int SaveChanges();
    }
}