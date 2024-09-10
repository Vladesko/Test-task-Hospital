using Hospitals.Domain.Enum;

namespace Hospitals.WebApi.Models.Patients
{
    public class CreatePatientsDto
    {
        public string Name { get; set; } = string.Empty;
        public string NameOfStreet {  get; set; } = string.Empty;
        public int NumberOfHouse { get; set; }
        public Gender Gender { get; set; }
        public DateTimeOffset Birthday { get; set; }
        public int NumberOfSection { get; set; }
    }
}
