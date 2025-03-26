using FluentValidation;

namespace AFI.Dtos
{
    public class CustomerForCreationDto
    {
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string PolicyReferenceNumber { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Email { get; set; }
    }

    public class CustomerForCreationDtoValidator : AbstractValidator<CustomerForCreationDto>
    {
        public CustomerForCreationDtoValidator()
        {
            // Validate first name (required and must be between 3 and 50 chars)
            RuleFor(c => c.FirstName)
                .NotEmpty().WithMessage("First name is required.")
                .Length(3, 50).WithMessage("First name must be between 3 and 50 characters.");

            // Validate surname (required and must be between 3 and 50 chars)
            RuleFor(c => c.Surname)
                .NotEmpty().WithMessage("Surname is required.")
                .Length(3, 50).WithMessage("Surname must be between 3 and 50 characters.");

            // Validate policy reference number (required and must match pattern XX-999999)
            RuleFor(c => c.PolicyReferenceNumber)
                .Matches(@"^[A-Z]{2}-\d{6}$").WithMessage("Policy reference number must be in the format XX-999999.");

            // Validate the date of birth if supplied (must be at least 18 years old)
            RuleFor(c => c.DateOfBirth)
                .Must(BeAtLeast18YearsOld).When(c => c.DateOfBirth.HasValue).WithMessage("Policy holder must be at least 18 years old.");

            // Validate email if supplied (must contain at least 4 alphanumeric chars, then '@', then at least 2 alpha numeric chars, and end with '.com' or '.co.uk' ONLY)
            RuleFor(c => c.Email)
                .Matches(@"^[a-zA-Z0-9]{4,}(\.[a-zA-Z0-9]{2,})?@[a-zA-Z0-9]{2,}\.(com|co\.uk)$")
                .When(c => !string.IsNullOrEmpty(c.Email))
                .WithMessage("Email must be a valid format (e.g., example@example.com or example@example.co.uk).");

            // Ensure either the DOB or email is provided, but email is optional
            RuleFor(c => c)
                .Must(c => c.DateOfBirth.HasValue || !string.IsNullOrEmpty(c.Email))  // At least one must be provided
                .WithMessage("Either the Date of Birth or the email must be provided.");
        }


        // Custom validation to check if the policy holder is at least 18 years old
        private bool BeAtLeast18YearsOld(DateTime? dateOfBirth)
        {
            if (!dateOfBirth.HasValue)
                return false;

            var today = DateTime.Today;
            var age = today.Year - dateOfBirth.Value.Year;

            if (dateOfBirth.Value.Date > today.AddYears(-age))
                age--;

            return age >= 18;
        }
    }
}
