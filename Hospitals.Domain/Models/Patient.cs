using Hospitals.Domain.Enum;
using Hospitals.Domain.ValueObjects;

namespace Hospitals.Domain.Models
{
    public class Patient
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public Adress Adress { get; set; }
        public Gender Gender { get; set; }
        public DateTimeOffset BirthDay { get; set; }
        public Section Section { get; set; }

    }
}
