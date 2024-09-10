namespace Hospitals.Persistance.Common.Exceptions
{
    public class NotFoundException(string message) : Exception(message)
    {
    }
}
