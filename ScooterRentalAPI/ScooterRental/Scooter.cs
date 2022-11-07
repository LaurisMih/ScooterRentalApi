using ScooterRentalAPI;

namespace ScooterRental
{
    public class Scooter : Entity
    {
        public Scooter()
        {

        }
        /// <summary>
        /// Create new instance of the scooter.
        /// </summary>
        /// <param name="id">ID of the scooter.</param>
        /// <param name="pricePerMinute">Rental price of the scooter per one minute.</param>
        public Scooter( decimal pricePerMinute)
        {
          
            PricePerMinute = pricePerMinute;
            
        }

        public Scooter(int id, decimal pricePerMinute)
        {
            Id = id;
            PricePerMinute = pricePerMinute;
           
        }


        /// <summary>
        /// Unique ID of the scooter.
        /// </summary>
        public int Id { get; }
        /// <summary>
        /// Rental price of the scooter per one minute.
        /// </summary>
    public decimal PricePerMinute { get; }
        /// <summary>
        /// Identify if someone is renting this scooter.
        /// </summary>
    public bool IsRented { get; set; }
    }
}