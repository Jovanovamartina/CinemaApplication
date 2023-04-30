using CinemaAppMVC.Repositories.Abstraction;
using CinemaAppMVC.Repositories.Data;
using DomainModels;


namespace Repositories.Implementation
{
    public class SizeRepository : IRepository<Size>
    {
        //context class
        private readonly ApplicationDbContext _context;
        public SizeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        //Add
        public void Add(Size entity)
        {
            _context.Sizes.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(Size entity)
        {
            _context.Sizes.Remove(entity);
            _context.SaveChanges();
        }

        public List<Size> GetAll()
        {
            return _context.Sizes.ToList();
        }

        public Size GetById(int id)
        {
            return _context.Sizes.SingleOrDefault(x => x.Id == id);
        }

        public void Update(Size entity)
        {
            _context.Sizes.Update(entity);
            _context.SaveChanges();
        }
    }
}
