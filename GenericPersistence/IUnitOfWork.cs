using GenericPersistence.Repositories;

namespace GenericPersistence;

public interface IUnitOfWork : IDisposable
{
    IGuitarRepository GuitarRepository { get; }
    ISellerRepository SellerRepository { get; }
    Task Save();
}