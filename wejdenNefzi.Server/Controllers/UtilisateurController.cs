using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using wejdenNefzi.Server.Models;
using wejdenNefzi.Server.Service;

namespace wejdenNefzi.Server.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UtilisateurController : ControllerBase
    {
        private readonly IUtilisateurService _utilisateurService;

        public UtilisateurController(IUtilisateurService utilisateurService)
        {
            _utilisateurService = utilisateurService;
        }

        [HttpGet]
        public IEnumerable<Utilisateur> GetAll()
        {
            return _utilisateurService.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<Utilisateur> GetById(int id)
        {
            var user = _utilisateurService.GetById(id);
            if (user == null)
            {
                return NotFound();
            }
            return user;
        }

        [HttpPost]
        public ActionResult<Utilisateur> Create(Utilisateur utilisateur)
        {
            _utilisateurService.Create(utilisateur);
            return CreatedAtAction(nameof(GetById), new { id = utilisateur.Id }, utilisateur);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Utilisateur utilisateur)
        {
            if (id != utilisateur.Id)
            {
                return BadRequest();
            }
            _utilisateurService.Update(id, utilisateur);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var user = _utilisateurService.GetById(id);
            if (user == null)
            {
                return NotFound();
            }
            _utilisateurService.Delete(id);
            return NoContent();
        }
    }
}