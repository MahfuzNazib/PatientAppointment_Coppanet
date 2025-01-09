using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PatientAppointment.API.Helpers;
using PatientAppointment.Application.DTO.Auth;
using PatientAppointment.Application.IService.Auth;

namespace PatientAppointment.API.Controllers.Auth
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("Registration")]
        public async Task<IActionResult> UserRegistration(RegistrationDto registrationDto)
        {
            try
            {
                await _authService.UserRegistration(registrationDto);
                return ResponseHelper.GetActionResponse(true, "User Registration Successfull");
            }
            catch (Exception ex)
            {
                return ResponseHelper.GetActionResponse(false, $"User Registration Failed. Error Message : {ex.Message}");
            }
        }
    }
}
