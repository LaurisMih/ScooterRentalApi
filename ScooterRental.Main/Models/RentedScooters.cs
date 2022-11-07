using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ScooterRental.Main.Models
{
    public class RentedScooters : Entity
    {
        private decimal v1;
        private int v2;

        public RentedScooters()
        {

        }
        
        public int ScooterId { get; set; }
        public DateTime StartTime { get; set; } 
        public DateTime? EndTime { get; set; }
        public decimal PricePerMinute { get; set; }

        public RentedScooters(int iD, DateTime startTime,  decimal pricePerMinute)
        {
            ScooterId = iD;
            StartTime = startTime;
            PricePerMinute = pricePerMinute;
            EndTime = null;
        }

        public RentedScooters(decimal v1, int v2)
        {
            this.v1 = v1;
            this.v2 = v2;
            StartTime = DateTime.Now;
            EndTime = null;
        }
    }
}
