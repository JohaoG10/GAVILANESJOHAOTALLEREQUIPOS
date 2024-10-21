using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GAVILANESJOHAOTALLEREQUIPOS.Models;

    public class tallergavilanesContext : DbContext
    {
        public tallergavilanesContext (DbContextOptions<tallergavilanesContext> options)
            : base(options)
        {
        }

        public DbSet<GAVILANESJOHAOTALLEREQUIPOS.Models.Equipoligapro> Equipoligapro { get; set; } = default!;

public DbSet<GAVILANESJOHAOTALLEREQUIPOS.Models.Estadio> Estadio { get; set; } = default!;

public DbSet<GAVILANESJOHAOTALLEREQUIPOS.Models.Jugador> Jugador { get; set; } = default!;
    }
