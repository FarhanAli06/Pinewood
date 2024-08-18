using PinewoodDMS.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PinewoodDMS.Persistence.Configurations.Entities
{
    /// <summary>
    /// Configures the entity type for <see cref="Customer"/> using Entity Framework Core.
    /// </summary>
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        /// <summary>
        /// Configures the <see cref="Customer"/> entity with Entity Framework Core.
        /// </summary>
        /// <param name="builder">The builder used to configure the <see cref="Customer"/> entity.</param>
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            // Configure the properties and relationships of the Customer entity here

            // Example:
            // builder.HasKey(c => c.Id); // Set the primary key
            // builder.Property(c => c.FirstName).IsRequired().HasMaxLength(50); // Configure the FirstName property
            // builder.Property(c => c.Email).HasMaxLength(100); // Configure the Email property
            // builder.HasIndex(c => c.Email).IsUnique(); // Ensure that the Email property is unique

            // Further configuration can be added as needed based on requirements
        }
    }
}
