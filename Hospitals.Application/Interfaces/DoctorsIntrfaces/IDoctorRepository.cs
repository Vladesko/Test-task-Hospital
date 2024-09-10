using Hospitals.Application.Models.Doctors;
using Hospitals.Domain.Models;

namespace Hospitals.Application.Interfaces.DoctorsIntrfaces
{
    public interface IDoctorRepository
    {
        Task<Guid> CreateDoctorAsync(CreateDoctorsViewModel model, CancellationToken token);
        Task UpdateDoctorAsync(UpdateDoctorsViewModel model, CancellationToken token);
        Task DeleteDoctorAsync(Guid id, CancellationToken token);
        Task<Doctor> GetDoctorAsync(Guid Id, CancellationToken token);
        Task<IEnumerable<Doctor>> GetDoctorsAsync(GetDoctorsViewModelQuery query, CancellationToken token);
    }
}
