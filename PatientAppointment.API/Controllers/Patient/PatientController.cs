using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PatientAppointment.API.Helpers;
using PatientAppointment.Application.DTO.PatientAppointment;
using PatientAppointment.Application.IService.PatientAppointment;

namespace PatientAppointment.API.Controllers.Patient
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientAppointmentService _patientAppointmentService;

        public PatientController(IPatientAppointmentService patientAppointmentService)
        {
            _patientAppointmentService = patientAppointmentService;
        }

        [HttpPost("CreatePatientAppointment")]
        public async Task<IActionResult> CreatePatientAppointment([FromBody] PatientAppointmentDto patientAppointmentDto)
        {
            await _patientAppointmentService.CreatePatientAppointment(patientAppointmentDto);
            return ResponseHelper.GetActionResponse(true, "Patient Appointment Created Successfully");
        }



    }
}
