using FluentValidation;

namespace PatientAppointment.Application.DTO.Auth.Registration
{
    public class RegistrationDtoValidator : AbstractValidator<RegistrationDto>
    {
        public RegistrationDtoValidator() 
        {
            RuleFor(x => x.FullName)
                .NotEmpty().WithMessage("Full Name is required")
                .MaximumLength(100).WithMessage("Full Name cannot exceed 100 characters");

            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("Username is required")
                .Matches(@"^[^\d]*$").WithMessage("Username cannot contain numbers");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required")
                .MinimumLength(6).WithMessage("Password must be at least 6 characters");
        }
    }
}
