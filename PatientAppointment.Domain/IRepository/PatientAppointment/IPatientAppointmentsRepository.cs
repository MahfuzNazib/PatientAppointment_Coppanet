using PatientAppointment.Domain.Entities;

namespace PatientAppointment.Domain.IRepository.PatientAppointment
{
    public interface IPatientAppointmentsRepository
    {
        Task CreatePatientAppointment(PatientAppointments patientAppointment);
    }
}
