using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using PinewoodDMS.Application.DTOs;
using PinewoodDMS.Application.DTOs.Customers;

namespace PinewoodDMS.Application.Features.Customers.Requests.Queries
{
    public class GetCustomerDetailRequest : IRequest<CustomerDto>
    {
        public int Id { get; set; }
    }
}
