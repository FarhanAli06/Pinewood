
using AutoMapper;
using MediatR;
using PinewoodDMS.Application.Constants;
using PinewoodDMS.Application.Contracts.Persistence;
using PinewoodDMS.Application.DTOs.Customers;
using PinewoodDMS.Application.Features.Customers.Requests.Queries;

namespace PinewoodDMS.Application.Features.Customers.Handlers.Queries
{
    internal class GetCustomerDetailRequestHandler : IRequestHandler<GetCustomerDetailRequest, CustomerDto>
    {
        private readonly ICustomerRepository _CustomerRepository;
        private readonly IMapper _mapper;

        public GetCustomerDetailRequestHandler(ICustomerRepository CustomerRepository, IMapper mapper)
        {
            _CustomerRepository = CustomerRepository;
            _mapper = mapper;
        }
        public async Task<CustomerDto> Handle(GetCustomerDetailRequest request, CancellationToken cancellationToken)
        {
            var Customer = DummyData.GetCustomers().Where(cs => cs.Id == request.Id).SingleOrDefault(); //await _CustomerRepository.Get(request.Id);
            
            if(Customer == null)
                return new CustomerDto();

            else
                return _mapper.Map<CustomerDto>(Customer);
        }
    }
}
