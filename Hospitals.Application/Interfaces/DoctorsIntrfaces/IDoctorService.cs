using Hospitals.Application.Models.Doctors;
using Hospitals.Domain.Models;

namespace Hospitals.Application.Interfaces.DoctorsIntrfaces
{
    public interface IDoctorService
    {
        Task<Guid> CreateDoctorAsync(CreateDoctorsViewModel model, CancellationToken token);
        Task UpdateDoctorAsync(UpdateDoctorsViewModel model, CancellationToken token);
        Task DeleteDoctorAsync(Guid id, CancellationToken token);
        Task<GetDoctorViewModelResult> GetDoctorAsync(Guid Id, CancellationToken token);
        Task<IEnumerable<GetDoctorsViewModelResult>> GetDoctorsAsync(GetDoctorsViewModelQuery query, CancellationToken token);  
    }
}
