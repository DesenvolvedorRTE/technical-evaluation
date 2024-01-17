using System.Net;

namespace DesafioRodonaves.Domain.Commons.Execptions;

public class ConflictException : CustomException
{
    public ConflictException(string message)
        : base(message, null, HttpStatusCode.Conflict)
    {
    }
}