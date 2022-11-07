using ScooterRental.Main.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScooterRental.Main.Interfaces
{
    public interface IScooterService : IEntityService<Scooter>
    {
        /// <summary>
        /// Add scooter.
        /// </summary>
        /// <param name="id">Unique ID of the scooter</param>
        /// <param name="pricePerMinute">Rental price of the scooter per one minute</param>
        ServiceResults AddScooter(decimal pricePerMinute);
        /// <summary>
        /// Remove scooter. This action is not allowed for scooters if the rental is in progress.
        /// </summary>
        /// <param name="id">Unique ID of the scooter</param>
        ServiceResults RemoveScooter(int id);
        /// <summary>
        /// List of scooters that belong to the company.
        /// </summary>
        /// <returns>Return a list of available scooters.</returns>
        IList<Scooter> GetScooters();
        /// <summary>
        /// Get particular scooter by ID.
        /// </summary>
        /// <param name="scooterId">Unique ID of the scooter.</param>
        /// <returns>Return a particular scooter.</returns>
        Scooter GetScooterById(int scooterId);
    }

}
