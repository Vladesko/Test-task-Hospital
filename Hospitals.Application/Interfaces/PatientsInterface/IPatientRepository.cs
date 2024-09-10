using Hospitals.Application.Models.Patients;
using Hospitals.Domain.Models;

namespace Hospitals.Application.Interfaces.PatientsInterface
{
    public interface IPatientRepository
    {
        Task<Guid> CreatePatientAsync(CreatePatientsViewModel model, CancellationToken token);
        Task UpdatePatientAsync(UpdatePatientsViewModel model, CancellationToken token);
        Task DeletePatientAsync(Guid id, CancellationToken token);
        Task<IEnumerable<Patient>> GetPatientsAsync(GetPatientsViewModelQuery query, CancellationToken token);
        Task<Patient> GetPatientAsync(Guid id, CancellationToken token);
    }
}
