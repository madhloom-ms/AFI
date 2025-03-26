using AFI.Repositories.IRepository;
using Microsoft.EntityFrameworkCore.Storage;

namespace AFI.UoW
{
    public interface IUnitOfWork : IDisposable
    {
        ICustomerRepository Customers { get; }

        Task<bool> SaveAllAsync();
        Task<int> CompleteAsync();
        Task<IDbContextTransaction> BeginTransactionAsync();
    }
}
