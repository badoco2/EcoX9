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
    public class OcorrenciasController : ControllerBase
    {
        private readonly EcoX9Context _context;

        public OcorrenciasController(EcoX9Context context)
        {
            _context = context;
        }

        // GET: api/Ocorrencias
        [HttpGet]
        public IEnumerable<Ocorrencias> Gettb_ocorrencias()
        {
            return _context.tb_ocorrencias;
        }

        // GET: api/Ocorrencias/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOcorrencias([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var ocorrencias = await _context.tb_ocorrencias.FindAsync(id);

            if (ocorrencias == null)
            {
                return NotFound();
            }

            return Ok(ocorrencias);
        }

        // PUT: api/Ocorrencias/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOcorrencias([FromRoute] long id, [FromBody] Ocorrencias ocorrencias)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ocorrencias.Id)
            {
                return BadRequest();
            }

            _context.Entry(ocorrencias).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OcorrenciasExists(id))
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

        // POST: api/Ocorrencias
        [HttpPost]
        public async Task<IActionResult> PostOcorrencias([FromBody] Ocorrencias ocorrencias)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.tb_ocorrencias.Add(ocorrencias);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOcorrencias", new { id = ocorrencias.Id }, ocorrencias);
        }

        // DELETE: api/Ocorrencias/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOcorrencias([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var ocorrencias = await _context.tb_ocorrencias.FindAsync(id);
            if (ocorrencias == null)
            {
                return NotFound();
            }

            _context.tb_ocorrencias.Remove(ocorrencias);
            await _context.SaveChangesAsync();

            return Ok(ocorrencias);
        }

        private bool OcorrenciasExists(long id)
        {
            return _context.tb_ocorrencias.Any(e => e.Id == id);
        }
    }
}