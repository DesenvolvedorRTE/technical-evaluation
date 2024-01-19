using DesafioRodonaves.Application.Commads.Response.Collaborator;

namespace DesafioRodonaves.Application.Commads.Response.Unit
{
    public class GetAllUnitAndAllCollaboratorDTOResponse
    {
        public int Id { get; set; }
        public string UnitName { get; set; }

        public string UnitCode { get; set; }

        public bool Status { get; set; }

        public IEnumerable<GetAllCollaboratorDTOResponse> Collaborator { get; set; }
    }
}