using System;

namespace PinewoodDMS.Domain.Common
{
    /// <summary>
    /// Represents the base class for domain entities that includes common properties.
    /// </summary>
    public abstract class BaseDomainEntity
    {
        /// <summary>
        /// Gets or sets the unique identifier for the entity.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the entity was created.
        /// </summary>
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// Gets or sets the username or identifier of the user who created the entity.
        /// </summary>
        public string CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the entity was last modified.
        /// </summary>
        public DateTime LastModifiedDate { get; set; }

        /// <summary>
        /// Gets or sets the username or identifier of the user who last modified the entity.
        /// </summary>
        public string LastModifiedBy { get; set; }
    }
}
