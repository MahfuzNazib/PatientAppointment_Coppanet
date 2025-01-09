﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientAppointment.Application.DTO.Auth
{
    public class RegistrationDto
    {
        public required string FullName { get; set; }
        public required string UserName { get; set; }
        public required string Password { get; set; }
    }
}
