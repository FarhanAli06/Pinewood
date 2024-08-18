using PinewoodDMS.Application.DTOs.Customers;
using PinewoodDMS.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace PinewoodDMS.Application.Features.Customers.Requests.Commands
{
    public class CreateCustomerCommand : IRequest<BaseCommandResponse>
    {
        public CreateCustomerDto CustomerDto { get; set; }

    }
}
