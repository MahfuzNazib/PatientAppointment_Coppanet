using FluentValidation;
using FluentValidation.AspNetCore;
using PatientAppointment.Application.DTO.Auth.Registration;

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

            return services;
        }
    }
}
