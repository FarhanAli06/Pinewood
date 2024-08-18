using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PinewoodDMS.Domain;

namespace PinewoodDMS.Persistence
{
    /// <summary>
    /// Represents the database context for PinewoodDMS, inheriting from AuditableDbContext.
    /// Provides access to the database and manages the lifecycle of entities.
    /// </summary>
    public class PinewoodDbContext : AuditableDbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PinewoodDbContext"/> class.
        /// </summary>
        /// <param name="options">The options to be used by the DbContext.</param>
        public PinewoodDbContext(DbContextOptions<PinewoodDbContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Configures the model and schema for the DbContext.
        /// Applies all entity configurations from the assembly of the DbContext.
        /// </summary>
        /// <param name="modelBuilder">The model builder used to configure the model.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Apply all configurations from the current assembly.
            // This method is used to set up entity configurations, relationships, and mappings.
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PinewoodDbContext).Assembly);
        }

        /// <summary>
        /// Gets or sets the DbSet for the Customer entity.
        /// This property represents the collection of customers in the database.
        /// </summary>
        public DbSet<Customer> Customers { get; set; }
    }
}
