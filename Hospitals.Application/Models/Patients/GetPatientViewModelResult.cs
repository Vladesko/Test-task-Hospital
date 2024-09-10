using Hospitals.Domain.Enum;
using Hospitals.Domain.ValueObjects;

namespace Hospitals.Application.Models.Patients
{
    public class GetPatientViewModelResult
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public Adress Adress { get; set; }
        public int NumberOfSection { get; set; }
        public DateTimeOffset Birthday { get; set; }
        public Gender Gender { get; set; }
    }
}
