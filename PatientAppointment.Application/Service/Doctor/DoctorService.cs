using AutoMapper;
using PatientAppointment.Application.DTO.Doctor;
using PatientAppointment.Application.IService.Doctor;
using PatientAppointment.Domain.Entities;
using PatientAppointment.Domain.IRepository.Doctor;

namespace PatientAppointment.Application.Service.Doctor
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly IMapper _mapper;

        public DoctorService(IDoctorRepository doctorRepository, IMapper mapper)
        {
            _doctorRepository = doctorRepository;
            _mapper = mapper;
        }

        public async Task AddDoctor(DoctorDto doctor)
        {
            var newDoctor = new Doctors
            {
                Name = doctor.Name,
                ContactNo = doctor.ContactNo,
                Title = doctor.Title,
            };

            await _doctorRepository.AddDoctor(newDoctor);
        }


        public async Task<List<DoctorDto>> GetAllDoctors()
        {
            var doctors = await _doctorRepository.GetAllDoctors();
            var doctorList = doctors.Select(d => new DoctorDto
            {
                Id = d.Id,
                Name = d.Name,
                ContactNo = d.ContactNo,
                Title = d.Title,
            }).ToList();

            return doctorList;
        }
    }
}
