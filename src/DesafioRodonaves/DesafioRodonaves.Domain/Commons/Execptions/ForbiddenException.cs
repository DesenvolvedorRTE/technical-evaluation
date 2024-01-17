using System.Net;

namespace DesafioRodonaves.Domain.Commons.Execptions;
public class ForbiddenException : CustomException
{
    public ForbiddenException(string message)
        : base(message, null, HttpStatusCode.Forbidden)
    {
    }
}