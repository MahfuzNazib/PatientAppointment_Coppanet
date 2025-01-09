using PatientAppointment.Application.DTO.Auth;

namespace PatientAppointment.Application.IService.Auth
{
    public interface IAuthService
    {
        Task UserRegistration(RegistrationDto registrationDto);
    }
}
