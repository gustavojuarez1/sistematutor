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
    public class retroalimentacion_preguntasController : Controller
    {
        private readonly sistematutorContext _context;

        public retroalimentacion_preguntasController(sistematutorContext context)
        {
            _context = context;
        }

        // GET: retroalimentacion_preguntas
        public async Task<IActionResult> Index()
        {
            return View(await _context.retroalimentacion_preguntas.ToListAsync());
        }

        // GET: retroalimentacion_preguntas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var retroalimentacion_preguntas = await _context.retroalimentacion_preguntas
                .SingleOrDefaultAsync(m => m.id_retroalimentacion == id);
            if (retroalimentacion_preguntas == null)
            {
                return NotFound();
            }

            return View(retroalimentacion_preguntas);
        }

        // GET: retroalimentacion_preguntas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: retroalimentacion_preguntas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_retroalimentacion,id_ejercicio,id_temas")] retroalimentacion_preguntas retroalimentacion_preguntas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(retroalimentacion_preguntas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(retroalimentacion_preguntas);
        }

        // GET: retroalimentacion_preguntas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var retroalimentacion_preguntas = await _context.retroalimentacion_preguntas.SingleOrDefaultAsync(m => m.id_retroalimentacion == id);
            if (retroalimentacion_preguntas == null)
            {
                return NotFound();
            }
            return View(retroalimentacion_preguntas);
        }

        // POST: retroalimentacion_preguntas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id_retroalimentacion,id_ejercicio,id_temas")] retroalimentacion_preguntas retroalimentacion_preguntas)
        {
            if (id != retroalimentacion_preguntas.id_retroalimentacion)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(retroalimentacion_preguntas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!retroalimentacion_preguntasExists(retroalimentacion_preguntas.id_retroalimentacion))
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
            return View(retroalimentacion_preguntas);
        }

        // GET: retroalimentacion_preguntas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var retroalimentacion_preguntas = await _context.retroalimentacion_preguntas
                .SingleOrDefaultAsync(m => m.id_retroalimentacion == id);
            if (retroalimentacion_preguntas == null)
            {
                return NotFound();
            }

            return View(retroalimentacion_preguntas);
        }

        // POST: retroalimentacion_preguntas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var retroalimentacion_preguntas = await _context.retroalimentacion_preguntas.SingleOrDefaultAsync(m => m.id_retroalimentacion == id);
            _context.retroalimentacion_preguntas.Remove(retroalimentacion_preguntas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool retroalimentacion_preguntasExists(int id)
        {
            return _context.retroalimentacion_preguntas.Any(e => e.id_retroalimentacion == id);
        }
    }
}
