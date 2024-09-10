namespace Hospitals.WebApi.Models.Patients
{
    public class GetPatientsDto
    {
        public int StartPosition { get; set; }
        public int Size { get; set; }
        public string PropertyName { get; set; } = string.Empty;
    }
}
