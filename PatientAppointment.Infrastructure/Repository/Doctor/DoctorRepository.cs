using PatientAppointment.Domain.Entities;
using PatientAppointment.Domain.IRepository.Doctor;
using PatientAppointment.Infrastructure.Context.EFCoreDBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientAppointment.Infrastructure.Repository.Doctor
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public DoctorRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task AddDoctor(Doctors doctor)
        {
            _applicationDbContext.Doctors.Add(doctor);
            await _applicationDbContext.SaveChangesAsync();
        }
    }
}
