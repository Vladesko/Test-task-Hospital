using Hospitals.Domain.Enum;
using Hospitals.Domain.Models;
using Hospitals.Domain.ValueObjects;

namespace Hospitals.Application.Models.Patients
{
    public class UpdatePatientsViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public Adress Adress { get; set; }
        public Gender Gender { get; set; }
        public DateTimeOffset BirthDay { get; set; }
        public int Section { get; set; }
    }
}
