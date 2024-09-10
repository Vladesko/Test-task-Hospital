using Hospitals.Application.Interfaces.DoctorsIntrfaces;
using Hospitals.Application.Interfaces.PatientsInterface;
using Hospitals.Persistance.Database;
using Hospitals.Persistance.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Hospitals.Persistance.Common
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistance(this IServiceCollection services, 
                                                        IConfiguration configuration)
        {
            services.AddDbContext<HospitalsDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddScoped<IDoctorRepository, DoctorRepository>();
            services.AddScoped<IPatientRepository, PatientRepository>();

            return services;
        }
    }
}
