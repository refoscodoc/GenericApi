using GenericAPI.Models;
using GenericPersistence.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace GenericPersistence.Repositories;

public class SellerRepository: GenericRepository<SellerModel>, ISellerRepository
{
    private readonly GenericDbContext _context;
    public SellerRepository(GenericDbContext context) : base(context)
    {
        _context = context;
    }
    
    public async Task<List<SellerModel>> GetAllSellers()
    {
        return await _context.Sellers.ToListAsync();
    }
}