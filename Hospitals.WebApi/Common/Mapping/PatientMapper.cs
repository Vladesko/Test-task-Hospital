using Hospitals.Application.Models.Patients;
using Hospitals.Domain.ValueObjects;
using Hospitals.WebApi.Common.Interfaces;
using Hospitals.WebApi.Models.Patients;

namespace Hospitals.WebApi.Common.Mapping
{
    public class PatientMapper : IPatientMapper
    {
        public CreatePatientsViewModel MapWith(CreatePatientsDto dto) =>
            new CreatePatientsViewModel()
            {
                Adress = new Adress(dto.NameOfStreet, dto.NumberOfHouse),
                BirthDay = dto.Birthday,
                Gender = dto.Gender,
                Name = dto.Name,
                Section = dto.NumberOfSection,
            };


        public UpdatePatientsViewModel MapWith(UpdatePatientDto dto) =>
            new UpdatePatientsViewModel()
            {
                Id = dto.Id,
                Name = dto.Name,
                Adress = new Adress(dto.NameOfStreet, dto.NumberOfHouse),
                BirthDay = dto.BirthDay,
                Gender = dto.Gender,
                Section = dto.NumberOfSection
            };

        public GetPatientsViewModelQuery MapWith(GetPatientsDto dto) =>
            new GetPatientsViewModelQuery()
            {
                PropertyName = dto.PropertyName,
                StartPosition = dto.StartPosition,
                Size = dto.Size,
            };
    }
}
