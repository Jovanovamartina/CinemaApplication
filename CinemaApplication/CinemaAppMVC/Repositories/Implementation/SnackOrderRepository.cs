

using CinemaAppMVC.Repositories.Abstraction;
using CinemaAppMVC.Repositories.Data;
using DomainModels;
using Microsoft.EntityFrameworkCore;

namespace Repositories.Implementation
{
    public class SnackOrderRepository : IRepository<SnackOrder>
    {
        //context class
        private readonly ApplicationDbContext _context;
        public SnackOrderRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Add(SnackOrder entity)
        {
            _context.SnackOrders.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(SnackOrder entity)
        {
            _context.SnackOrders.Remove(entity);
            _context.SaveChanges();
        }

        public List<SnackOrder> GetAll()
        {
            return _context.SnackOrders.Include(x=>x.Snack).ToList();
        }

        public SnackOrder GetById(int id)
        {
           return _context.SnackOrders.Include(x => x.Snack).FirstOrDefault(x => x.Id == id);
        }

        public void Update(SnackOrder entity)
        {
            _context.SnackOrders.Update(entity);
            _context.SaveChanges();
        }
    }
}
