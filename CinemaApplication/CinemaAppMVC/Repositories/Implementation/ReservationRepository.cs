using CinemaAppMVC.Repositories.Abstraction;
using CinemaAppMVC.Repositories.Data;
using DomainModels;
using Microsoft.EntityFrameworkCore;


namespace Repositories.Implementation
{
    public class ReservationRepository : IRepository<Reservation>
    {
        //context class
        private readonly ApplicationDbContext _context;
        public ReservationRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Add(Reservation entity)
        {
            _context.Reservations.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(Reservation entity)
        {
            _context.Reservations.Remove(entity);
            _context.SaveChanges();
        }

        public List<Reservation> GetAll()
        {
            return _context.Reservations
                .Include(x => x.SnackOrders)
                .ThenInclude(x => x.Snack)
                .Include(x => x.MovieProgram)
                .ThenInclude(x => x.CinemaHall)
                .ThenInclude(x => x.Movie)
                .Include(x => x.MovieProgram)
                .ThenInclude(x => x.CinemaHall)
                .ThenInclude(x => x.Size)
                .ToList();
        }

        public Reservation GetById(int id)
        {
            return _context.Reservations
               .Include(x => x.SnackOrders)
               .ThenInclude(x => x.Snack)
               .Include(x => x.MovieProgram)
               .ThenInclude(x => x.CinemaHall)
               .ThenInclude(x => x.Movie)
               .Include(x => x.MovieProgram)
               .ThenInclude(x => x.CinemaHall)
               .ThenInclude(x => x.Size)
               .SingleOrDefault(x => x.Id == id);
        }

        public void Update(Reservation entity)
        {
            _context.Reservations.Update(entity);
            _context.SaveChanges();
        }
    }
}
