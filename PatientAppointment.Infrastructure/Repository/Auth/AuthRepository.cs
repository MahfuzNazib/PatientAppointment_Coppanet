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
    }
}
