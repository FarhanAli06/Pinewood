namespace PinewoodDMS.DTOs.Customer.Request
{
    /// <summary>
    /// Represents a customer in the system. This class contains properties and methods
    /// related to customer information, such as name, contact details, and account management.
    /// </summary>
    public class CustomerRequestDto
    {
        /// <summary>
        /// Gets or sets the unique identifier for the customer.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the first name of the customer.
        /// </summary>
        public string FirstName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the last name of the customer.
        /// </summary>
        public string LastName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the age of the customer.
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// Gets or sets the email address of the customer.
        /// </summary>
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the phone number of the customer.
        /// </summary>
        public string PhoneNumber { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the address of the customer.
        /// </summary>
        public string Address { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the date when the customer was registered.
        /// </summary>
        public DateTime CreatedDate { get; set; }
    }
}
