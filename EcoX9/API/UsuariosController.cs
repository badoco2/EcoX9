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
    public class UsuariosController : ControllerBase
    {
        private readonly EcoX9Context _context;

        public UsuariosController(EcoX9Context context)
        {
            _context = context;
        }

        // GET: api/Usuarios
        [HttpGet]
        public IEnumerable<Usuarios> Gettb_usuarios()
        {
            return _context.tb_usuarios;
        }

        // GET: api/Usuarios/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUsuarios([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var usuarios = await _context.tb_usuarios.FindAsync(id);

            if (usuarios == null)
            {
                return NotFound();
            }

            return Ok(usuarios);
        }

        // PUT: api/Usuarios/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuarios([FromRoute] long id, [FromBody] Usuarios usuarios)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != usuarios.Id)
            {
                return BadRequest();
            }

            _context.Entry(usuarios).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuariosExists(id))
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

        // POST: api/Usuarios
        [HttpPost]
        public async Task<IActionResult> PostUsuarios([FromBody] Usuarios usuarios)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.tb_usuarios.Add(usuarios);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUsuarios", new { id = usuarios.Id }, usuarios);
        }

        // DELETE: api/Usuarios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuarios([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var usuarios = await _context.tb_usuarios.FindAsync(id);
            if (usuarios == null)
            {
                return NotFound();
            }

            _context.tb_usuarios.Remove(usuarios);
            await _context.SaveChangesAsync();

            return Ok(usuarios);
        }
        // Get verifica login
        // GET: api/Usuarios/
        [HttpGet("{email}/{senha}")]
        public bool GetLogin(string email, string senha)
        {
           return UsuariosLogin(email, senha);

        }

        private bool UsuariosExists(long id)
        {
            return _context.tb_usuarios.Any(e => e.Id == id);
        }

        private bool UsuariosLogin(string email, string senha)
        {
            if(_context.tb_usuarios.Any(e => e.EMAIL == email) != false)
            {
                if (_context.tb_usuarios.Any(e => e.SENHA == senha) != false)
                {
                    return true;
                }
            }
            return false;
        }
    }
}