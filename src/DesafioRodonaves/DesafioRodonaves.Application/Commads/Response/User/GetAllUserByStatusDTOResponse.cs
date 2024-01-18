using DesafioRodonaves.Domain.Commons;


namespace DesafioRodonaves.Application.Commads.Response.User
{
    public class GetAllUserByStatusDTOResponse : EntityBase
    {
        public string Login { get; set; }

        public bool Status { get; set; }
    }
}
