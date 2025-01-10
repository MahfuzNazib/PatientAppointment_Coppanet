using PatientAppointment.Application.IService.Doctor;
using PatientAppointment.Application.Service.Doctor;
using PatientAppointment.Domain.IRepository.Doctor;
using PatientAppointment.Infrastructure.Repository.Doctor;

namespace PatientAppointment.API.Extensions
{
    public static class DoctorServiceExtensions
    {
        public static IServiceCollection AddDoctorServiceExtensions(this IServiceCollection services)
        {
            services.AddScoped<IDoctorService, DoctorService>();
            services.AddScoped<IDoctorRepository, DoctorRepository>();

            return services;
        }
    }
}
