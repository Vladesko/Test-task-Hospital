using Hospitals.Application.Interfaces.DoctorsIntrfaces;
using Hospitals.Application.Interfaces.PatientsInterface;
using Hospitals.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Hospitals.Application.Common
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IDoctorService, DoctorService>();
            services.AddScoped<IPatientService, PatientService>();

            return services;
        }
    }
}
