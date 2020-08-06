using AutoMapper;
using BusinessLogic.DTO;
using BusinessLogic.Interfaces;
using DataLayer.Entities;

namespace BusinessLogic.Services.MapperConfiguration
{
    public class MappingConfiguration : IMappingConfiguration
    {
        public IMapper ConfigureMapper()
        {
            var configuration = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Student, StudentDTO>().ReverseMap();
                cfg.CreateMap<Subject, SubjectDTO>().ReverseMap();
                cfg.CreateMap<Professor, ProfessorDTO>().ReverseMap();
                cfg.CreateMap<Attendance, AttendanceDTO>().ReverseMap();
            });
            return configuration.CreateMapper();
        }
    }
}
