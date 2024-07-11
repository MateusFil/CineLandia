using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TRABALHODEFINITIVO.Data;
using TRABALHODEFINITIVO.Models;

namespace TRABALHODEFINITIVO.Controllers
{
    public class FilmesAtoresController : Controller
    {
        private readonly TRABALHODEFINITIVOContext _context;

        public FilmesAtoresController(TRABALHODEFINITIVOContext context)
        {
            _context = context;
        }

        // GET: FilmesAtores
        public async Task<IActionResult> Index(string textoBusca)
        {
            var tRABALHODEFINITIVOContext = _context.FilmeAtores.Include(f => f.Ator).Include(f => f.Filme);
            var query = _context.FilmeAtores.AsQueryable();

            if (!string.IsNullOrEmpty(textoBusca))
            {
                query = query.Where(x => x.Personagem.Contains(textoBusca)


                );
            }


            return View(await tRABALHODEFINITIVOContext.ToListAsync());
            
        }

        // GET: FilmesAtores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filmeAtores = await _context.FilmeAtores
                .Include(f => f.Ator)
                .Include(f => f.Filme)
                .FirstOrDefaultAsync(m => m.FilmeAtoresId == id);
            if (filmeAtores == null)
            {
                return NotFound();
            }

            return View(filmeAtores);
        }

        // GET: FilmesAtores/Create
        public IActionResult Create()
        {
            ViewData["AtorId"] = new SelectList(_context.Artista, "AtorId", "AtorId");
            ViewData["FilmeId"] = new SelectList(_context.Filme, "FilmeId", "Titulo");
            return View();
        }

        // POST: FilmesAtores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FilmeAtoresId,FilmeId,AtorId,Personagem")] FilmeAtores filmeAtores)
        {
            if (ModelState.IsValid)
            {
                _context.Add(filmeAtores);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AtorId"] = new SelectList(_context.Artista, "AtorId", "AtorId", filmeAtores.AtorId);
            ViewData["FilmeId"] = new SelectList(_context.Filme, "FilmeId", "Titulo", filmeAtores.FilmeId);
            return View(filmeAtores);
        }

        // GET: FilmesAtores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filmeAtores = await _context.FilmeAtores.FindAsync(id);
            if (filmeAtores == null)
            {
                return NotFound();
            }
            ViewData["AtorId"] = new SelectList(_context.Artista, "AtorId", "AtorId", filmeAtores.AtorId);
            ViewData["FilmeId"] = new SelectList(_context.Filme, "FilmeId", "Titulo", filmeAtores.FilmeId);
            return View(filmeAtores);
        }

        // POST: FilmesAtores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FilmeAtoresId,FilmeId,AtorId,Personagem")] FilmeAtores filmeAtores)
        {
            if (id != filmeAtores.FilmeAtoresId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(filmeAtores);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FilmeAtoresExists(filmeAtores.FilmeAtoresId))
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
            ViewData["AtorId"] = new SelectList(_context.Artista, "AtorId", "AtorId", filmeAtores.AtorId);
            ViewData["FilmeId"] = new SelectList(_context.Filme, "FilmeId", "Titulo", filmeAtores.FilmeId);
            return View(filmeAtores);
        }

        // GET: FilmesAtores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filmeAtores = await _context.FilmeAtores
                .Include(f => f.Ator)
                .Include(f => f.Filme)
                .FirstOrDefaultAsync(m => m.FilmeAtoresId == id);
            if (filmeAtores == null)
            {
                return NotFound();
            }

            return View(filmeAtores);
        }

        // POST: FilmesAtores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var filmeAtores = await _context.FilmeAtores.FindAsync(id);
            if (filmeAtores != null)
            {
                _context.FilmeAtores.Remove(filmeAtores);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FilmeAtoresExists(int id)
        {
            return _context.FilmeAtores.Any(e => e.FilmeAtoresId == id);
        }
    }
}
