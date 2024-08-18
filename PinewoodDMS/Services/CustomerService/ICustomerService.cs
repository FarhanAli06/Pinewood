using PinewoodDMS.DTOs.Customer.Request;
using PinewoodDMS.DTOs.Customer.Response;

namespace PinewoodDMS.Services.CustomerService
{
    public interface ICustomerService
    {
        /// <summary>
        /// Asynchronously retrieves a list of customers.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation. The task result contains a list of <see cref="CustomerResponseDto"/> objects.</returns>
        Task<List<CustomerResponseDto>> GetCustomersAsync();

        /// <summary>
        /// Asynchronously retrieves a specific customer by their ID.
        /// </summary>
        /// <param name="id">The ID of the customer to retrieve.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a <see cref="CustomerRequestDto"/> object.</returns>
        Task<CustomerRequestDto> GetCustomerByIdAsync(int? id);

        /// <summary>
        /// Asynchronously creates a new customer with the provided data.
        /// </summary>
        /// <param name="customerRequestDto">The customer data to create, represented as a <see cref="CustomerRequestDto"/> object.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task CreateCustomerAsync(CustomerRequestDto customerRequestDto);

        /// <summary>
        /// Asynchronously updates an existing customer with the provided data.
        /// </summary>
        /// <param name="customerRequestDto">The updated customer data, represented as a <see cref="CustomerRequestDto"/> object.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task UpdateCustomerAsync(CustomerRequestDto customerRequestDto);

        /// <summary>
        /// Asynchronously deletes a customer by their ID.
        /// </summary>
        /// <param name="id">The ID of the customer to delete.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task DeleteCustomerAsync(int? id);
    }

}
