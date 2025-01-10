using Microsoft.EntityFrameworkCore;
using PatientAppointment.Domain.Entities;

namespace PatientAppointment.Infrastructure.Context.EFCoreDBContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Users> Users { get; set; }
        public DbSet<Doctors> Doctors { get; set; }
        public DbSet<PatientAppointments> PatientAppointments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PatientAppointments>()
                .HasOne(pa => pa.Doctor)
                .WithMany(d => d.PatientAppointments)
                .HasForeignKey(pa => pa.DoctorId)
                .OnDelete(DeleteBehavior.Cascade); // If Doctor Deleted, related Patient Appointments Also Deleted
        }
    }
}
