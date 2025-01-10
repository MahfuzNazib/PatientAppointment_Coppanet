
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using PatientAppointment.API.Extensions;
using System.Text;

namespace PatientAppointment.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            #region DI Extensions Register
            builder.Services.AddDatabaseConnectionExtensions(builder.Configuration);
            builder.Services.AddAuthenticationServiceExtensions();
            builder.Services.AddFluentValidatorServiceExtensions();
            builder.Services.AddJWTTokenAuthenticationExtension(builder.Configuration);
            #endregion

            
            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
