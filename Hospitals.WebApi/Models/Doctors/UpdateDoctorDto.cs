namespace Hospitals.WebApi.Models.Doctors
{
    public class UpdateDoctorDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int NumberOfCabinet { get; set; }
        public string NameOfSpecialisation { get; set; } = string.Empty;
    }
}
