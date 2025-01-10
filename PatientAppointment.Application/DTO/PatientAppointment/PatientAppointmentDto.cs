namespace PatientAppointment.Application.DTO.PatientAppointment
{
    public class PatientAppointmentDto
    {
        public required string PatientName { get; set; }
        public required string PatientContact { get; set; }
        public DateTime AppointmentDate { get; set; }
        public TimeSpan AppointmentTime { get; set; }
        public bool IsPatientVisit { get; set; }
        public int DoctorId { get; set; }
    }
}
