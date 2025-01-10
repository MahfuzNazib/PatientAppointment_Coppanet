using PatientAppointment.Application.DTO.Auth.Registration;

namespace PatientAppointment.Application.IService.Auth
{
    public interface IAuthService
    {
        Task UserRegistration(RegistrationDto registrationDto);
    }
}
