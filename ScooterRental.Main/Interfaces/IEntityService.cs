using ScooterRental.Main.Models;
using System.Collections.Generic;
using System.Linq;

namespace ScooterRental.Main.Interfaces
{
    public interface IEntityService<T> where T : Entity
    {
        ServiceResults Create(T entity);
        ServiceResults Delete(T entity);
        ServiceResults Update(T entity);
        List<T> GetAll();
        T GetById(int id);
        IQueryable<T> Query();
    }
}