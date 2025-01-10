using PatientAppointment.Application.IService.PatientAppointment;
using PatientAppointment.Application.Service.PatientAppointment;
using PatientAppointment.Domain.IRepository.PatientAppointment;
using PatientAppointment.Infrastructure.Repository.PatientAppointment;

namespace PatientAppointment.API.Extensions
{
    public static class PatientAppointmentServiceExtensions
    {
        public static IServiceCollection AddPatientAppointmentServiceExtensions(this IServiceCollection services)
        {
            services.AddScoped<IPatientAppointmentService, PatientAppointmentService>();
            services.AddScoped<IPatientAppointmentsRepository, PatientAppointmentRepository>();

            return services;
        }
    }
}
