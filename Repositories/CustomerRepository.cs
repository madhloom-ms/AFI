using AFI.Data;
using AFI.Models;
using AFI.Repositories.IRepository;
using Microsoft.EntityFrameworkCore;

namespace AFI.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApiContext _context;

        public CustomerRepository(ApiContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Customer> GetByIdAsync(int id)
        {
            return await _context.Customers.FindAsync(id);
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            return await _context.Customers.ToListAsync();
        }

        public async Task<Customer> CreateAsync(Customer entity)
        {
            await _context.Customers.AddAsync(entity);
            return entity;
        }

        public async Task UpdateAsync(Customer entity)
        {
            _context.Customers.Update(entity);
        }

        public async Task DeleteAsync(Customer entity)
        {
            _context.Customers.Remove(entity);
        }

        public async Task<Customer> GetCustomerByEmailAsync(string email)
        {
            return await _context.Customers.FirstOrDefaultAsync(c => c.Email == email);
        }
    }
}
