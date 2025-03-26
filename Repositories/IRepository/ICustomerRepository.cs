using AFI.Models;

namespace AFI.Repositories.IRepository
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Task<Customer> GetCustomerByEmailAsync(string email);
    }
}
