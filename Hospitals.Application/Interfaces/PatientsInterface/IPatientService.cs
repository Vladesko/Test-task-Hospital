using Hospitals.Application.Models.Doctors;
using Hospitals.Application.Models.Patients;

namespace Hospitals.Application.Interfaces.PatientsInterface
{
    public interface IPatientService
    {
        Task<Guid> CreatePatientAsync(CreatePatientsViewModel model, CancellationToken token);
        Task UpdatePatientAsync(UpdatePatientsViewModel model, CancellationToken token);
        Task DeletePatientAsync(Guid id, CancellationToken token);
        Task<IEnumerable<GetPatientsViewModelResult>> GetPatientsAsync(GetPatientsViewModelQuery query, CancellationToken token);
        Task<GetPatientViewModelResult> GetPatientAsync(Guid id, CancellationToken token);
    }
}
