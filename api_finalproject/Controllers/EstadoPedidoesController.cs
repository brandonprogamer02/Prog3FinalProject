using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api_finalproject.Models;
using api_finalproject.Models.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace api_finalproject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class EstadoPedidoesController : ControllerBase
    {
        private readonly db_finalprojectContext _context;

        public EstadoPedidoesController(db_finalprojectContext context)
        {
            _context = context;
        }

        // GET: api/EstadoPedidoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EstadoPedido>>> GetEstadoPedidos()
        {
            Response<List<EstadoPedido>> response = new Response<List<EstadoPedido>>();

            try
            {
                var listado = await _context.EstadoPedidos.Include(P=> P.Pedidos).ToListAsync();
                response.Exito = 1;
                response.ls = listado;
            }
            catch (Exception ex)
            {
                response.Mensaje = ex.Message;
            }

            return Ok(response);
        }

        // GET: api/EstadoPedidoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EstadoPedido>> GetEstadoPedido(int id)
        {
            var estadoPedido = await _context.EstadoPedidos.FindAsync(id);

            if (estadoPedido == null)
            {
                return NotFound();
            }

            return estadoPedido;
        }

        // PUT: api/EstadoPedidoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEstadoPedido(int id, EstadoPedido estadoPedido)
        {
            if (id != estadoPedido.Id)
            {
                return BadRequest();
            }

            _context.Entry(estadoPedido).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstadoPedidoExists(id))
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

        // POST: api/EstadoPedidoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EstadoPedido>> PostEstadoPedido(EstadoPedido estadoPedido)
        {
            _context.EstadoPedidos.Add(estadoPedido);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEstadoPedido", new { id = estadoPedido.Id }, estadoPedido);
        }

        // DELETE: api/EstadoPedidoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEstadoPedido(int id)
        {
            var estadoPedido = await _context.EstadoPedidos.FindAsync(id);
            if (estadoPedido == null)
            {
                return NotFound();
            }

            _context.EstadoPedidos.Remove(estadoPedido);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EstadoPedidoExists(int id)
        {
            return _context.EstadoPedidos.Any(e => e.Id == id);
        }
    }
}
