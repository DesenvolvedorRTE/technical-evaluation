using System.Net;

namespace DesafioRodonaves.Domain.Commons.Execptions;

public class NotFoundException : CustomException
{
    public NotFoundException(string message)
        : base(message, null, HttpStatusCode.NotFound)
    {
    }
}