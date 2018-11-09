using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using sistematutor.Models;

namespace sistematutor.Controllers
{
    public class resultadosController : Controller
    {
        private readonly sistematutorContext _context;

        public resultadosController(sistematutorContext context)
        {
            _context = context;
        }

        // GET: resultados
        public async Task<IActionResult> Index()
        {
            return View(await _context.resultados.ToListAsync());
        }

        // GET: resultados/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resultados = await _context.resultados
                .SingleOrDefaultAsync(m => m.id_resultados == id);
            if (resultados == null)
            {
                return NotFound();
            }

            return View(resultados);
        }

        // GET: resultados/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: resultados/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_resultados,id_respuestas_correctas,id_respuestas_incorrectas,id_ejercicio,id_usuario")] resultados resultados)
        {
            if (ModelState.IsValid)
            {
                _context.Add(resultados);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(resultados);
        }

        // GET: resultados/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resultados = await _context.resultados.SingleOrDefaultAsync(m => m.id_resultados == id);
            if (resultados == null)
            {
                return NotFound();
            }
            return View(resultados);
        }

        // POST: resultados/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id_resultados,id_respuestas_correctas,id_respuestas_incorrectas,id_ejercicio,id_usuario")] resultados resultados)
        {
            if (id != resultados.id_resultados)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(resultados);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!resultadosExists(resultados.id_resultados))
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
            return View(resultados);
        }

        // GET: resultados/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resultados = await _context.resultados
                .SingleOrDefaultAsync(m => m.id_resultados == id);
            if (resultados == null)
            {
                return NotFound();
            }

            return View(resultados);
        }

        // POST: resultados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var resultados = await _context.resultados.SingleOrDefaultAsync(m => m.id_resultados == id);
            _context.resultados.Remove(resultados);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool resultadosExists(int id)
        {
            return _context.resultados.Any(e => e.id_resultados == id);
        }
    }
}
