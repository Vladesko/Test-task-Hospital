namespace Hospitals.Application.Models.Patients
{
    public class GetPatientsViewModelQuery
    {
        public int Size { get; set; }
        public int StartPosition { get; set; }
        public string PropertyName { get; set; } = string.Empty;
    }
}
