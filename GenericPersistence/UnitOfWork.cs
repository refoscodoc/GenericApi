using System.Security.Claims;
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
    private bool _disposed;
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
        if (_httpContextAccessor.HttpContext != null)
        {
            var username = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Name)?.Value;
        }

        await _context.SaveChangesAsync();
    }
    
    public async ValueTask DisposeAsync()
    {
        await DisposeAsync(true);
 
        // Take this object off the finalization queue to prevent 
        // finalization code for this object from executing a second time.
        GC.SuppressFinalize(this);
    }

    protected virtual async ValueTask DisposeAsync(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)         
            {
                // Dispose managed resources.
                await _context.DisposeAsync();
            }

            // Dispose any unmanaged resources here...
 
            _disposed = true;
        }
    }
}