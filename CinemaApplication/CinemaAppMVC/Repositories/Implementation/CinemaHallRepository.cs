using CinemaAppMVC.Repositories.Abstraction;
using CinemaAppMVC.Repositories.Data;
using DomainModels;
using Microsoft.EntityFrameworkCore;

namespace Repositories.Implementation
{
    public class CinemaHallRepository : IRepository<CinemaHall>
    {
        //context class
        private readonly ApplicationDbContext _context;
        public CinemaHallRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        //Add
        public void Add(CinemaHall entity)
        {
            _context.CinemaHalls.Add(entity);
            _context.SaveChanges();
        }

        //Delete
        public void Delete(CinemaHall entity)
        {
            _context.CinemaHalls.Remove(entity);
            _context.SaveChanges();
        }

        //Get All
        public List<CinemaHall> GetAll()
        {
            return _context.CinemaHalls.Include(x => x.Movie).Include(x => x.Size).ToList();
        }

        //Get By Id
        public CinemaHall GetById(int id)
        {
            return _context.CinemaHalls.Include(x => x.Movie).Include(x => x.Size).SingleOrDefault(x => x.Id == id);
        }

        //Update
        public void Update(CinemaHall entity)
        {
            _context.CinemaHalls.Update(entity);
            _context.SaveChanges();
        }
    }
}
