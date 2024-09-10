using Hospitals.Application.Models.Patients;
using Hospitals.WebApi.Models.Patients;

namespace Hospitals.WebApi.Common.Interfaces
{
    public interface IPatientMapper
    {
        CreatePatientsViewModel MapWith(CreatePatientsDto dto);
        UpdatePatientsViewModel MapWith(UpdatePatientDto dto);
        GetPatientsViewModelQuery MapWith(GetPatientsDto dto);
    }
}
