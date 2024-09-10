using Hospitals.Application.Models.Doctors;
using Hospitals.Domain.Models;
using Hospitals.WebApi.Common.Interfaces;
using Hospitals.WebApi.Models.Doctors;

namespace Hospitals.WebApi.Common.Mapping
{
    public class DoctorMapper : IDoctorMapper
    {
        public CreateDoctorsViewModel MapWith(CreateDoctorDto dto) =>
            new CreateDoctorsViewModel()
            {
                Name = dto.Name,
                Specialisation = dto.NameOfSpecialisation,
                Cabinet = dto.NumberOfCabinet
            };

        public UpdateDoctorsViewModel MapWith(UpdateDoctorDto dto) =>
            new UpdateDoctorsViewModel()
            {
                Name = dto.Name,
                Cabinet = dto.NumberOfCabinet,
                Specialisation = dto.NameOfSpecialisation,
                Id= dto.Id
            };

        public GetDoctorsViewModelQuery MapWith(GetDoctorsDto dto) =>
            new GetDoctorsViewModelQuery()
            {
                PropertyName = dto.PropertyName,
                Size = dto.Size, 
                StartPosition = dto.StartPosition,
            };
    }
}
