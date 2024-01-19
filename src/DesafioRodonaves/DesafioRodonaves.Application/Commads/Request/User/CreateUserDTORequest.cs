
using DesafioRodonaves.Domain.Enums;
using System.Text.Json.Serialization;

namespace DesafioRodonaves.Application.Commads.Request.User
{
    public class CreateUserDTORequest
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public bool Status { get; set; }

        public UserRole Role { get; set; }
    }
}
