
using ScooterRentalAPI.ScooterRental.Interfaces;
using System.Collections.Generic;

namespace ScooterRentalAPI
{
    public class ServiceResult
    {
        public ServiceResult(bool success)
        {
            Success = success;
            Errors = new List<string>();
        }

        public ServiceResult AddError(string error)
        {
            Errors.Add(error);
            return this;
        }

        public ServiceResult SetEntity(IEntity entity)
        {
            Entity = entity;
            return this;
        }



        public bool Success { get; private set; }
        public IEntity Entity { get; private set; }

        public IList<string> Errors { get; private set; }

        public string FormatedErrors => string.Join(",", Errors);
    }
}
