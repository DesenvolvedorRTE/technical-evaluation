

using DesafioRodonaves.Domain.Commons;

namespace DesafioRodonaves.Application.Commads.Response.Collaborator
{
    public class GetCollaboratorByIdDTOResponse : EntityBase
    {
        public string Name { get; set; }
        public int UnitId { get; set; }
        public int UserId { get; set; }

    }
}
