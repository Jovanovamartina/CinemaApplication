namespace CinemaAppMVC.Repositories.Abstraction
{
    public interface IRepository<T>
    {
        void Update(T entity);
        void Add(T entity);
        void Delete(T entity);
        List<T> GetAll();
        T GetById(int id);
    }
}
