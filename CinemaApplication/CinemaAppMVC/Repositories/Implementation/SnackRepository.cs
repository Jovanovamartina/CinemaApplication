

using CinemaAppMVC.Repositories.Abstraction;
using CinemaAppMVC.Repositories.Data;
using DomainModels;

namespace CinemaAppMVC.Repositories.Implementation
{
    public class SnackRepository : IRepository<Snack>
    {
        //context class
        private readonly ApplicationDbContext _context;
        public SnackRepository(ApplicationDbContext context)
        {
            _context = context;
        }
      
        //Add
        public void Add(Snack entity)
        {
            _context.Snacks.Add(entity);
            _context.SaveChanges();
        }

        //Delete
        public void Delete(Snack entity)
        {
            _context.Snacks.Remove(entity);
            _context.SaveChanges();
        }

        //Get All
        public List<Snack> GetAll()
        {
            return _context.Snacks.ToList();
        }

        //Get By Id
        public Snack GetById(int id)
        {
            return _context.Snacks.SingleOrDefault(x => x.Id == id);
        }

        //Update
        public void Update(Snack entity)
        {
            _context.Snacks.Update(entity);
            _context.SaveChanges();
        }
    }
}
