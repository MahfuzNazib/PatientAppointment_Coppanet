using Microsoft.EntityFrameworkCore;
using PatientAppointment.Domain.Entities;
using PatientAppointment.Domain.IRepository.PatientAppointment;
using PatientAppointment.Infrastructure.Context.EFCoreDBContext;

namespace PatientAppointment.Infrastructure.Repository.PatientAppointment
{
    public class PatientAppointmentRepository : IPatientAppointmentsRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public PatientAppointmentRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task CreatePatientAppointment(PatientAppointments patientAppointment)
        {
            _applicationDbContext.PatientAppointments.Add(patientAppointment);
            await _applicationDbContext.SaveChangesAsync();
        }


        public async Task<List<PatientAppointments>> GetAllPatientAppointments()
        {
            return await _applicationDbContext.PatientAppointments
                .Include(pa => pa.Doctor)
                .ToListAsync();
        }


        public async Task<PatientAppointments> GetPatientAppointmentById(int id)
        {
            return await _applicationDbContext.PatientAppointments
                .Include(pa => pa.Doctor)
                .FirstOrDefaultAsync(pa => pa.Id == id);
        }


        public async Task<bool> UpdatePatientAppointmentById(PatientAppointments patientAppointment)
        {
            var existingPatientAppointment = await _applicationDbContext.PatientAppointments
                .FirstOrDefaultAsync(pa => pa.Id ==  patientAppointment.Id);

            if (existingPatientAppointment == null)
                return false;

            // Update Fields Value
            existingPatientAppointment.PatientName = patientAppointment.PatientName;
            existingPatientAppointment.PatientContact = patientAppointment.PatientContact;
            existingPatientAppointment.AppointmentDate = patientAppointment.AppointmentDate;
            existingPatientAppointment.AppointmentTime = patientAppointment.AppointmentTime;
            existingPatientAppointment.IsPatientVisit = patientAppointment.IsPatientVisit;
            existingPatientAppointment.DoctorId = patientAppointment.DoctorId;

            await _applicationDbContext.SaveChangesAsync();
            return true;
        }


        public async Task<bool> DeletePatientAppointmentById(int id)
        {
            var patientAppointment = await _applicationDbContext.PatientAppointments
                .FirstOrDefaultAsync(pa => pa.Id == id);

            if (patientAppointment == null)
                return false; 

            _applicationDbContext.PatientAppointments.Remove(patientAppointment); 
            await _applicationDbContext.SaveChangesAsync(); 
            return true; 
        }
    }
}
