using DesafioRodonaves.Domain.Commons.Execptions;
using System.Net;

public class ConversionErrorException : CustomException
{
    public ConversionErrorException(string message, List<string>? errors = default)
        : base(message, errors, HttpStatusCode.InternalServerError)
    {
    }
}