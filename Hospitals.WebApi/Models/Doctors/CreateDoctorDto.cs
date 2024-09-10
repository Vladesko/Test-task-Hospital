namespace Hospitals.WebApi.Models.Doctors
{
    public class CreateDoctorDto
    {
        public string Name { get; set; }
        public int NumberOfCabinet { get; set; }
        public string NameOfSpecialisation { get; set; }
    }
}
