using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EcoX9.Data;
using EcoX9.Models;

namespace EcoX9.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class Tipo_OcorrenciaController : ControllerBase
    {
        private readonly EcoX9Context _context;

        public Tipo_OcorrenciaController(EcoX9Context context)
        {
            _context = context;
        }

        // GET: api/Tipo_Ocorrencia
        [HttpGet]
        public IEnumerable<Tipo_Ocorrencia> GetTipo_Ocorrencia()
        {
            return _context.Tipo_Ocorrencia;
        }

        // GET: api/Tipo_Ocorrencia/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTipo_Ocorrencia([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tipo_Ocorrencia = await _context.Tipo_Ocorrencia.FindAsync(id);

            if (tipo_Ocorrencia == null)
            {
                return NotFound();
            }

            return Ok(tipo_Ocorrencia);
        }

        // PUT: api/Tipo_Ocorrencia/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipo_Ocorrencia([FromRoute] long id, [FromBody] Tipo_Ocorrencia tipo_Ocorrencia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tipo_Ocorrencia.ID)
            {
                return BadRequest();
            }

            _context.Entry(tipo_Ocorrencia).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Tipo_OcorrenciaExists(id))
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

        // POST: api/Tipo_Ocorrencia
        [HttpPost]
        public async Task<IActionResult> PostTipo_Ocorrencia([FromBody] Tipo_Ocorrencia tipo_Ocorrencia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Tipo_Ocorrencia.Add(tipo_Ocorrencia);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTipo_Ocorrencia", new { id = tipo_Ocorrencia.ID }, tipo_Ocorrencia);
        }

        // DELETE: api/Tipo_Ocorrencia/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipo_Ocorrencia([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tipo_Ocorrencia = await _context.Tipo_Ocorrencia.FindAsync(id);
            if (tipo_Ocorrencia == null)
            {
                return NotFound();
            }

            _context.Tipo_Ocorrencia.Remove(tipo_Ocorrencia);
            await _context.SaveChangesAsync();

            return Ok(tipo_Ocorrencia);
        }

        private bool Tipo_OcorrenciaExists(long id)
        {
            return _context.Tipo_Ocorrencia.Any(e => e.ID == id);
        }
    }
}