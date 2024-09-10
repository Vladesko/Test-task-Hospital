using Hospitals.Domain.Models;

namespace Hospitals.Application.Models.Doctors
{
    public class CreateDoctorsViewModel
    {
        public string Name { get; set; } = string.Empty;
        public int Cabinet { get; set; }
        public string Specialisation { get; set; } = string.Empty;
    }
}
