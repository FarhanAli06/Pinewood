using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PinewoodDMS.DTOs.Customer.Request;
using PinewoodDMS.Services.CustomerService;
using System;
using System.Threading.Tasks;

namespace PinewoodDMS.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;
        private readonly ILogger<CustomerController> _logger;

        // Constructor for dependency injection of the customer service and logger
        public CustomerController(ICustomerService customerService, ILogger<CustomerController> logger)
        {
            _customerService = customerService ?? throw new ArgumentNullException(nameof(customerService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        // GET: /Customer
        // Retrieves and displays a list of customers.
        public async Task<IActionResult> Index()
        {
            try
            {
                var customers = await _customerService.GetCustomersAsync();
                return View(customers);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving the customer list.");
                return View("Error"); // Consider a more specific error view or message
            }
        }

        // GET: /Customer/Create
        // Displays a form for creating a new customer.
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Customer/Create
        // Handles form submission to create a new customer.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Email,Age,PhoneNumber,Address")] CustomerRequestDto customerRequestDto)
        {
            if (!ModelState.IsValid)
            {
                return View(customerRequestDto); // Return the view with validation errors
            }

            try
            {
                await _customerService.CreateCustomerAsync(customerRequestDto);
                return RedirectToAction(nameof(Index)); // Redirect to the Index action upon success
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating a new customer.");
                return View("Error"); // Consider returning a view with specific error details
            }
        }

        // GET: /Customer/Details/5
        // Retrieves and displays details of a specific customer by ID.
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var customerRequestDto = await _customerService.GetCustomerByIdAsync(id);
                if (customerRequestDto == null)
                {
                    return NotFound(); // Return a 404 response if the customer is not found
                }
                return View(customerRequestDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving customer details.");
                return View("Error");
            }
        }

        // GET: /Customer/Edit/5
        // Retrieves and displays a form for editing a specific customer by ID.
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var customerRequestDto = await _customerService.GetCustomerByIdAsync(id);
                if (customerRequestDto == null)
                {
                    return NotFound(); // Return a 404 response if the customer is not found
                }
                return View(customerRequestDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving customer for editing.");
                return View("Error");
            }
        }

        // POST: /Customer/Edit/5
        // Handles form submission to update a customer's details.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Email,Age,PhoneNumber,Address")] CustomerRequestDto customerRequestDto)
        {
            if (id != customerRequestDto.Id)
            {
                return NotFound(); // Return a 404 response if the ID mismatch occurs
            }

            if (!ModelState.IsValid)
            {
                return View(customerRequestDto); // Return the view with validation errors
            }

            try
            {
                await _customerService.UpdateCustomerAsync(customerRequestDto);
                return RedirectToAction(nameof(Index)); // Redirect to the Index action upon success
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating the customer.");
                return View("Error");
            }
        }

        // GET: /Customer/Delete/5
        // Retrieves and displays a form for deleting a specific customer by ID.
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var customerRequestDto = await _customerService.GetCustomerByIdAsync(id);
                if (customerRequestDto == null)
                {
                    return NotFound(); // Return a 404 response if the customer is not found
                }
                return View(customerRequestDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving customer for deletion.");
                return View("Error");
            }
        }

        // POST: /Customer/Delete/5
        // Handles form submission to delete a customer.
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var customerRequestDto = await _customerService.GetCustomerByIdAsync(id);
                if (customerRequestDto != null)
                {
                    await _customerService.DeleteCustomerAsync(id);
                }

                return RedirectToAction(nameof(Index)); // Redirect to the Index action upon success
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting the customer.");
                return View("Error");
            }
        }
    }
}
