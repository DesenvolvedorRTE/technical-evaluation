using DesafioRodonaves.Domain.Commons;

namespace DesafioRodonaves.Domain.Entities 
{ 
    public class Unit : EntityBase
    {
        public string UnitName { get; set; }   
        
        public string UnitCode { get; set; }

        // Propriedade de navageção
        public Collaborator CollaboratorNavigation { get; set; }

       
    }
}
