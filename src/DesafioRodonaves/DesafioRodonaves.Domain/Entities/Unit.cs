using DesafioRodonaves.Domain.Commons;

namespace DesafioRodonaves.Domain.Entities 
{ 
    public class Unit : EntityBase
    {
        public string? UnitName { get; set; }   
        
        public string? UnitCode { get; set; }

        public bool? Status { get; set; }

        // Propriedade de navageção
        public IEnumerable<Collaborator> CollaboratorNavigation { get; set; } = new List<Collaborator>();
       
    }
}
