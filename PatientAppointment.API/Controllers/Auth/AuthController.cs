using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PatientAppointment.API.Helpers;
using PatientAppointment.Application.DTO.Auth.Login;
using PatientAppointment.Application.DTO.Auth.Registration;
using PatientAppointment.Application.IService.Auth;
using PatientAppointment.Domain.Entities;

namespace PatientAppointment.API.Controllers.Auth
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IConfiguration _configuration;

        public AuthController(IAuthService authService, IConfiguration configuration)
        {
            _authService = authService;
            _configuration = configuration;
        }

        [HttpPost("Registration")]
        public async Task<IActionResult> UserRegistration([FromBody] RegistrationDto registrationDto)
        {
            await _authService.UserRegistration(registrationDto);
            return ResponseHelper.GetActionResponse(true, "User Registration Successfull");
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            (bool status, string message, Users? user) = await _authService.UserLogin(loginDto);

            if (!status)
            {
                return ResponseHelper.GetActionResponse(status, message);
            }

            // Proceed with generation JWT Token
            var tokenHelper = new JwtTokenHelper(_configuration);
            var accessToken = tokenHelper.GenerateJwtAccessToken(user);
            var refreshToken = tokenHelper.GenerateRefreshToken();
            DateTime refreshTokenExpiryTime = DateTime.UtcNow.AddDays(double.Parse(_configuration["JwtSettings:RefreshTokenDurationInDays"]));

            await _authService.StoreUserLoginTokens(refreshToken, refreshTokenExpiryTime, user.Id);

            var loggedInData = new
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken,
                UserId = user.Id,
                UserFullName = user.UserName // We can pass our custom user view model data.
            };

            return ResponseHelper.GetActionResponse(status, message, loggedInData);
        }
    }
}
