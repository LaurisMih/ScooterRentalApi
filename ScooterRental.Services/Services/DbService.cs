using Microsoft.EntityFrameworkCore;
using ScooterRental.Data;
using ScooterRental.Main.Models;
using ScooterRental.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace ScooterRental.Services
{

    public class DbService : IDbService
    {
        protected ScooterRentalDbContext _context;

        public DbService(ScooterRentalDbContext context)
        {
            _context = context;
        }

        public ServiceResults Create<T>(T entity) where T : Entity
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();

            return new ServiceResults(true).SetEntity(entity);
        }

        public ServiceResults Delete<T>(T entity) where T : Entity
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();

            return new ServiceResults(true);
        }

        public ServiceResults Update<T>(T entity) where T : Entity
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();

            return new ServiceResults(true).SetEntity(entity);
        }

        public List<T> GetAll<T>() where T : Entity
        {
            return _context.Set<T>().ToList();
        }

        public T GetById<T>(int id) where T : Entity
        {
            return _context.Set<T>().SingleOrDefault(x => x.Id == id);
        }

        public IQueryable<T> Query<T>() where T : Entity
        {
            return _context.Set<T>().AsQueryable();
        }
    }
}
