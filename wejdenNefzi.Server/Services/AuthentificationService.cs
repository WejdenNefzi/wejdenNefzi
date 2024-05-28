using Microsoft.AspNetCore.Authentication;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using wejdenNefzi.Server.Data;
using wejdenNefzi.Server.Models;

namespace wejdenNefzi.Server.Service
{
    public class AuthentificationService : IAuthentificationService
    {

        private readonly GestionContext _context;
        private readonly IConfiguration _configuration;

        public AuthentificationService(GestionContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public string Authenticate(string email, string password)
        {
            var user = _context.Utilisateurs.SingleOrDefault(u => u.Email == email && u.MotDePasse == password);
            if (user == null) return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString()),
                    new Claim(ClaimTypes.Role, user.Role)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
    }
