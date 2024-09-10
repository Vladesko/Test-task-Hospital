using Hospitals.Application.Models.Doctors;
using Hospitals.WebApi.Models.Doctors;

namespace Hospitals.WebApi.Common.Interfaces
{
    public interface IDoctorMapper
    {
        CreateDoctorsViewModel MapWith(CreateDoctorDto dto);
        UpdateDoctorsViewModel MapWith(UpdateDoctorDto dto);
        GetDoctorsViewModelQuery MapWith(GetDoctorsDto dto);
    }
}
