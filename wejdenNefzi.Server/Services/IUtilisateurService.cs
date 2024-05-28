using wejdenNefzi.Server.Models;

namespace wejdenNefzi.Server.Service
{
    public interface IUtilisateurService
    {
        IEnumerable<Utilisateur> GetAll();
        Utilisateur GetById(int id);
        void Create(Utilisateur utilisateur);
        void Update(int id, Utilisateur utilisateur);
        void Delete(int id);
    }
}