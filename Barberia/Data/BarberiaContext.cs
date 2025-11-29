using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Barberia.Models;

namespace Barberia.Data
{
    public class BarberiaContext : DbContext
    {
        public BarberiaContext (DbContextOptions<BarberiaContext> options)
            : base(options)
        {
        }

        public DbSet<Barberia.Models.Cita> Cita { get; set; } = default!;
        public DbSet<Barberia.Models.cliente> cliente { get; set; } = default!;
        public DbSet<Barberia.Models.Servicio> Servicio { get; set; } = default!;
    }
}
