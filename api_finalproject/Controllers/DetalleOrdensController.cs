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
    public class DetalleOrdensController : ControllerBase
    {
        private readonly db_finalprojectContext _context;

        public DetalleOrdensController(db_finalprojectContext context)
        {
            _context = context;
        }

        // GET: api/DetalleOrdens
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DetalleOrden>>> GetDetalleOrdens()
        {
            Response<List<DetalleOrden>> response = new Response<List<DetalleOrden>>();

            try
            {
                var listado = await _context.DetalleOrdens.Include(O=> O.Orden).Include(P => P.Producto).ToListAsync();
                response.Exito = 1;
                response.ls = listado;
            }
            catch (Exception ex)
            {

                response.Mensaje = ex.Message;
            }

            return Ok(response);
        }

        // GET: api/DetalleOrdens/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DetalleOrden>> GetDetalleOrden(int id)
        {
            var detalleOrden = await _context.DetalleOrdens.FindAsync(id);

            if (detalleOrden == null)
            {
                return NotFound();
            }

            return detalleOrden;
        }

        // PUT: api/DetalleOrdens/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDetalleOrden(int id, DetalleOrden detalleOrden)
        {
            if (id != detalleOrden.Id)
            {
                return BadRequest();
            }

            _context.Entry(detalleOrden).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DetalleOrdenExists(id))
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

        // POST: api/DetalleOrdens
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DetalleOrden>> PostDetalleOrden(DetalleOrden detalleOrden)
        {
            _context.DetalleOrdens.Add(detalleOrden);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDetalleOrden", new { id = detalleOrden.Id }, detalleOrden);
        }

        // DELETE: api/DetalleOrdens/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDetalleOrden(int id)
        {
            var detalleOrden = await _context.DetalleOrdens.FindAsync(id);
            if (detalleOrden == null)
            {
                return NotFound();
            }

            _context.DetalleOrdens.Remove(detalleOrden);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DetalleOrdenExists(int id)
        {
            return _context.DetalleOrdens.Any(e => e.Id == id);
        }
    }
}
