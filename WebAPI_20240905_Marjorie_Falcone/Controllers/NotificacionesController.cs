using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI_20240905_Marjorie_Falcone.Data;
using WebAPI_20240905_Marjorie_Falcone.Models;

namespace WebAPI_20240905_Marjorie_Falcone.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class NotificacionesController : ControllerBase
    {
        private readonly BG_Marjorie_FalconeContext _context;

        public NotificacionesController(BG_Marjorie_FalconeContext context)
        {
            _context = context;
        }

        // GET: api/Notificaciones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Notificacione>>> GetNotificaciones()
        {
          if (_context.Notificaciones == null)
          {
              return NotFound();
          }
            return await _context.Notificaciones.ToListAsync();
        }

        // GET: api/Notificaciones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Notificacione>> GetNotificacione(int id)
        {
          if (_context.Notificaciones == null)
          {
              return NotFound();
          }
            var notificacione = await _context.Notificaciones.FindAsync(id);

            if (notificacione == null)
            {
                return NotFound();
            }

            return notificacione;
        }

        // PUT: api/Notificaciones/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNotificacione(int id, Notificacione notificacione)
        {
            if (id != notificacione.IdNotificacion)
            {
                return BadRequest();
            }

            _context.Entry(notificacione).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NotificacioneExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Notificaciones
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Notificacione>> PostNotificacione(Notificacione notificacione)
        {
          if (_context.Notificaciones == null)
          {
              return Problem("Entity set 'BG_Marjorie_FalconeContext.Notificaciones'  is null.");
          }
            _context.Notificaciones.Add(notificacione);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNotificacione", new { id = notificacione.IdNotificacion }, notificacione);
        }

        // DELETE: api/Notificaciones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNotificacione(int id)
        {
            if (_context.Notificaciones == null)
            {
                return NotFound();
            }
            var notificacione = await _context.Notificaciones.FindAsync(id);
            if (notificacione == null)
            {
                return NotFound();
            }

            _context.Notificaciones.Remove(notificacione);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NotificacioneExists(int id)
        {
            return (_context.Notificaciones?.Any(e => e.IdNotificacion == id)).GetValueOrDefault();
        }
    }
}
