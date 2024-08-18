using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace PinewoodDMS.Application.DTOs.Customers.Validators
{
    public class ICustomerDtoValidator : AbstractValidator<ICustomerDto>
    {
        public ICustomerDtoValidator()
        {
            //First Name validation
            RuleFor(customer => customer.FirstName)
                .NotEmpty().WithMessage("First Name is required.")
                .MaximumLength(100).WithMessage("First Name must be 100 characters or less.")
                .Matches(@"^[a-zA-Z\s'-]+$").WithMessage("First Name can only contain letters, spaces, hyphens, and apostrophes.");

            // Last Name validation
            RuleFor(customer => customer.LastName)
               .NotEmpty().WithMessage("Last Name is required.")
                .MaximumLength(100).WithMessage("Last Name must be 100 characters or less.")
                .Matches(@"^[a-zA-Z\s'-]+$").WithMessage("Last Name can only contain letters, spaces, hyphens, and apostrophes.");

            // Email validation
            RuleFor(customer => customer.Email)
                .NotEmpty().WithMessage("Email is required.")
                .MaximumLength(100).WithMessage("Email must be 100 characters or less.")
                .EmailAddress().WithMessage("Please provide a valid email address.");

            // Phone validation
            RuleFor(customer => customer.PhoneNumber)
                .NotEmpty().WithMessage("Phone number is required.")
                .Matches(@"^\+?[0-9\s\-\(\)]{7,15}$")
                .WithMessage("Phone number must be valid and contain 7 to 15 digits, optional '+' at the beginning, and can include spaces, dashes, or parentheses.")
                .MaximumLength(15).WithMessage("Phone number must be 15 characters or less.");

            // Age validation
            RuleFor(customer => customer.Age)
                .InclusiveBetween(1, 100).WithMessage("Age must be between 1 and 100.");

            // Address validation
            RuleFor(customer => customer.Address)
                .NotEmpty().WithMessage("Address is required.")
                .MaximumLength(200).WithMessage("Address must be 200 characters or less.")
                .Matches(@"^[a-zA-Z0-9\s,.'-]{3,}$")
                .WithMessage("Address should contain only letters, numbers, spaces, commas, periods, apostrophes, and hyphens.");

        }
    }
}
