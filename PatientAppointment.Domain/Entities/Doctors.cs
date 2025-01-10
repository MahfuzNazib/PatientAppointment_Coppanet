using System.ComponentModel.DataAnnotations;

namespace PatientAppointment.Domain.Entities
{
    public class Doctors
    {
        [Key]
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Title { get; set; }
        public required string ContactNo { get; set; }

        public ICollection<PatientAppointments> PatientAppointments { get; set; }
    }
}
