using PatientAppointment.Application.DTO.Doctor;
using PatientAppointment.Application.IService.Doctor;
using PatientAppointment.Domain.Entities;
using PatientAppointment.Domain.IRepository.Doctor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientAppointment.Application.Service.Doctor
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository;

        public DoctorService(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
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
    }
}
