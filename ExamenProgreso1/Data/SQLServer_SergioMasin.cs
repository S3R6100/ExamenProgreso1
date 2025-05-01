using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SergioMasin.Models;

    public class SQLServer_SergioMasin : DbContext
    {
        public SQLServer_SergioMasin (DbContextOptions<SQLServer_SergioMasin> options)
            : base(options)
        {
        }

        public DbSet<SergioMasin.Models.Dueno> Dueno { get; set; } = default!;

public DbSet<SergioMasin.Models.Mascota> Mascota { get; set; } = default!;

public DbSet<SergioMasin.Models.Visita> Visita { get; set; } = default!;
    }
