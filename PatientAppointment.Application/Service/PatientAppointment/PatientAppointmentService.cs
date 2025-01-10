using PatientAppointment.Application.DTO.PatientAppointment;
using PatientAppointment.Application.IService.PatientAppointment;
using PatientAppointment.Domain.Entities;
using PatientAppointment.Domain.IRepository.PatientAppointment;

namespace PatientAppointment.Application.Service.PatientAppointment
{
    public class PatientAppointmentService : IPatientAppointmentService
    {
        private readonly IPatientAppointmentsRepository _patientAppointmentRepository;

        public PatientAppointmentService(IPatientAppointmentsRepository patientAppointmentsRepository)
        {
            _patientAppointmentRepository = patientAppointmentsRepository;
        }

        public async Task CreatePatientAppointment(PatientAppointmentDto patientAppointmentDto)
        {
            var patientAppointment = new PatientAppointments
            {
                PatientName = patientAppointmentDto.PatientName,
                PatientContact = patientAppointmentDto.PatientContact,
                AppointmentDate = patientAppointmentDto.AppointmentDate,
                AppointmentTime = patientAppointmentDto.AppointmentTime,
                IsPatientVisit = false, // Initial of Patient Visit was false.
                DoctorId = patientAppointmentDto.DoctorId,
            };

            await _patientAppointmentRepository.CreatePatientAppointment(patientAppointment);
        }
    }
}
