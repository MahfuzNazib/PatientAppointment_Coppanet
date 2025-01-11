using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientAppointment.Domain.Entities
{
    public class PatientAppointments
    {
        [Key]
        public int Id { get; set; }
        public string PatientName { get; set; }
        public string PatientContact {  get; set; }
        public DateTime AppointmentDate { get; set; }
        public TimeSpan AppointmentTime { get; set; }
        public bool IsPatientVisit { get; set; } = false;
        public int DoctorId { get; set; } // Doctor Entity FK

        public Doctors Doctor {  get; set; }
    }
}
