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
    public class ArtistasController : Controller
    {
        private readonly TRABALHODEFINITIVOContext _context;

        public ArtistasController(TRABALHODEFINITIVOContext context)
        {
            _context = context;
        }

        // GET: Artistas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Artista.ToListAsync());
        }

        // GET: Artistas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var artista = await _context.Artista
                .FirstOrDefaultAsync(m => m.AtorId == id);
            if (artista == null)
            {
                return NotFound();
            }

            return View(artista);
        }

        // GET: Artistas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Artistas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AtorId,Nome,DataNascimento,PaisNascimento,Foto")] Artista artista)
        {
            if (ModelState.IsValid)
            {
                _context.Add(artista);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(artista);
        }

        // GET: Artistas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var artista = await _context.Artista.FindAsync(id);
            if (artista == null)
            {
                return NotFound();
            }
            return View(artista);
        }

        // POST: Artistas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AtorId,Nome,DataNascimento,PaisNascimento,Foto")] Artista artista)
        {
            if (id != artista.AtorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(artista);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArtistaExists(artista.AtorId))
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
            return View(artista);
        }

        // GET: Artistas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var artista = await _context.Artista
                .FirstOrDefaultAsync(m => m.AtorId == id);
            if (artista == null)
            {
                return NotFound();
            }

            return View(artista);
        }

        // POST: Artistas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var artista = await _context.Artista.FindAsync(id);
            if (artista != null)
            {
                _context.Artista.Remove(artista);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArtistaExists(int id)
        {
            return _context.Artista.Any(e => e.AtorId == id);
        }
    }
}
