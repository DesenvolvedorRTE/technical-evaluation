using DesafioRodonaves.Application.Commads.Request.User;

namespace DesafioRodonaves.Application.Commads.Request.Collaborator
{
    public class CreateCollaboratorDTORequest
    {
        public string Name { get; set; }

        public int UnitId { get; set; }

        public CreateUserDTORequest User { get; set; }
    }
}