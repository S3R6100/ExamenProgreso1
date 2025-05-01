using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SergioMasin.Models;

namespace SergioMasin.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Dueno> Duenos { get; set; }
        public DbSet<Mascota> Mascotas { get; set; }
        public DbSet<Visita> Visitas { get; set; }
    }
}

