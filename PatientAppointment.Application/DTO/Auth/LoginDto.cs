﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientAppointment.Application.DTO.Auth
{
    public class LoginDto
    {
        public required string UserName { get; set; }
        public required string Password { get; set; }
    }
}
