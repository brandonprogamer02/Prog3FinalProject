﻿using System;
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
    public class EstadoOrdensController : ControllerBase
    {
        private readonly db_finalprojectContext _context;

        public EstadoOrdensController(db_finalprojectContext context)
        {
            _context = context;
        }

        // GET: api/EstadoOrdens
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EstadoOrden>>> GetEstadoOrdens()
        {
            Response<List<EstadoOrden>> response = new Response<List<EstadoOrden>>();

            try
            {
                var listado = await _context.EstadoOrdens.Include(O=> O.Ordens).ToListAsync();
                response.Exito = 1;
                response.ls = listado;
            }
            catch (Exception ex)
            {

                response.Mensaje = ex.Message;
            }

            return Ok(response);
        }

        // GET: api/EstadoOrdens/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EstadoOrden>> GetEstadoOrden(int id)
        {
            var estadoOrden = await _context.EstadoOrdens.FindAsync(id);

            if (estadoOrden == null)
            {
                return NotFound();
            }

            return estadoOrden;
        }

        // PUT: api/EstadoOrdens/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEstadoOrden(int id, EstadoOrden estadoOrden)
        {
            if (id != estadoOrden.Id)
            {
                return BadRequest();
            }

            _context.Entry(estadoOrden).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstadoOrdenExists(id))
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

        // POST: api/EstadoOrdens
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EstadoOrden>> PostEstadoOrden(EstadoOrden estadoOrden)
        {
            _context.EstadoOrdens.Add(estadoOrden);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEstadoOrden", new { id = estadoOrden.Id }, estadoOrden);
        }

        // DELETE: api/EstadoOrdens/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEstadoOrden(int id)
        {
            var estadoOrden = await _context.EstadoOrdens.FindAsync(id);
            if (estadoOrden == null)
            {
                return NotFound();
            }

            _context.EstadoOrdens.Remove(estadoOrden);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EstadoOrdenExists(int id)
        {
            return _context.EstadoOrdens.Any(e => e.Id == id);
        }
    }
}
