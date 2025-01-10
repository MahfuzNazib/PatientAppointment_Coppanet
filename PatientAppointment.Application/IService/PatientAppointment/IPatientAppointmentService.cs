using PatientAppointment.Application.DTO.PatientAppointment;

namespace PatientAppointment.Application.IService.PatientAppointment
{
    public interface IPatientAppointmentService
    {
        Task CreatePatientAppointment(PatientAppointmentDto patientAppointmentDto);
    }
}
