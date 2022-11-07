using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScooterRental.Main.Calculations;
using ScooterRental.Main.Models;

namespace ScooterRental.Main.Calculations
{
    public  class RentCalculator: IRentCalculator
    {

        public decimal Calculation(RentedScooters rentedScooter) 
        {
            DateTime endTime = rentedScooter.EndTime ?? DateTime.UtcNow;
            var startTime = rentedScooter.StartTime;
            decimal pricePerMinute = rentedScooter.PricePerMinute;

            decimal totalPrice = 0;


            if (rentedScooter.StartTime.Day == endTime.Day)
            {
                
                var rentedMinutes = (endTime - rentedScooter.StartTime).TotalMinutes;
                decimal pricePerUse = rentedScooter.PricePerMinute * Convert.ToDecimal(rentedMinutes);

                if (pricePerUse > 20)
                {
                    totalPrice = 20;
                }

                else
                {
                    totalPrice = pricePerUse;
                }
                
            }
            else
            {
                var firstDayIncome = (decimal)(startTime.Date.AddDays(1) - startTime).TotalMinutes * pricePerMinute;

                if (firstDayIncome > 20)
                {
                    firstDayIncome = 20;
                }

                var lastDayIncome = (decimal)(endTime - endTime.Date).TotalMinutes * pricePerMinute;

                if (lastDayIncome > 20)
                {
                    lastDayIncome = 20;
                }

                int daysBetween = (endTime - startTime.AddDays(1)).Days;
                int daysBetweenIncome = daysBetween * 20;

                totalPrice = firstDayIncome + daysBetweenIncome + lastDayIncome;
            }
            return totalPrice;
            

        }
    }
}
