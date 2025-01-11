using PatientAppointment.Application.DTO.PatientAppointment;

namespace PatientAppointment.Application.IService.PatientAppointment
{
    public interface IPatientAppointmentService
    {
        Task CreatePatientAppointment(PatientAppointmentDto patientAppointmentDto);

        Task<List<PatientAppointmentDto>> GetAllPatientAppointments();

        Task<PatientAppointmentDto> GetPatientAppointmentById(int id);

        Task<bool> UpdatePatientAppointmentById(int id, PatientAppointmentDto patientAppointmentDto);

        Task<bool> DeletePatientAppointmentById(int id);
    }
}
