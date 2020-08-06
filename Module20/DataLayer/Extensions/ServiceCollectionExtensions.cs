using DataLayer.Entities;
using DataLayer.Interfaces;
using DataLayer.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace DataLayer.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterDalServices(this IServiceCollection services)
        {
            services.AddScoped<IRepository<Student>, StudentRepository>();

            services.AddScoped<IRepository<Subject>, SubjectRepository>();

            services.AddScoped<IRepository<Attendance>, AttendanceRepository>();
            
            services.AddScoped<IRepository<Professor>, ProfessorRepository>();
        }
    }
}
