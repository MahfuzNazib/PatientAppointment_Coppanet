using PatientAppointment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientAppointment.Domain.IRepository.Auth
{
    public interface IAuthRepository
    {
        Task UserRegistration(Users user);

        Task<Users?> UserLogin(string userName);

        Task StoreUserLoginTokens(string refreshToken, DateTime refreshTokenExpiryTime, int userId);
    }
}
