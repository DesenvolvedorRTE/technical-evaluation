
namespace DesafioRodonaves.Application.Interfaces
{
    public interface IPasswordManager
    {

        string HashPassword(string password);

        bool VerifyPassword(string hashedPassword, string providedPassword);
    }
}
