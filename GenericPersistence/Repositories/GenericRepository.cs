using GenericPersistence.DataAccess;

namespace GenericPersistence.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly GenericDbContext _context;

    public GenericRepository(GenericDbContext context)
    {
        _context = context;
    }

    public async Task<T> Get(Guid id)
    {
        return await _context.Set<T>().FindAsync(id);
    }

    public Task<List<T>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<T> Add(T entity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Exists(Guid id)
    {
        throw new NotImplementedException();
    }

    public bool Update(T entity)
    {
        throw new NotImplementedException();
    }

    public bool Delete(T entity)
    {
        throw new NotImplementedException();
    }
}