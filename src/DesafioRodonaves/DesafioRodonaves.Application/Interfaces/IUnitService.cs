using DesafioRodonaves.Application.Commads.Request.Unit;
using DesafioRodonaves.Application.Commads.Response.Unit;

namespace DesafioRodonaves.Application.Interfaces
{
    public interface IUnitService 
    {
        Task<IEnumerable<GetAllUnitDTOResponse>> GetAll();

        Task<GetUnitByIdDTOResponse> GetById(int id);

        Task<string> Create(CreateUnitDTORequest entity);

        Task<string> Update(UpdateUnitDtoRequest entity, int id);

        Task<string> Delete(int id);

        Task<IEnumerable<GetAllUnitAndAllCollaboratorDTOResponse>> GetAllUnitAndAllCollaboratorAssociate();
    }
}
