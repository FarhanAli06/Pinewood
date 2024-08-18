using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace PinewoodDMS.Application.DTOs.Customers.Validators
{
    public class CreateCustomerDtoValidator : AbstractValidator<CreateCustomerDto>
    {
        public CreateCustomerDtoValidator()
        {
            Include(new ICustomerDtoValidator());
        }
    }
}
