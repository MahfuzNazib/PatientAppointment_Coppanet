using PatientAppointment.Domain.Entities;
using PatientAppointment.Domain.IRepository.PatientAppointment;
using PatientAppointment.Infrastructure.Context.EFCoreDBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
