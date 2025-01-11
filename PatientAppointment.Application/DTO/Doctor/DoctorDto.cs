using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientAppointment.Application.DTO.Doctor
{
    public class DoctorDto
    {
        public int Id { get; set; }
        public required string Name {  get; set; }
        public required string ContactNo { get; set; }
        public string? Title { get; set; }
    }
}
