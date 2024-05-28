using wejdenNefzi.Server.Models;

namespace wejdenNefzi.Server.Service
{
    public interface IAuthentificationService
    {
        string Authenticate(string email, string password);
    }
}