using PatientAppointment.Application.DTO.Doctor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientAppointment.Application.IService.Doctor
{
    public interface IDoctorService
    {
        Task AddDoctor(DoctorDto doctor);

        Task<List<DoctorDto>> GetAllDoctors();
    }
}
