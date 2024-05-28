using wejdenNefzi.Server.Data;
using wejdenNefzi.Server.Models;

namespace wejdenNefzi.Server.Service
{
    public class UtilisateurService : IUtilisateurService
    {
       
        private readonly GestionContext _context;

        public UtilisateurService(GestionContext context)
        {
            _context = context;
        }

        public IEnumerable<Utilisateur> GetAll()
        {
            return _context.Utilisateurs.ToList();
        }

        public Utilisateur GetById(int id)
        {
            return _context.Utilisateurs.Find(id);
        }

        public void Create(Utilisateur utilisateur)
        {
            _context.Utilisateurs.Add(utilisateur);
            _context.SaveChanges();
        }

        public void Update(int id, Utilisateur utilisateur)
        {
            var existingUser = _context.Utilisateurs.FirstOrDefault(u => u.Id == id);
            if (existingUser == null) return;

            existingUser.Nom = utilisateur.Nom;
            existingUser.Email = utilisateur.Email;
            existingUser.MotDePasse = utilisateur.MotDePasse;
            existingUser.Role = utilisateur.Role;
            existingUser.NumeroDeTelephone = utilisateur.NumeroDeTelephone;

            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var utilisateur = _context.Utilisateurs.FirstOrDefault(u => u.Id == id);
            if (utilisateur != null)
            {
                _context.Utilisateurs.Remove(utilisateur);
                _context.SaveChanges();
            }
        }
    }
    }

   

