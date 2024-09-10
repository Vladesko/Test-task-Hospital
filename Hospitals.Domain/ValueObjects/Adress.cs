using CSharpFunctionalExtensions;

namespace Hospitals.Domain.ValueObjects
{
    public class Adress
    {
        public string Street { get; private set; } = string.Empty;
        public int NumberOfHouse { get; private set; }
        public Adress(string Street, int NumberOfHouse)
        {
            this.Street = Street;
            this.NumberOfHouse = NumberOfHouse;
        }
    }
}
