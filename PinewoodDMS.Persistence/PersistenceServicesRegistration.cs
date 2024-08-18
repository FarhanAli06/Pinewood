using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PinewoodDMS.Application.Contracts.Persistence;
using PinewoodDMS.Persistence.Repositories;

namespace PinewoodDMS.Persistence
{
    /// <summary>
    /// Contains extension methods for configuring persistence services in the dependency injection container.
    /// </summary>
    public static partial class ServiceInitializer
    {
        /// <summary>
        /// Configures persistence-related services and registers them with the dependency injection container.
        /// </summary>
        /// <param name="services">The service collection to configure.</param>
        /// <param name="configuration">The configuration settings used for setting up services.</param>
        /// <returns>The updated service collection.</returns>
        public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Register the DbContext with the dependency injection container.
            // Configures it to use SQL Server with the connection string from the configuration.
            services.AddDbContext<PinewoodDbContext>(options =>
               options.UseSqlServer(
                   configuration.GetConnectionString("PinewoodConnectionString")));

            // Register generic repository interface and implementation with scoped lifetime.
            // This allows for dependency injection of generic repositories for any entity type.
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            // Register UnitOfWork interface and implementation with scoped lifetime.
            // This allows for dependency injection of the UnitOfWork for managing transactions.
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Register specific repository interface and implementation for Customer with scoped lifetime.
            // This allows for dependency injection of the CustomerRepository for customer-specific data operations.
            services.AddScoped<ICustomerRepository, CustomerRepository>();

            return services;
        }
    }
}
