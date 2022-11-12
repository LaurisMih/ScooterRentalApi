
using ScooterRental.Main.Interfaces;
using System.Collections.Generic;

namespace ScooterRental.Main.Models
{
    public class ServiceResults
    {
        public ServiceResults(bool success)
        {
            Success = success;
            Errors = new List<string>();
        }

        public ServiceResults AddError(string error)
        {
            Errors.Add(error);
            return this;
        }

        public ServiceResults SetEntity(IEntity entity)
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
