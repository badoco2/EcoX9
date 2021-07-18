using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EcoX9.Data;
using EcoX9.Models;

namespace EcoX9.Controllers
{
    public class OcorrenciasController : Controller
    {
        private readonly EcoX9Context _context;

        public OcorrenciasController(EcoX9Context context)
        {
            _context = context;
        }

        // GET: Ocorrencias
        public async Task<IActionResult> Index()
        {
            var ecoX9Context = _context.tb_ocorrencias.Include(o => o.Usuarios);
            return View(await ecoX9Context.ToListAsync());
        }

        // GET: Ocorrencias/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ocorrencias = await _context.tb_ocorrencias
                .Include(o => o.Usuarios)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ocorrencias == null)
            {
                return NotFound();
            }

            return View(ocorrencias);
        }

        // GET: Ocorrencias/Create
        public IActionResult Create()
        {
            ViewData["UsuariosId"] = new SelectList(_context.tb_usuarios, "Id", "Id");
            return View();
        }

        // POST: Ocorrencias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,COD_OCO,DESC_OCO,DT_OCO,FOTO,FLAG_SIT,FLAG,UsuariosId")] Ocorrencias ocorrencias)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ocorrencias);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UsuariosId"] = new SelectList(_context.tb_usuarios, "Id", "Id", ocorrencias.UsuariosId);
            return View(ocorrencias);
        }

        // GET: Ocorrencias/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ocorrencias = await _context.tb_ocorrencias.FindAsync(id);
            if (ocorrencias == null)
            {
                return NotFound();
            }
            ViewData["UsuariosId"] = new SelectList(_context.tb_usuarios, "Id", "Id", ocorrencias.UsuariosId);
            return View(ocorrencias);
        }

        // POST: Ocorrencias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,COD_OCO,DESC_OCO,DT_OCO,FOTO,FLAG_SIT,FLAG,UsuariosId")] Ocorrencias ocorrencias)
        {
            if (id != ocorrencias.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ocorrencias);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OcorrenciasExists(ocorrencias.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["UsuariosId"] = new SelectList(_context.tb_usuarios, "Id", "Id", ocorrencias.UsuariosId);
            return View(ocorrencias);
        }

        // GET: Ocorrencias/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ocorrencias = await _context.tb_ocorrencias
                .Include(o => o.Usuarios)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ocorrencias == null)
            {
                return NotFound();
            }

            return View(ocorrencias);
        }

        // POST: Ocorrencias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var ocorrencias = await _context.tb_ocorrencias.FindAsync(id);
            _context.tb_ocorrencias.Remove(ocorrencias);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OcorrenciasExists(long id)
        {
            return _context.tb_ocorrencias.Any(e => e.Id == id);
        }
    }
}
