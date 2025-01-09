
using PatientAppointment.Application.IService.Auth;
using PatientAppointment.Application.Service.Auth;
using PatientAppointment.Domain.IRepository.Auth;
using PatientAppointment.Infrastructure.Repository.Auth;

namespace PatientAppointment.API.Extensions
{
    public static class AuthenticationServiceExtensions
    {
        public static IServiceCollection AddAuthenticationServiceExtensions(this IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IAuthRepository, AuthRepository>();

            return services;
        }
    }
}
