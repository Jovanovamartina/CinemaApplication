using CinemaAppMVC.Repositories.Abstraction;
using CinemaAppMVC.Repositories.Data;
using DomainModels;


namespace Repositories.Implementation
{
    public class MovieRepository : IRepository<Movie>
    {
        //context class
        private readonly ApplicationDbContext _context;
        public MovieRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        //Add
        public void Add(Movie entity)
        {
            _context.Movies.Add(entity);
            _context.SaveChanges();
        }

        //Delete
        public void Delete(Movie entity)
        {
            _context.Movies.Remove(entity);
            _context.SaveChanges();
        }

        //Get All
        public List<Movie> GetAll()
        {
            return _context.Movies.ToList();
        }

        //Get By Id
        public Movie GetById(int id)
        {
            return _context.Movies.SingleOrDefault(x => x.Id == id);
        }

        //Update
        public void Update(Movie entity)
        {
            _context.Movies.Update(entity);
            _context.SaveChanges();
        }
    }
}
