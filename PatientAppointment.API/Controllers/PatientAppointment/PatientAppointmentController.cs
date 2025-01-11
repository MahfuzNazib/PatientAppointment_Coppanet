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
    public class PatientAppointmentController : ControllerBase
    {
        private readonly IPatientAppointmentService _patientAppointmentService;

        public PatientAppointmentController(IPatientAppointmentService patientAppointmentService)
        {
            _patientAppointmentService = patientAppointmentService;
        }

        [HttpPost("appointments")]
        public async Task<IActionResult> CreatePatientAppointment([FromBody] PatientAppointmentDto patientAppointmentDto)
        {
            await _patientAppointmentService.CreatePatientAppointment(patientAppointmentDto);
            return ResponseHelper.GetActionResponse(true, "Patient Appointment Created Successfully");
        }


        [HttpGet("appointments")]
        public async Task<IActionResult> GetAllPatientAppointments()
        {
            var patientAppointments = await _patientAppointmentService.GetAllPatientAppointments();
            return ResponseHelper.GetActionResponse(true, "All Patient Appointments Data Fetched", patientAppointments);
        }


        [HttpGet("appointments/{id}")]
        public async Task<IActionResult> GetPatientAppointmentById(int id)
        {
            var patientAppointment = await _patientAppointmentService.GetPatientAppointmentById(id);
            return ResponseHelper.GetActionResponse(true, "Patient Appointment Data", patientAppointment);
        }


        [HttpPut("appointments/{id}")]
        public async Task<IActionResult> UpdatePatientAppointmentById(int id, [FromBody] PatientAppointmentDto patientAppointmentDto)
        {
            if (id != patientAppointmentDto.Id)
                return ResponseHelper.GetActionResponse(false, "Id in URL and body do not match");
            
            bool isPatientAppointmentUpdated = await _patientAppointmentService.UpdatePatientAppointmentById(id, patientAppointmentDto);
            return ResponseHelper.GetActionResponse(isPatientAppointmentUpdated, "Patient Appointment Updated");
        }


        [HttpDelete("appointments/{id}")]
        public async Task<IActionResult> DeletePatientAppointment(int id)
        {
            bool isPatientDeleted = await _patientAppointmentService.DeletePatientAppointmentById(id);
            return ResponseHelper.GetActionResponse(isPatientDeleted, "Patient Appointment Deleted");
        }
    }
}
