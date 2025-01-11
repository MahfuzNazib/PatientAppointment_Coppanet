using PatientAppointment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientAppointment.Domain.IRepository.Doctor
{
    public interface IDoctorRepository
    {
        Task AddDoctor(Doctors doctor);

        Task<List<Doctors>> GetAllDoctors();
    }
}
