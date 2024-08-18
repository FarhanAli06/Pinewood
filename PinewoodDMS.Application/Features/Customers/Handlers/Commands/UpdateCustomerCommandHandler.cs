using AutoMapper;
using PinewoodDMS.Application.DTOs.Customers.Validators;
using PinewoodDMS.Application.Exceptions;
using PinewoodDMS.Application.Contracts.Persistence;
using PinewoodDMS.Domain;
using MediatR;
using PinewoodDMS.Application.Features.Customers.Requests.Commands;
using PinewoodDMS.Application.Constants;

namespace HR.LeaveManagement.Application.Features.Customers.Handlers.Commands
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateCustomerCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateCustomerDtoValidator();
            var validationResult = await validator.ValidateAsync(request.CustomerDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var customer = DummyData.GetCustomers().Where(cs => cs.Id == request.CustomerDto.Id).SingleOrDefault();

            if (customer is null)
                throw new NotFoundException(nameof(customer), request.CustomerDto.Id);

            _mapper.Map(request.CustomerDto, customer);

            //await _unitOfWork.CustomerRepository.Update(customer);
            //await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
