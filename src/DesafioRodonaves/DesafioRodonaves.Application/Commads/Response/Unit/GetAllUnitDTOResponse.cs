
using DesafioRodonaves.Domain.Commons;

namespace DesafioRodonaves.Application.Commads.Response.Unit
{
    public class GetAllUnitDTOResponse : EntityBase
    {
        public string UnitName { get; set; }

        public string UnitCode { get; set; }
      
        public bool Status { get; set; }
    }
}
