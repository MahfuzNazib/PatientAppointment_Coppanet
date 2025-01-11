using Microsoft.EntityFrameworkCore;
using PatientAppointment.Domain.Entities;
using PatientAppointment.Domain.IRepository.Doctor;
using PatientAppointment.Infrastructure.Context.EFCoreDBContext;

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


        public async Task<List<Doctors>> GetAllDoctors()
        {
            return await _applicationDbContext.Doctors.ToListAsync();
        }
    }
}
