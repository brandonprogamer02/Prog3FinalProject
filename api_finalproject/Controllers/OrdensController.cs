using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api_finalproject.Models;
using api_finalproject.Models.Response;

namespace api_finalproject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdensController : ControllerBase
    {
        private readonly db_finalprojectContext _context;

        public OrdensController(db_finalprojectContext context)
        {
            _context = context;
        }

        // GET: api/Ordens
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Orden>>> GetOrdens()
        {
            Response<List<Orden>> response = new Response<List<Orden>>();

            try
            {
                var listado = await  _context.Ordens.Include(Client => Client.Cliente).Include(Es=> Es.EstadoOrden).Include(De=> De.DetalleOrdens).Include(P => P.Pedidos).ToListAsync();
                response.Exito = 1;
                response.ls = listado;
            }
            catch (Exception ex)
            {

                response.Mensaje = ex.Message;
            }

            return Ok(response);
        }

        // GET: api/Ordens/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Orden>> GetOrden(int id)
        {
            var orden = await _context.Ordens.FindAsync(id);

            if (orden == null)
            {
                return NotFound();
            }

            return orden;
        }

        // PUT: api/Ordens/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrden(int id, Orden orden)
        {
            if (id != orden.Id)
            {
                return BadRequest();
            }

            _context.Entry(orden).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrdenExists(id))
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

        // POST: api/Ordens
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Orden>> PostOrden(Orden orden)
        {
            _context.Ordens.Add(orden);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrden", new { id = orden.Id }, orden);
        }

        // DELETE: api/Ordens/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrden(int id)
        {
            var orden = await _context.Ordens.FindAsync(id);
            if (orden == null)
            {
                return NotFound();
            }

            _context.Ordens.Remove(orden);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrdenExists(int id)
        {
            return _context.Ordens.Any(e => e.Id == id);
        }
    }
}
