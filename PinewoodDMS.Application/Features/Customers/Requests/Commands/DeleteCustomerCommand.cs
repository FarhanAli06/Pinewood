using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace PinewoodDMS.Application.Features.Customers.Requests.Commands
{
    public class DeleteCustomerCommand : IRequest
    {
        public int Id { get; set; }
    }
}
