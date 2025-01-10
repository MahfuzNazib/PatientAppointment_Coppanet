using FluentValidation;

namespace PatientAppointment.Application.DTO.Doctor
{
    internal class DoctorDtoValidator : AbstractValidator<DoctorDto>
    {
        public DoctorDtoValidator() 
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Doctor name is required");

            RuleFor(x => x.ContactNo)
                .NotEmpty().WithMessage("Contact No is required")
                .Matches(@"^01\d\{9}$").WithMessage("Contact no must start with 01")
                .MaximumLength(11).WithMessage("Conact no limit 11 digit");
        }
    }
}
