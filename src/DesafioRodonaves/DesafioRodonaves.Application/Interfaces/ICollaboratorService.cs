using DesafioRodonaves.Application.Commads.Request.Collaborator;
using DesafioRodonaves.Application.Commads.Response.Collaborator;

namespace DesafioRodonaves.Application.Interfaces
{
    public interface ICollaboratorService
    {
        Task<IEnumerable<GetAllCollaboratorDTOResponse>> GetAll();

        Task<GetCollaboratorByIdDTOResponse> GetById(int id);

        Task<string> Create(CreateCollaboratorDTORequest collaboratorResquest);

        Task<string> Update(UpdateCollaboratorDTORequest entity, int id);

        Task<string> Delete(int id);
    }
}