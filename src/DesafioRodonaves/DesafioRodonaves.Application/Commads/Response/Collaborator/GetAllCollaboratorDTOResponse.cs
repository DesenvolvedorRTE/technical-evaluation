using DesafioRodonaves.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioRodonaves.Application.Commads.Response.Collaborator
{
    public class GetAllCollaboratorDTOResponse : EntityBase
    {
        public string Name { get; set; }
        public int UnitId { get; set; }
        public int UserId { get; set; }
    }
}
