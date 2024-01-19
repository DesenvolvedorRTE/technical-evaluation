using DesafioRodonaves.Domain.Commons;
using DesafioRodonaves.Domain.Enums;

namespace DesafioRodonaves.Domain.Entities
{
    public class User : EntityBase
    {
        public string Login { get; set; }
        public string Password { get; set; }

        public bool? Status { get; set; }

        public UserRole Roles { get; set; }

        // Propriedade de navegação
        public Collaborator Collaborator { get; set; }
    }
}
