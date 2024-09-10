namespace Hospitals.Application.Models.Doctors
{
    public class GetDoctorViewModelResult
    {
        public Guid Id { get; set; }
        public int NumberOfCabinet { get; set; }
        public string Name { get; set; } = string.Empty;
        public string NameOfSpecialisation { get; set; } = string.Empty;
    }
}
