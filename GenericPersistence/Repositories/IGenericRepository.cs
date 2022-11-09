namespace GenericPersistence.Repositories;

public interface IGenericRepository<T> where T : class
{
    Task<T> Get(Guid id);
    Task<List<T>> GetAll();
    Task<T> Add(T entity);
    Task<bool> Exists(Guid id);
    bool Update(T entity);
    bool Delete(T entity);
}