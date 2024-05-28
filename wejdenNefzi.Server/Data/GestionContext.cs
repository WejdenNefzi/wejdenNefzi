using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using wejdenNefzi.Server.Models;

namespace wejdenNefzi.Server.Data
{
    public class GestionContext: DbContext
    {
        public DbSet<Utilisateur> Utilisateurs { get; set; }
        public GestionContext(DbContextOptions<GestionContext> options) : base(options) { }

        
    }
}

