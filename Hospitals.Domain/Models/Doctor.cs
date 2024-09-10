namespace Hospitals.Domain.Models
{
    public class Doctor
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public Cabinet Cabinet { get; set; }
        public Specialisation Specialisation { get; set; }

    }
}
