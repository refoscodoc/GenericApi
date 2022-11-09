using GenericAPI.Models;
using GenericPersistence.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace GenericPersistence.Repositories;

public class GuitarRepository : GenericRepository<GuitarModel>, IGuitarRepository
{
    private readonly GenericDbContext _context;

    public GuitarRepository(GenericDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<List<GuitarModel>> GetAllGuitars()
    {
        return await _context.Guitars.ToListAsync();
    }
}