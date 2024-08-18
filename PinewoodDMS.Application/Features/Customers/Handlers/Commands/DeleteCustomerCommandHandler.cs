using AutoMapper;
using PinewoodDMS.Application.Exceptions;
using PinewoodDMS.Application.Features.Customers.Requests.Commands;
using PinewoodDMS.Application.Contracts.Persistence;
using MediatR;
using PinewoodDMS.Application.Constants;
using System.Xml;

namespace PinewoodDMS.Application.Features.Customers.Handlers.Commands
{
    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteCustomerCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var Customer = DummyData.GetCustomers().Where(cs => cs.Id.Equals(request.Id)).SingleOrDefault();

            if (Customer == null)
                throw new NotFoundException(nameof(Customer), request.Id);
            else
                DummyData.GetCustomers().Remove(Customer);
            //await _unitOfWork.CustomerRepository.Delete(Customer);
            //await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
