namespace Hospitals.WebApi.Models.Doctors
{
    public class GetDoctorsDto
    {
        public int StartPosition { get; set; }
        public int Size { get; set; }
        public string PropertyName { get; set; } = string.Empty;
    }
}
