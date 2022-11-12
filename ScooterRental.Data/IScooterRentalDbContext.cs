using Microsoft.EntityFrameworkCore;
using ScooterRental;
using ScooterRental.Main.Models;
using System.Threading.Tasks;

namespace ScooterRental.Data
{
    public interface IScooterRentalDbContext
    {
        DbSet<Scooter> Scooter { get; set; }
        DbSet<RentedScooters> RentedScooters { get; set; }
        Task<int> SaveChangesAsync();
        int SaveChanges();
    }
}