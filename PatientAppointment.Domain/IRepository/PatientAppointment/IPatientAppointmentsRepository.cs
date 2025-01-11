using PatientAppointment.Domain.Entities;

namespace PatientAppointment.Domain.IRepository.PatientAppointment
{
    public interface IPatientAppointmentsRepository
    {
        Task CreatePatientAppointment(PatientAppointments patientAppointment);
        
        Task<List<PatientAppointments>> GetAllPatientAppointments();

        Task<PatientAppointments> GetPatientAppointmentById(int id);

        Task<bool> UpdatePatientAppointmentById(PatientAppointments patientAppointment);

        Task<bool> DeletePatientAppointmentById(int id);
    }
}
