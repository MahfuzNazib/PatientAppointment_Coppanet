using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PatientAppointment.API.Helpers;
using PatientAppointment.Application.DTO.Doctor;
using PatientAppointment.Application.IService.Doctor;

namespace PatientAppointment.API.Controllers.Doctor
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService _doctorService;

        public DoctorController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        [HttpPost("AddDoctor")]
        public async Task<IActionResult> AddDoctor([FromBody] DoctorDto doctorDto)
        {
            await _doctorService.AddDoctor(doctorDto);
            return ResponseHelper.GetActionResponse(true, "Doctor Create Successfully");
        }


        [HttpGet("Doctors")]
        public async Task<IActionResult> GetAllDoctors()
        {
            var doctors = await _doctorService.GetAllDoctors();
            return ResponseHelper.GetActionResponse(true, "Doctor Data Fetched", doctors);
        }

    }
}
