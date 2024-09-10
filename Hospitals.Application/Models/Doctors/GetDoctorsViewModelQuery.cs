namespace Hospitals.Application.Models.Doctors
{
    public class GetDoctorsViewModelQuery
    {
        public int Size { get; set; }
        public int StartPosition { get; set; }
        public string PropertyName { get; set; } = string.Empty;
    }
}
