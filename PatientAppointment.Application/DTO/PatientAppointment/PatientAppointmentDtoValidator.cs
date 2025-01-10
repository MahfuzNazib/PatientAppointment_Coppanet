using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientAppointment.Application.DTO.PatientAppointment
{
    public class PatientAppointmentDtoValidator : AbstractValidator<PatientAppointmentDto>
    {
        public PatientAppointmentDtoValidator() 
        {
            RuleFor(x => x.PatientName)
                .NotEmpty().WithMessage("Patient name is required");

            RuleFor(x => x.PatientContact)
                .NotEmpty().WithMessage("Patient contact is required");

            RuleFor(x => x.AppointmentDate)
                .NotEmpty().WithMessage("Please Select Appointment Date")
                .GreaterThan(DateTime.Now.Date).WithMessage("Appointment date must be grater than today");

            RuleFor(x => x.AppointmentTime)
                .Must(IsValidAppointmentTime)
                .WithMessage("Appointment time must be between 08:00 AM and 08:00 PM.");

        }


        private bool IsValidAppointmentTime(TimeSpan time)
        {
            var startTime = new TimeSpan(8, 0, 0);
            var endTime = new TimeSpan(20, 0, 0);

            return time >= startTime && time <= endTime;
        }
    }
}
