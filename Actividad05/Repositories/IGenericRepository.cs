namespace Lab04_AlexanderVasquez.Repositories;

public interface IGenericRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAll();
    Task<T?> GetById(int id);
    Task Add(T entity);
    void Update(T entity);
    Task Delete(int id);
}