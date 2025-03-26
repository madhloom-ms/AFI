using AFI.Data;
using AFI.Repositories.IRepository;
using Microsoft.EntityFrameworkCore.Storage;

namespace AFI.UoW
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ApiContext _context;
        private readonly ILogger<UnitOfWork> _logger;
        private readonly ICustomerRepository _customers;

        public ICustomerRepository Customers => _customers;

        public UnitOfWork(ApiContext context, ICustomerRepository customerRepository, ILogger<UnitOfWork> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _customers = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<bool> SaveAllAsync()
        {
            try
            {
                return await CompleteAsync() > 0;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while saving changes.");
                return false;
            }
        }

        public async Task<int> CompleteAsync()
        {
            try
            {
                return await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while completing transaction.");
                throw; 
            }
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            try
            {
                return await _context.Database.BeginTransactionAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while starting transaction.");
                throw;
            }
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
