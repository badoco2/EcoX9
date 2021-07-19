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
    public class Tipo_OcorrenciaController : Controller
    {
        private readonly EcoX9Context _context;

        public Tipo_OcorrenciaController(EcoX9Context context)
        {
            _context = context;
        }

        // GET: Tipo_Ocorrencia
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tipo_Ocorrencia.ToListAsync());
        }

        // GET: Tipo_Ocorrencia/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipo_Ocorrencia = await _context.Tipo_Ocorrencia
                .FirstOrDefaultAsync(m => m.ID == id);
            if (tipo_Ocorrencia == null)
            {
                return NotFound();
            }

            return View(tipo_Ocorrencia);
        }

        // GET: Tipo_Ocorrencia/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tipo_Ocorrencia/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,NOME_TIPO,DESC_TIPO")] Tipo_Ocorrencia tipo_Ocorrencia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipo_Ocorrencia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipo_Ocorrencia);
        }

        // GET: Tipo_Ocorrencia/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipo_Ocorrencia = await _context.Tipo_Ocorrencia.FindAsync(id);
            if (tipo_Ocorrencia == null)
            {
                return NotFound();
            }
            return View(tipo_Ocorrencia);
        }

        // POST: Tipo_Ocorrencia/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("ID,NOME_TIPO,DESC_TIPO")] Tipo_Ocorrencia tipo_Ocorrencia)
        {
            if (id != tipo_Ocorrencia.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipo_Ocorrencia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Tipo_OcorrenciaExists(tipo_Ocorrencia.ID))
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
            return View(tipo_Ocorrencia);
        }

        // GET: Tipo_Ocorrencia/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipo_Ocorrencia = await _context.Tipo_Ocorrencia
                .FirstOrDefaultAsync(m => m.ID == id);
            if (tipo_Ocorrencia == null)
            {
                return NotFound();
            }

            return View(tipo_Ocorrencia);
        }

        // POST: Tipo_Ocorrencia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var tipo_Ocorrencia = await _context.Tipo_Ocorrencia.FindAsync(id);
            _context.Tipo_Ocorrencia.Remove(tipo_Ocorrencia);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Tipo_OcorrenciaExists(long id)
        {
            return _context.Tipo_Ocorrencia.Any(e => e.ID == id);
        }
    }
}
