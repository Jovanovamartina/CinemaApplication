
using CinemaAppMVC.Repositories.Abstraction;
using CinemaAppMVC.Repositories.Data;
using DomainModels;
using Microsoft.EntityFrameworkCore;

namespace Repositories.Implementation
{
    public class MovieProgramRepository : IRepository<MovieProgram>
    {
        //context class
        private readonly ApplicationDbContext _context;
        public MovieProgramRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        //Add
        public void Add(MovieProgram entity)
        {
            _context.MoviePrograms.Add(entity);
            _context.SaveChanges();
        }

        //Delete
        public void Delete(MovieProgram entity)
        {
            _context.MoviePrograms.Remove(entity);
            _context.SaveChanges();
        }

        //Get All
        public List<MovieProgram> GetAll()
        {
            return _context.MoviePrograms
                .Include(x => x.CinemaHall)
                .ThenInclude(x => x.Movie)
                .Include(x => x.CinemaHall)
                .ThenInclude(x => x.Size)
                .ToList();
        }

        //Get By Id
        public MovieProgram GetById(int id)
        {
            return _context.MoviePrograms
                 .Include(x => x.CinemaHall)
                 .ThenInclude(x => x.Movie)
                 .Include(x => x.CinemaHall)
                 .ThenInclude(x => x.Size)
                 .SingleOrDefault(x => x.Id == id);
        }

        //Update
        public void Update(MovieProgram entity)
        {
            _context.MoviePrograms.Update(entity);
            _context.SaveChanges();
        }
    }
}
