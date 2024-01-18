using DesafioRodonaves.Domain.Commons;


namespace DesafioRodonaves.Domain.Entities
{
    public class Collaborator : EntityBase
    {
        public string Name { get; set; }

        // Relacionamento com a unidade
        public Unit Unit { get; set; } 
        public int? UnitId { get; set; }

        // Relacionamento com o usuário
        public User User { get; set; } 
        public int? UserId { get; set; }


    }
}
