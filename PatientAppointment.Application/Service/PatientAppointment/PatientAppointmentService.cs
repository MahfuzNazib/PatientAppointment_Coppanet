using PatientAppointment.Application.DTO.Doctor;
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


        public async Task<List<PatientAppointmentDto>> GetAllPatientAppointments()
        {
            var patientAppointments = await _patientAppointmentRepository.GetAllPatientAppointments();

            var patientAppointmentDtos = patientAppointments.Select(pa => new PatientAppointmentDto
            {
                Id = pa.Id,
                PatientName = pa.PatientName,
                PatientContact = pa.PatientContact,
                AppointmentDate = pa.AppointmentDate,
                AppointmentTime = pa.AppointmentTime,
                IsPatientVisit = pa.IsPatientVisit,
                DoctorId = pa.DoctorId,
                Doctor = pa.Doctor != null
            ? new DoctorDto
            {
                Id = pa.Doctor.Id,
                Name = pa.Doctor.Name,
                Title = pa.Doctor.Title,
                ContactNo = pa.Doctor.ContactNo
            }
            : null
            }).ToList();

            return patientAppointmentDtos;
        }


        public async Task<PatientAppointmentDto> GetPatientAppointmentById(int id)
        {
            var patientAppointment = await _patientAppointmentRepository.GetPatientAppointmentById(id);

            if (patientAppointment == null)
                throw new KeyNotFoundException("Patient Appointment Not Found");

            return new PatientAppointmentDto
            {
                Id = patientAppointment.Id,
                PatientName = patientAppointment.PatientName,
                PatientContact = patientAppointment.PatientContact,
                AppointmentDate = patientAppointment.AppointmentDate,
                AppointmentTime = patientAppointment.AppointmentTime,
                IsPatientVisit = patientAppointment.IsPatientVisit,
                DoctorId = patientAppointment.DoctorId,
                Doctor = patientAppointment.Doctor != null ? new DoctorDto
                {
                    Id = patientAppointment.Doctor.Id,
                    Name = patientAppointment.Doctor.Name,
                    Title = patientAppointment.Doctor.Title,
                    ContactNo = patientAppointment.Doctor.ContactNo
                }
                : null
            };
        }


        public async Task<bool> UpdatePatientAppointmentById(int id, PatientAppointmentDto patientAppointmentDto)
        {
            var updatePatientAppointmentData = new PatientAppointments
            {
                Id = patientAppointmentDto.Id,
                PatientName = patientAppointmentDto.PatientName,
                PatientContact = patientAppointmentDto.PatientContact,
                AppointmentDate = patientAppointmentDto.AppointmentDate,
                AppointmentTime = patientAppointmentDto.AppointmentTime,
                IsPatientVisit = patientAppointmentDto.IsPatientVisit,
                DoctorId = patientAppointmentDto.DoctorId
            };

            bool isPatientAppointmentDataUpdated = await _patientAppointmentRepository.UpdatePatientAppointmentById(updatePatientAppointmentData);
            if (!isPatientAppointmentDataUpdated)
                throw new KeyNotFoundException("Patient appointment not found");

            return isPatientAppointmentDataUpdated;
        }


        public async Task<bool> DeletePatientAppointmentById(int id)
        {
            bool isPatientAppointmentDeleted = await _patientAppointmentRepository.DeletePatientAppointmentById(id);

            if (!isPatientAppointmentDeleted) 
                throw new KeyNotFoundException("Patient appointment not found to delete");

            return isPatientAppointmentDeleted;
        }
    }
}
