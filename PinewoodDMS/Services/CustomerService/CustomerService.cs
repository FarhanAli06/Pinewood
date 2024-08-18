using Newtonsoft.Json;
using System.Net.Http;
using PinewoodDMS.DTOs.Customer.Request;
using System.Text;
using PinewoodDMS.DTOs.Customer.Response;
using Microsoft.Extensions.Configuration;
using PinewoodDMS.Constants;

namespace PinewoodDMS.Services.CustomerService
{
    public class CustomerService : ICustomerService
    {
        private readonly IConfiguration _configuration;

        private readonly HttpClient _httpClient;

        // Constructor to initialize HttpClient for making HTTP requests
        public CustomerService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _configuration = configuration;
        }

        /// <summary>
        /// Retrieves a list of customers from the API.
        /// </summary>
        /// <returns>A list of <see cref="CustomerResponseDto"/>.</returns>
        /// <exception cref="HttpRequestException">Thrown when the API call fails.</exception>
        public async Task<List<CustomerResponseDto>> GetCustomersAsync()
        {
            // Define the endpoint URL for getting customer data
            var endpoint = _configuration.GetValue<string>(AppConstants.ApiUrl);

            // Send a GET request to the API
            var response = await _httpClient.GetAsync(endpoint);

            // Check if the response is successful
            if (response.IsSuccessStatusCode)
            {
                // Read and deserialize the JSON response into a list of CustomerResponseDto
                var jsonResponse = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<CustomerResponseDto>>(jsonResponse);
            }
            else
            {
                // Throw an exception if the response status is not successful
                throw new HttpRequestException($"Failed to fetch data from {endpoint}, Status code: {response.StatusCode}");
            }
        }

        /// <summary>
        /// Retrieves a specific customer by ID from the API.
        /// </summary>
        /// <param name="id">The ID of the customer to retrieve.</param>
        /// <returns>A <see cref="CustomerRequestDto"/> representing the customer.</returns>
        /// <exception cref="HttpRequestException">Thrown when the API call fails.</exception>
        public async Task<CustomerRequestDto> GetCustomerByIdAsync(int? id)
        {
            // Define the endpoint URL for getting a specific customer
            var endpoint = $"{_configuration.GetValue<string>(AppConstants.ApiUrl)}/{id}";

            // Send a GET request to the API
            var response = await _httpClient.GetAsync(endpoint);

            // Initialize a default customer object
            var customer = new CustomerRequestDto();

            // Check if the response is successful
            if (response.IsSuccessStatusCode)
            {
                // Read and deserialize the JSON response into a CustomerRequestDto
                var jsonResponse = await response.Content.ReadAsStringAsync();
                customer = JsonConvert.DeserializeObject<CustomerRequestDto>(jsonResponse);
            }
            else
            {
                // Throw an exception if the response status is not successful
                throw new HttpRequestException($"Failed to fetch data from {endpoint}, Status code: {response.StatusCode}");
            }

            return customer;
        }

        /// <summary>
        /// Creates a new customer by sending data to the API.
        /// </summary>
        /// <param name="customer">The customer data to create.</param>
        /// <exception cref="HttpRequestException">Thrown when the API call fails.</exception>
        public async Task CreateCustomerAsync(CustomerRequestDto customer)
        {
            // Define the endpoint URL for creating a new customer           
            var endpoint = _configuration.GetValue<string>(AppConstants.ApiUrl);

            // Serialize the customer data to JSON
            var jsonContent = new StringContent(JsonConvert.SerializeObject(customer), Encoding.UTF8, "application/json");

            // Send a POST request to the API
            var response = await _httpClient.PostAsync(endpoint, jsonContent);

            // Check if the response is not successful
            if (!response.IsSuccessStatusCode)
            {
                // Throw an exception if the response status is not successful
                throw new HttpRequestException($"Failed to create data at {endpoint}, Status code: {response.StatusCode}");
            }
        }

        /// <summary>
        /// Updates an existing customer by sending data to the API.
        /// </summary>
        /// <param name="customerRequestDto">The customer data to update.</param>
        /// <exception cref="HttpRequestException">Thrown when the API call fails.</exception>
        public async Task UpdateCustomerAsync(CustomerRequestDto customerRequestDto)
        {
            // Define the endpoint URL for updating an existing customer
            var endpoint = $"{_configuration.GetValue<string>(AppConstants.ApiUrl)}/{customerRequestDto.Id}";

            // Serialize the customer data to JSON
            var jsonContent = new StringContent(JsonConvert.SerializeObject(customerRequestDto), Encoding.UTF8, "application/json");

            // Send a PUT request to the API
            var response = await _httpClient.PutAsync(endpoint, jsonContent);

            // Check if the response is not successful
            if (!response.IsSuccessStatusCode)
            {
                // Throw an exception if the response status is not successful
                throw new HttpRequestException($"Failed to update data at {endpoint}, Status code: {response.StatusCode}");
            }
        }

        /// <summary>
        /// Deletes a customer by ID using the API.
        /// </summary>
        /// <param name="id">The ID of the customer to delete.</param>
        /// <exception cref="HttpRequestException">Thrown when the API call fails.</exception>
        public async Task DeleteCustomerAsync(int? id)
        {
            // Define the endpoint URL for deleting a customer
            var endpoint = $"{_configuration.GetValue<string>(AppConstants.ApiUrl)}/{id}";

            // Send a DELETE request to the API
            var response = await _httpClient.DeleteAsync(endpoint);

            // Check if the response is not successful
            if (!response.IsSuccessStatusCode)
            {
                // Throw an exception if the response status is not successful
                throw new HttpRequestException($"Failed to delete data at {endpoint}, Status code: {response.StatusCode}");
            }
        }
    }
}
