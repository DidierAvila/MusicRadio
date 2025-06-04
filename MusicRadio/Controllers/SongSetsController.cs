using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicRadio.Infrastructure.DbContexts;
using MusicRadio.Models;

namespace MusicRadio.Controllers
{
    public class SongSetsController : Controller
    {
        private readonly MusicRadioDbContext _context;

        public SongSetsController(MusicRadioDbContext context)
        {
            _context = context;
        }

        // GET: SongSets
        public async Task<IActionResult> Index()
        {
            return View(await _context.SongSets.ToListAsync());
        }

        // GET: SongSets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var songSet = await _context.SongSets
                .FirstOrDefaultAsync(m => m.Id == id);
            if (songSet == null)
            {
                return NotFound();
            }

            return View(songSet);
        }

        // GET: SongSets/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SongSets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,AlbumId")] SongSet songSet)
        {
            if (ModelState.IsValid)
            {
                _context.Add(songSet);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(songSet);
        }

        // GET: SongSets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var songSet = await _context.SongSets.FindAsync(id);
            if (songSet == null)
            {
                return NotFound();
            }
            return View(songSet);
        }

        // POST: SongSets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,AlbumId")] SongSet songSet)
        {
            if (id != songSet.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(songSet);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SongSetExists(songSet.Id))
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
            return View(songSet);
        }

        // GET: SongSets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var songSet = await _context.SongSets
                .FirstOrDefaultAsync(m => m.Id == id);
            if (songSet == null)
            {
                return NotFound();
            }

            return View(songSet);
        }

        // POST: SongSets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var songSet = await _context.SongSets.FindAsync(id);
            if (songSet != null)
            {
                _context.SongSets.Remove(songSet);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SongSetExists(int id)
        {
            return _context.SongSets.Any(e => e.Id == id);
        }
    }
}
