using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using PinewoodDMS.Application.Constants;
using PinewoodDMS.Application.Contracts.Persistence;
using PinewoodDMS.Application.DTOs;
using PinewoodDMS.Application.DTOs.Customers;
using PinewoodDMS.Application.Features.Customers.Requests.Queries;

namespace PinewoodDMS.Application.Features.Customers.Handlers.Queries
{
    public class GetCustomerListRequestHandler : IRequestHandler<GetCustomerListRequest, List<CustomerDto>>
    {
        private readonly ICustomerRepository _CustomerRepository;
        private readonly IMapper _mapper;

        public GetCustomerListRequestHandler(ICustomerRepository CustomerRepository, IMapper mapper)
        {
            _CustomerRepository = CustomerRepository;
            _mapper = mapper;
        }
        public async Task<List<CustomerDto>> Handle(GetCustomerListRequest request, CancellationToken cancellationToken)
        {
            var Customers = DummyData.GetCustomers();
            return _mapper.Map<List<CustomerDto>>(Customers);
        }
    }
}
