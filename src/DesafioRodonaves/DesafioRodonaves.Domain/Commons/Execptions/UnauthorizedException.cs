using System.Net;

namespace DesafioRodonaves.Domain.Commons.Execptions;
public class UnauthorizedException : CustomException
{
    public UnauthorizedException(string message)
       : base(message, null, HttpStatusCode.Unauthorized)
    {
    }
}