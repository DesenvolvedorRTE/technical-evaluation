
using DesafioRodonaves.Domain.Commons;

namespace DesafioRodonaves.Application.Commads.Response.User
{
    public class GetAllUserDTOResponse : EntityBase
    {
        public string Login { get; set; }

        public bool Status { get; set; }
    }
}
