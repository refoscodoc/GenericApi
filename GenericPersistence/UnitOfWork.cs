using System.Xml.Linq;
using GenericPersistence.DataAccess;
using GenericPersistence.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Storage;

namespace GenericPersistence;

public class UnitOfWork : IUnitOfWork
{
    private readonly GenericDbContext _context;
    private readonly IHttpContextAccessor _httpContextAccessor;
    // private  IDbContextTransaction _dbContextTransaction;

    private IGuitarRepository _guitarRepository;
    private ISellerRepository _sellerRepository;

    public UnitOfWork(GenericDbContext context, 
        IHttpContextAccessor httpContextAccessor 
        // IDbContextTransaction dbContextTransaction
        )
    {
        _context = context;
        _httpContextAccessor = httpContextAccessor;
        // _dbContextTransaction = dbContextTransaction;
    }

    public IGuitarRepository GuitarRepository =>
        _guitarRepository ??= new GuitarRepository(_context);

    public ISellerRepository SellerRepository =>
        _sellerRepository ??= new SellerRepository(_context);

    public async Task Save()
    {
        // var username = _httpContextAccessor.HttpContext.User.FindFirst(CustomClaimTypes.Uid)?.Value;
        // await _context.SaveChangesAsync(username);
        await _context.SaveChangesAsync();
    }
    
    public void Dispose()
    {
        _context.Dispose();
        // if (_dbContextTransaction is not null)
        // {
        //     _dbContextTransaction.Dispose();
        // }
        GC.SuppressFinalize(this);
    }
}