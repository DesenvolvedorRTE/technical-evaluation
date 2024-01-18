
namespace DesafioRodonaves.Application.Commads.Request.User
{
    public class UpdateUserDTORequest
    {
        public string? Login { get; set; }
        public string? Password { get; set; }

        public bool? Status { get; set; } = true;
    }
}
