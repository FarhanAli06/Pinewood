using Microsoft.EntityFrameworkCore;
using PinewoodDMS.Application.Contracts.Persistence;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PinewoodDMS.Persistence.Repositories
{
    /// <summary>
    /// A generic repository class for managing entities of type <typeparamref name="T"/> in the database.
    /// Implements the <see cref="IGenericRepository{T}"/> interface.
    /// </summary>
    /// <typeparam name="T">The type of the entity being managed. Must be a class.</typeparam>
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly PinewoodDbContext _dbContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="GenericRepository{T}"/> class.
        /// </summary>
        /// <param name="dbContext">The database context used for data operations.</param>
        public GenericRepository(PinewoodDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        /// <summary>
        /// Adds a new entity to the database context.
        /// </summary>
        /// <param name="entity">The entity to add.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the added entity.</returns>
        public async Task<T> Add(T entity)
        {
            await _dbContext.AddAsync(entity);
            return entity;
        }

        /// <summary>
        /// Removes an existing entity from the database context.
        /// </summary>
        /// <param name="entity">The entity to remove.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public async Task Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
        }

        /// <summary>
        /// Checks if an entity with the specified ID exists in the database.
        /// </summary>
        /// <param name="id">The ID of the entity to check.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a boolean indicating whether the entity exists.</returns>
        public async Task<bool> Exists(int id)
        {
            var entity = await Get(id);
            return entity != null;
        }

        /// <summary>
        /// Retrieves an entity with the specified ID from the database.
        /// </summary>
        /// <param name="id">The ID of the entity to retrieve.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the entity with the specified ID, or null if not found.</returns>
        public async Task<T> Get(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        /// <summary>
        /// Retrieves all entities of type <typeparamref name="T"/> from the database.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation. The task result contains a read-only list of all entities.</returns>
        public async Task<IReadOnlyList<T>> GetAll()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        /// <summary>
        /// Updates an existing entity in the database context.
        /// </summary>
        /// <param name="entity">The entity to update.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public async Task Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
        }
    }
}
