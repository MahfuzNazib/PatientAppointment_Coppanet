using PatientAppointment.Application.DTO.Auth.Login;
using PatientAppointment.Application.DTO.Auth.Registration;
using PatientAppointment.Application.IService.Auth;
using PatientAppointment.Domain.Entities;
using PatientAppointment.Domain.IRepository.Auth;
using System.Security.Cryptography;
using System.Text;


namespace PatientAppointment.Application.Service.Auth
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;

        public AuthService(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        #region User Registration with Password Hashing
        public async Task UserRegistration(RegistrationDto registrationDto)
        {
            var (hashedPassword, salt) = await PasswordHashing(registrationDto.Password);

            var user = new Users
            {
                FullName = registrationDto.FullName,
                UserName = registrationDto.UserName,
                HashedPassword = hashedPassword,
                Salt = salt
            };
            await _authRepository.UserRegistration(user);
        }

        private async Task<(string hashedPassword, string salt)> PasswordHashing(string plainPassword)
        {
            string salt = await CreateSalt(16);

            string hashedPassword = await Task.Run(() =>
            {
                using (SHA256 sHA256 = SHA256.Create())
                {
                    string saltedInput = plainPassword + salt;
                    byte[] bytes = sHA256.ComputeHash(Encoding.UTF8.GetBytes(saltedInput));
                    return Convert.ToBase64String(bytes);
                }
            });

            return (hashedPassword, salt);
        }

        private async Task<string> CreateSalt(int size)
        {
            return await Task.Run(() =>
            {
                byte[] saltBytes = new byte[size];
                RandomNumberGenerator.Fill(saltBytes);
                return Convert.ToBase64String(saltBytes);
            });
        }
        #endregion

        public async Task<(bool status, string message, Users? user)> UserLogin(LoginDto loginDto)
        {
            var user = await _authRepository.UserLogin(loginDto.UserName);

            if (user == null)
                return (false, $"User not found for {loginDto.UserName}", null);

            bool isPasswordValid = await VerifyHashedPassword(loginDto.Password, user.HashedPassword, user.Salt);
            if (!isPasswordValid)
                return (false, "Invalid Credentials", null);
            return (true, "Successfully Logged In", user);
        
        }

        public async Task<bool> VerifyHashedPassword(string inputPassword, string storedHashedPassword, string storeSaltValue)
        {
            return await Task.Run(() =>
            {
                using (SHA256 sHA256 = SHA256.Create())
                {
                    string saltedInput = inputPassword + storeSaltValue;
                    byte[] inputHashBytes = sHA256.ComputeHash(Encoding.UTF8.GetBytes(saltedInput));
                    string inputHashedPassword = Convert.ToBase64String(inputHashBytes);

                    return inputHashedPassword == storedHashedPassword;
                }
            });
        }


        public async Task StoreUserLoginTokens(string refreshToken, DateTime refreshTokenExpiryTime, int userId)
        {
            await _authRepository.StoreUserLoginTokens(refreshToken, refreshTokenExpiryTime, userId);
        }
    }
}
