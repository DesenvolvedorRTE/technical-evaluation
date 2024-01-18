using DesafioRodonaves.Application.Commads.Response.Collaborator;
using DesafioRodonaves.Application.Commads.Response.User;
using DesafioRodonaves.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
