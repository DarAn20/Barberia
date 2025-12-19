using Barberia.Data;
using Barberia.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Runtime.ConstrainedExecution;



namespace Barberia.Controllers

{
    //ya quedo bien para ver si se actuazliza git
    [Authorize]
    public class CitasController : Controller
    {
        private readonly BarberiaContext _context;

        public CitasController(BarberiaContext context)
        {
            _context = context;
        }
        //ocupo hacer que sirva y ensene los nombres de los servicios y 
        //nombre de los clientes
        // GET: Citas
        public async Task<IActionResult> Index()
        {
            var barberiaContext = _context.Cita.Include(c => c.Servicio).Include(c => c.cliente);
            return View(await barberiaContext.ToListAsync());
        }

        // GET: Citas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cita = await _context.Cita
                .Include(c => c.Servicio)
                .Include(c => c.cliente)
                .FirstOrDefaultAsync(m => m.CitaId == id);
            if (cita == null)
            {
                return NotFound();
            }

            return View(cita);
        }

        // GET: Citas/Create
        public IActionResult Create()
        {
            ViewData["NombreServicio"] = new SelectList(_context.Servicio, "ServicioId", "NombreServicio");
            ViewData["NombreCliente"] = new SelectList(_context.cliente.Select(c => new{ c.ClienteId,NombreMostrar = c.NombreCliente + " — " + c.Email}), "ClienteId","NombreMostrar");

            return View();
        }

        // POST: Citas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CitaId,FechaHora,ClienteId,ServicioId,Email")] Cita cita)
        {
            if (cita.FechaHora < DateTime.Now ||
         cita.FechaHora > DateTime.Now.AddDays(8))
            {
                ModelState.AddModelError(
                    "",
                    "La fecha debe ser hoy o dentro de los próximos 8 días."
                );
            }
            else
            {
                try
                {
                    _context.Add(cita);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException)
                {
                    ModelState.AddModelError("", "Error al guardar los cambios.");
                }
            }

            ViewData["NombreServicio"] = new SelectList(_context.Servicio, "ServicioId", "NombreServicio", cita.ServicioId);
            ViewData["NombreCliente"] = new SelectList(_context.cliente.Select(c => new { c.ClienteId, NombreMostrar = c.NombreCliente + " — " + c.Email }), "ClienteId", "NombreMostrar");
            return View(cita);
        }

        // GET: Citas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cita = await _context.Cita.FindAsync(id);
            if (cita == null)
            {
                return NotFound();
            }
            ViewData["NombreServicio"] = new SelectList(_context.Servicio, "ServicioId", "NombreServicio", cita.ServicioId);
          //  ViewData["ClienteId"] = new SelectList(_context.cliente, "ClienteId", "NombreCliente", cita.ClienteId);
            return View(cita);
        }

        // POST: Citas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CitaId,FechaHora,ClienteId,ServicioId")] Cita cita)
        {
            if (id != cita.CitaId)
                return NotFound();

            // Validar fecha
            if (cita.FechaHora < DateTime.Now || cita.FechaHora > DateTime.Now.AddDays(8))
            {
                ModelState.AddModelError("FechaHora", "La fecha debe ser hoy o dentro de los próximos 8 días.");
                ViewData["NombreServicio"] = new SelectList(_context.Servicio, "ServicioId", "NombreServicio", cita.ServicioId);
                // ViewData["ClienteId"] = new SelectList(_context.cliente, "ClienteId", "NombreCliente", cita.ClienteId);
                return View(cita);

            }
           

                // Obtener cita original
                var citaDb = await _context.Cita.FindAsync(id);

            // Actualizar solo lo permitido
            citaDb.FechaHora = cita.FechaHora;
            citaDb.ServicioId = cita.ServicioId;

            await _context.SaveChangesAsync();

            //return View(cita);
            return RedirectToAction(nameof(Index));

        }

        // GET: Citas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cita = await _context.Cita
                .Include(c => c.Servicio)
                .Include(c => c.cliente)
                .FirstOrDefaultAsync(m => m.CitaId == id);
            if (cita == null)
            {
                return NotFound();
            }

            return View(cita);
        }

        // POST: Citas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cita = await _context.Cita.FindAsync(id);
            if (cita != null)
            {
                _context.Cita.Remove(cita);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CitaExists(int id)
        {
            return _context.Cita.Any(e => e.CitaId == id);
        }
    }
}
