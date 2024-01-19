using DesafioRodonaves.Domain.Commons;

namespace DesafioRodonaves.Application.Commads.Response.User
{
    public class GetUserByIdDTOResponse : EntityBase
    {
        public string Login { get; set; }

        public bool Status { get; set; }
    }
}