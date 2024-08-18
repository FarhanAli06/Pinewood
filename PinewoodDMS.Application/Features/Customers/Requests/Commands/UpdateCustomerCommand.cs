using PinewoodDMS.Application.DTOs.Customers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace PinewoodDMS.Application.Features.Customers.Requests.Commands
{
    public class UpdateCustomerCommand : IRequest<Unit>
    {
        public CustomerDto CustomerDto { get; set; }

    }
}
