using GenericPersistence.Repositories;

namespace GenericPersistence;

public interface IUnitOfWork : IAsyncDisposable
{
    IGuitarRepository GuitarRepository { get; }
    ISellerRepository SellerRepository { get; }
    Task Save();
}