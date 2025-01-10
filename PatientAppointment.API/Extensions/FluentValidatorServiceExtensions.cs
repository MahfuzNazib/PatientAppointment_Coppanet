using FluentValidation;
using FluentValidation.AspNetCore;
using PatientAppointment.Application.DTO.Auth.Login;
using PatientAppointment.Application.DTO.Auth.Registration;
using PatientAppointment.Application.DTO.Doctor;
using PatientAppointment.Application.DTO.PatientAppointment;

namespace PatientAppointment.API.Extensions
{
    public static class FluentValidatorServiceExtensions
    {
        public static IServiceCollection AddFluentValidatorServiceExtensions(this IServiceCollection services)
        {
            services.AddFluentValidationAutoValidation(config =>
            {
                config.DisableDataAnnotationsValidation = true;
            });

            services.AddValidatorsFromAssemblyContaining<RegistrationDto>();
            services.AddValidatorsFromAssemblyContaining<LoginDto>();
            services.AddValidatorsFromAssemblyContaining<DoctorDto>();
            services.AddValidatorsFromAssemblyContaining<PatientAppointmentDto>();

            return services;
        }
    }
}
