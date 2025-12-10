using Barberia.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Barberia.Data
{
    public class BarberiaContext : IdentityDbContext<IdentityUser>
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
