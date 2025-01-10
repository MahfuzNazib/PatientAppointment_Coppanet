using PatientAppointment.Application.DTO.Auth.Login;
using PatientAppointment.Application.DTO.Auth.Registration;
using PatientAppointment.Domain.Entities;

namespace PatientAppointment.Application.IService.Auth
{
    public interface IAuthService
    {
        Task UserRegistration(RegistrationDto registrationDto);

        Task<(bool status, string message, Users? user)> UserLogin(LoginDto loginDto);

        Task StoreUserLoginTokens(string refreshToken, DateTime refreshTokenExpiryTime, int userId);

    }
}
