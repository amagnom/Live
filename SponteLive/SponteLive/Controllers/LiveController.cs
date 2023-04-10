using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SponteLive.Models;

namespace SponteLive.Controllers
{
    public class LiveController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LiveController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Live
        public async Task<IActionResult> Index()
        {
            return View(await _context.Lives.ToListAsync());
        }

        // GET: Live/Details/id
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var live = await _context.Lives
                .Include(l => l.Instrutor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (live == null)
            {
                return NotFound();
            }

            return View(live);
        }

        // GET: Live/Create
        public IActionResult Create()
        {

            if (!InstrutoresExists())
            {
                ModelState.AddModelError("", "Não existem instrutores cadastrados. Cadastre um instrutor antes de criar uma nova live.");
                return View("Index", _context.Lives.ToList());
            }

            List<Instrutor> instrutores = _context.Instrutores.ToList();
            ViewData["Instrutores"] = instrutores;
            return View();
        }

        // POST: Live/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Live live)
        {

            if (ModelState.IsValid)
            {
                _context.Add(live);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            List<Instrutor> instrutores = _context.Instrutores.ToList();
            ViewData["Instrutores"] = instrutores;
            return View(live);
        }

        // GET: Live/Edit/id
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var live = await _context.Lives.FindAsync(id);
            if (live == null)
            {
                return NotFound();
            }
            List<Instrutor> instrutores = _context.Instrutores.ToList();
            ViewData["Instrutores"] = instrutores;

            return View(live);
        }

        // POST: Live/Edit/id
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Live live)
        {
            if (id != live.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(live);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LivesExists(live.Id))
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
            List<Instrutor> instrutores = _context.Instrutores.ToList();
            ViewData["Instrutores"] = instrutores;

            return View(live);
        }

        // GET: Live/Delete/id
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var live = await _context.Lives
                .Include(l => l.Instrutor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (live == null)
            {
                return NotFound();
            }

            return View(live);
        }

        // POST: Live/Delete/id
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var live = await _context.Lives.FindAsync(id);


            if (live == null)
            {
                return NotFound();
            }

            bool hasInscricoes = await _context.Inscricoes.AnyAsync(i => i.LiveId == id);
            if (hasInscricoes)
            {
                var lives = await _context.Lives.ToListAsync();
                ModelState.AddModelError(string.Empty, "Esta live está sendo referenciado por uma ou mais inscrições e não pode ser excluído.");
                return View(nameof(Index), lives);
            }

            try
            {
                _context.Lives.Remove(live);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException /* ex */)
            {
                // Log the error (uncomment ex variable name and write a log.)
                ModelState.AddModelError(string.Empty, "Não foi possível excluir a live. Tente novamente, e se o problema persistir, consulte o administrador do sistema.");
                return RedirectToAction(nameof(Index), new { id, saveChangesError = true });
            }


        }


        private bool InstrutoresExists()
        {
            return _context.Instrutores.Any();
        }

        private bool LivesExists(int id)
        {
            return _context.Lives.Any(e => e.Id == id);
        }

    }

}