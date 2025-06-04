using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicRadio.Infrastructure.DbContexts;
using MusicRadio.Models;
using MusicRadio.Services;

namespace MusicRadio.Controllers
{
    public class AlbumSetsController : Controller
    {
        private readonly MusicRadioDbContext _context;
        private readonly IAlbumSetHandler _albumSetHandler;

        public AlbumSetsController(MusicRadioDbContext context, IAlbumSetHandler albumSetHandler)
        {
            _context = context;
            _albumSetHandler = albumSetHandler;
        }

        // GET: AlbumSets
        public async Task<IActionResult> Index()
        {
            return View(await _context.AlbumSets.ToListAsync());
        }

        // GET: AlbumSets/Details/5
        public async Task<IActionResult> Details(int? id, CancellationToken cancellationToken)
        {
            if (id == null)
            {
                return NotFound();
            }

            var result = await _albumSetHandler.GetById(id!.Value, cancellationToken);
            if (result == null)
            {
                return NotFound();
            }

            return View(result);
        }

        // GET: AlbumSets/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AlbumSets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] AlbumSet albumSet)
        {
            if (ModelState.IsValid)
            {
                _context.Add(albumSet);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(albumSet);
        }

        // GET: AlbumSets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var albumSet = await _context.AlbumSets.FindAsync(id);
            if (albumSet == null)
            {
                return NotFound();
            }
            return View(albumSet);
        }

        // POST: AlbumSets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] AlbumSet albumSet)
        {
            if (id != albumSet.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(albumSet);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlbumSetExists(albumSet.Id))
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
            return View(albumSet);
        }

        // GET: AlbumSets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var albumSet = await _context.AlbumSets
                .FirstOrDefaultAsync(m => m.Id == id);
            if (albumSet == null)
            {
                return NotFound();
            }

            return View(albumSet);
        }

        // POST: AlbumSets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var albumSet = await _context.AlbumSets.FindAsync(id);
            if (albumSet != null)
            {
                _context.AlbumSets.Remove(albumSet);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlbumSetExists(int id)
        {
            return _context.AlbumSets.Any(e => e.Id == id);
        }
    }
}
