using AutoMapper;
using PinewoodDMS.Application.DTOs.Customers.Validators;
using PinewoodDMS.Application.Exceptions;
using PinewoodDMS.Application.Features.Customers.Requests.Commands;
using PinewoodDMS.Application.Contracts.Persistence;
using PinewoodDMS.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using PinewoodDMS.Application.Responses;
using System.Linq;
using PinewoodDMS.Application.Constants;

namespace HR.LeaveManagement.Application.Features.Customers.Handlers.Commands
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateCustomerCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateCustomerDtoValidator();
            var validationResult = await validator.ValidateAsync(request.CustomerDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var customers = DummyData.GetCustomers();
                //var customer = _mapper.Map<Customer>(request.CustomerDto);
                //customer = await _unitOfWork.CustomerRepository.Add(customer);
                //await _unitOfWork.Save();

                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = request.CustomerDto.Id;
            }

            return response;
        }
    }
}
