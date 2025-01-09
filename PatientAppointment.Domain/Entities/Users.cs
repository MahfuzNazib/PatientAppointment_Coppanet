using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientAppointment.Domain.Entities
{
    public class Users
    {
        [Key]
        public int Id { get; set; }
        public required string FullName { get; set; }
        public required string UserName { get; set; }
        public required string HashedPassword { get; set; }
        public string? Salt { get; set; }
    }
}
