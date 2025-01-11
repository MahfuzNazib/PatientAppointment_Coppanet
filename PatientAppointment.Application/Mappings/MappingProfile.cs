using AutoMapper;
using PatientAppointment.Application.DTO.Doctor;
using PatientAppointment.Application.DTO.PatientAppointment;
using PatientAppointment.Domain.Entities;

namespace PatientAppointment.Application.Mappings
{
    public class MappingProfile : Profile 
    {
        public MappingProfile()
        {
            CreateMap<PatientAppointments, PatientAppointmentDto>()
                .ForMember(d => d.Doctor, option => option.MapFrom(src =>  src.Doctor));

            CreateMap<Doctors, DoctorDto>();
        }
    }
}
