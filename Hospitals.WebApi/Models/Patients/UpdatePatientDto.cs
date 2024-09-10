using Hospitals.Domain.Enum;
using Hospitals.Domain.ValueObjects;

namespace Hospitals.WebApi.Models.Patients
{
    public class UpdatePatientDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string NameOfStreet { get; set; } = string.Empty;
        public int NumberOfHouse { get; set; }
        public Gender Gender { get; set; }
        public DateTimeOffset BirthDay { get; set; }
        public int NumberOfSection { get; set; }
    }
}
