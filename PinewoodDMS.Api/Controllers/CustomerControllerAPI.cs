using MediatR;
using Microsoft.AspNetCore.Mvc;
using PinewoodDMS.Application.DTOs.Customers;
using PinewoodDMS.Application.Features.Customers.Requests.Commands;
using PinewoodDMS.Application.Features.Customers.Requests.Queries;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PinewoodDMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerControllerAPI : ControllerBase
    {
        private readonly IMediator _mediator;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerControllerAPI"/> class.
        /// </summary>
        /// <param name="mediator">An instance of <see cref="IMediator"/> used to send commands and queries.</param>
        public CustomerControllerAPI(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        /// <summary>
        /// Retrieves a list of customers.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation. The task result contains an action result with a list of <see cref="CustomerDto"/> objects.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(List<CustomerDto>), 200)]
        public async Task<ActionResult<List<CustomerDto>>> Get()
        {
            try
            {
                // Send a request to retrieve the list of customers
                var customers = await _mediator.Send(new GetCustomerListRequest());

                // Return the list of customers with a 200 OK status
                return Ok(customers);
            }
            catch (Exception ex)
            {
                // Log the exception (implement logging as needed)
                // _logger.LogError(ex, "An error occurred while retrieving the customer list.");
                // Return a 500 Internal Server Error status code
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        /// <summary>
        /// Retrieves a specific customer by their ID.
        /// </summary>
        /// <param name="id">The ID of the customer to retrieve.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains an action result with the customer details if found, or a 404 Not Found if not found.</returns>
        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(CustomerDto), 200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<CustomerDto>> Get(int id)
        {
            try
            {
                // Send a request to retrieve the details of a specific customer
                var customer = await _mediator.Send(new GetCustomerDetailRequest { Id = id });

                // Check if the customer was found
                if (customer == null)
                {
                    // Return a 404 Not Found response if the customer does not exist
                    return NotFound();
                }

                // Return the customer details with a 200 OK status
                return Ok(customer);
            }
            catch (Exception ex)
            {
                // Log the exception (implement logging as needed)
                // _logger.LogError(ex, "An error occurred while retrieving the customer details.");
                // Return a 500 Internal Server Error status code
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        /// <summary>
        /// Creates a new customer with the provided data.
        /// </summary>
        /// <param name="customer">The customer data to create, represented as a <see cref="CreateCustomerDto"/> object.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains an action result with the created customer details and a 201 Created status if successful, or a 400 Bad Request if the input is invalid.</returns>
        [HttpPost]
        [ProducesResponseType(typeof(CustomerDto), 201)]
        [ProducesResponseType(typeof(CustomerDto), 400)]
        public async Task<ActionResult<CustomerDto>> Post([FromBody] CreateCustomerDto customer)
        {
            try
            {
                // Check if the model state is valid
                if (!ModelState.IsValid)
                {
                    // Return a 400 Bad Request response if the model state is invalid
                    return BadRequest(ModelState);
                }

                // Send a command to create a new customer
                var response = await _mediator.Send(new CreateCustomerCommand { CustomerDto = customer });

                // Check if the creation was successful
                if (response.Success)
                {
                    // Return a 201 Created response with the location of the new resource
                    return CreatedAtAction(nameof(Get), new { id = response.Id }, response);
                }

                // Return a 400 Bad Request response if the creation failed
                return BadRequest(response);
            }
            catch (Exception ex)
            {
                // Log the exception (implement logging as needed)
                // _logger.LogError(ex, "An error occurred while creating the customer.");
                // Return a 500 Internal Server Error status code
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        /// <summary>
        /// Updates an existing customer with the provided data.
        /// </summary>
        /// <param name="id">The ID of the customer to update.</param>
        /// <param name="customer">The updated customer data, represented as a <see cref="CustomerDto"/> object.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains an action result with a 204 No Content status if successful, or a 400 Bad Request if the input is invalid.</returns>
        [HttpPut("{id:int}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Put(int id, [FromBody] CustomerDto customer)
        {
            try
            {
                // Check if the model state is valid
                if (!ModelState.IsValid)
                {
                    // Return a 400 Bad Request response if the model state is invalid
                    return BadRequest(ModelState);
                }

                // Send a command to update the customer details
                var command = new UpdateCustomerCommand { CustomerDto = customer };
                await _mediator.Send(command);

                // Return a 204 No Content response indicating that the update was successful
                return NoContent();
            }
            catch (Exception ex)
            {
                // Log the exception (implement logging as needed)
                // _logger.LogError(ex, "An error occurred while updating the customer.");
                // Return a 500 Internal Server Error status code
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        /// <summary>
        /// Deletes a customer by their ID.
        /// </summary>
        /// <param name="id">The ID of the customer to delete.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains an action result with a 204 No Content status indicating successful deletion.</returns>
        [HttpDelete("{id:int}")]
        [ProducesResponseType(204)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                // Send a command to delete the customer
                var command = new DeleteCustomerCommand { Id = id };
                await _mediator.Send(command);

                // Return a 204 No Content response indicating that the deletion was successful
                return NoContent();
            }
            catch (Exception ex)
            {
                // Log the exception (implement logging as needed)
                // _logger.LogError(ex, "An error occurred while deleting the customer.");
                // Return a 500 Internal Server Error status code
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
    }
}
