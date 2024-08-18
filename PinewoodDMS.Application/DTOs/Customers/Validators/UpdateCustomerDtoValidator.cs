using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace PinewoodDMS.Application.DTOs.Customers.Validators
{
    public class UpdateCustomerDtoValidator : AbstractValidator<CustomerDto>
    {
        public UpdateCustomerDtoValidator()
        {
            Include(new ICustomerDtoValidator());

            RuleFor(p => p.Id).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
