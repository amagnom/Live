using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SponteLive.Models;

namespace SponteLive.Controllers
{
    public class InstrutorController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InstrutorController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Instrutores
        public async Task<IActionResult> Index()
        {
            return View(await _context.Instrutores.ToListAsync());
        }

        // GET: Instrutores/Details/id
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instrutor = await _context.Instrutores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (instrutor == null)
            {
                return NotFound();
            }

            return View(instrutor);
        }

        // GET: Instrutores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Instrutores/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Instrutor instrutor)
        {
            if (ModelState.IsValid)
            {
                var instrutores = await _context.Instrutores.ToListAsync();

                if (_context.Instrutores.Any(i => i.Email == instrutor.Email))
                {
                    ModelState.AddModelError(string.Empty, "Já existe um instrutor com esse e-mail cadastrado.");
                    return View(nameof(Index), instrutores);
                }

                if (_context.Instrutores.Any(i => i.InstagramUrl == instrutor.InstagramUrl))
                {
                    ModelState.AddModelError(string.Empty, "Já existe um inscrito com esse instagram cadastrado.");
                    return View(nameof(Index), instrutores);
                }


                _context.Add(instrutor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(instrutor);
        }

        // GET: Instrutores/Edit/id
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instrutor = await _context.Instrutores.FindAsync(id);
            if (instrutor == null)
            {
                return NotFound();
            }
            return View(instrutor);
        }

        // POST: Instrutores/Edit/id
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Instrutor instrutor)
        {
            if (id != instrutor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {

                var instrutores = await _context.Instrutores.ToListAsync();

                if (_context.Instrutores.Any(i => i.Email == instrutor.Email))
                {
                    ModelState.AddModelError(string.Empty, "Já existe um instrutor com esse e-mail cadastrado.");
                    return View(nameof(Index), instrutores);
                }

                if (_context.Instrutores.Any(i => i.InstagramUrl == instrutor.InstagramUrl))
                {
                    ModelState.AddModelError(string.Empty, "Já existe um inscrito com esse instagram cadastrado.");
                    return View(nameof(Index), instrutores);
                }


                try
                {
                    _context.Update(instrutor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InstrutoresExists(instrutor.Id))
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
            return View(instrutor);
        }

        // GET: Instrutores/Delete/id
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instrutor = await _context.Instrutores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (instrutor == null)
            {
                return NotFound();
            }

            return View(instrutor);
        }

        // POST: Instrutores/Delete/id
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var instrutor = await _context.Instrutores.FindAsync(id);

            if (instrutor == null)
            {
                return NotFound();
            }

            // verificação de referências
            bool hasLives = await _context.Lives.AnyAsync(i => i.InstrutorId == id);
            if (hasLives)
            {
                var instrutores = await _context.Instrutores.ToListAsync();
                ModelState.AddModelError(string.Empty, "Este instrutor está sendo referenciado por uma ou mais lives e não pode ser excluído.");
                return View(nameof(Index), instrutores);
            }

            try
            {
                _context.Instrutores.Remove(instrutor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException /* ex */)
            {
                // Log the error (uncomment ex variable name and write a log.)
                ModelState.AddModelError(string.Empty, "Não foi possível excluir o instrutor. Tente novamente, e se o problema persistir, consulte o administrador do sistema.");
                return RedirectToAction(nameof(Index), new { id, saveChangesError = true });
            }
        }

        private bool InstrutoresExists(int id)
        {
            return _context.Instrutores.Any(e => e.Id == id);
        }
    }

}