﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema_de_planos.Dominio.Entidades;
using Sistema_de_planos.Infraestructura.Datos;
using Sistema_de_planos.Models;

namespace Sistema_de_planos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadosController : ControllerBase
    {
        private readonly PlanosContext _context;

        public EstadosController(PlanosContext context)
        {
            _context = context;
        }

        // GET: api/Estados
        [HttpGet]
        public async Task<ActionResult<ApiResult<Estado>>> GetEstados(
            int pageIndex = 0,
            int pageSize = 10)
        {
            return await ApiResult<Estado>.CreateAsync(
                _context.Estados,
                pageIndex,
                pageSize,
                "codigo",
                "asc",
                "descripcion",
                null
                );
        }

        // GET: api/Estados/onlyEstados -- DEVUELVE SÓLO LOS ESTADOS SIN USAR APIRESULT
        [HttpGet("/onlyEstados")]
        public async Task<ActionResult<IEnumerable<Estado>>> GetEstados()
        {
            if (_context.Estados == null)
            {
                return NotFound();
            }
            return await _context.Estados.ToListAsync();
        }

        // GET: api/Estados/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Estado>> GetEstado(int id)
        {
          if (_context.Estados == null)
          {
              return NotFound();
          }
            var estado = await _context.Estados.FindAsync(id);

            if (estado == null)
            {
                return NotFound();
            }

            return estado;
        }

        // PUT: api/Estados/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEstado(int id, Estado estado)
        {
            if (id != estado.Id)
            {
                return BadRequest();
            }

            _context.Entry(estado).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstadoExists(id))
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

        // POST: api/Estados
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Estado>> PostEstado(EstadoModelPOST estadoM)
        {
          if (_context.Estados == null)
          {
              return Problem("Entity set 'PlanosContext.Estados'  is null.");
          }
            Estado estado = new();
            estado.Descripcion = estadoM.Descripcion;
            estado.Codigo = estadoM.Codigo;
            _context.Estados.Add(estado);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEstado", new { id = estado.Id }, estado);
        }

        [HttpPost]
        [Route("IsDupeEstado")]
        public bool IsDupeEstado(Estado estado)
        {
            return _context.Estados.Any(
                e => e.Codigo == estado.Codigo && e.Descripcion == estado.Descripcion && e.Id != estado.Id);

        }

        // DELETE: api/Estados/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEstado(int id)
        {
            if (_context.Estados == null)
            {
                return NotFound();
            }
            var estado = await _context.Estados.FindAsync(id);
            if (estado == null)
            {
                return NotFound();
            }

            _context.Estados.Remove(estado);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EstadoExists(int id)
        {
            return (_context.Estados?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
