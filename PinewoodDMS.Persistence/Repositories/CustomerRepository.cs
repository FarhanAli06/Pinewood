using PinewoodDMS.Application.Contracts.Persistence;
using PinewoodDMS.Domain;
using System;

namespace PinewoodDMS.Persistence.Repositories
{
    /// <summary>
    /// Provides the implementation for the customer repository, extending the generic repository.
    /// </summary>
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        private readonly PinewoodDbContext _dbContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerRepository"/> class.
        /// </summary>
        /// <param name="dbContext">The database context to use for data operations.</param>
        public CustomerRepository(PinewoodDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        // Additional methods specific to the Customer repository can be added here
    }
}
