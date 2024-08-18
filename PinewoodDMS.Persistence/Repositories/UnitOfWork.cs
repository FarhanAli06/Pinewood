using PinewoodDMS.Application.Constants;
using PinewoodDMS.Application.Contracts.Persistence;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace PinewoodDMS.Persistence.Repositories
{
    /// <summary>
    /// Implements the Unit of Work pattern for managing transactions and repositories.
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PinewoodDbContext _context;

        private ICustomerRepository _customerRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWork"/> class.
        /// </summary>
        /// <param name="context">The database context used for data operations.</param>
        public UnitOfWork(PinewoodDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <summary>
        /// Gets the customer repository, creating it if it does not already exist.
        /// </summary>
        public ICustomerRepository CustomerRepository =>
            _customerRepository ??= new CustomerRepository(_context);

        /// <summary>
        /// Disposes of the database context and suppresses finalization.
        /// </summary>
        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Saves all changes made in the unit of work to the database.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
