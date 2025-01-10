using Microsoft.EntityFrameworkCore;
using PatientAppointment.Domain.Entities;
using PatientAppointment.Domain.IRepository.Auth;
using PatientAppointment.Infrastructure.Context.EFCoreDBContext;

namespace PatientAppointment.Infrastructure.Repository.Auth
{
    public class AuthRepository : IAuthRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public AuthRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task UserRegistration(Users user)
        {
            _applicationDbContext.Add(user);
            await _applicationDbContext.SaveChangesAsync();
        }

        public async Task<Users?> UserLogin(string userName)
        {
            var user = await _applicationDbContext.Users.SingleOrDefaultAsync(u => u.UserName == userName);
            return user;
        }

        public async Task StoreUserLoginTokens(string refreshToken, DateTime refreshTokenExpiryTime, int userId)
        {
            var user = await _applicationDbContext.Users.FirstOrDefaultAsync(u => u.Id == userId);

            if (user != null)
            {
                user.RefreshToken = refreshToken;
                user.RefreshTokenExpiryTime = refreshTokenExpiryTime;

                await _applicationDbContext.SaveChangesAsync();
            }
        }
    }
}
