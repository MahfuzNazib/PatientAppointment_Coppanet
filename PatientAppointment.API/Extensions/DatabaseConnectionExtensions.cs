using Microsoft.EntityFrameworkCore;
using PatientAppointment.Infrastructure.Context.EFCoreDBContext;

namespace PatientAppointment.API.Extensions
{
    public static class DatabaseConnectionExtensions
    {
        public static IServiceCollection AddDatabaseConnectionExtensions(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
            );

            return services;
        }
    }
}
