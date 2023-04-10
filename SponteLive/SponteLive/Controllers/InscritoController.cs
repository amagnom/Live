using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SponteLive.Models;

namespace SponteLive.Controllers
{
    public class InscritoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InscritoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Inscritos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Inscritos.ToListAsync());
        }

        // GET: Instrutores/Details/id
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inscrito = await _context.Inscritos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (inscrito == null)
            {
                return NotFound();
            }

            return View(inscrito);
        }


        // GET: Inscritos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Inscritos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Inscrito inscrito)
        {
            if (ModelState.IsValid)
            {
                var inscritos = await _context.Inscritos.ToListAsync();

                if (_context.Inscritos.Any(i => i.Email == inscrito.Email))
                {
                    ModelState.AddModelError(string.Empty, "Já existe um inscrito com esse e-mail cadastrado.");
                    return View(nameof(Index), inscritos);
                }

                if (_context.Inscritos.Any(i => i.InstagramUrl == inscrito.InstagramUrl))
                {
                    ModelState.AddModelError(string.Empty, "Já existe um inscrito com esse instagram cadastrado.");
                    return View(nameof(Index), inscritos);
                }

                _context.Add(inscrito);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(inscrito);
        }

        // GET: Inscritos/Edit/id
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inscrito = await _context.Inscritos.FindAsync(id);
            if (inscrito == null)
            {
                return NotFound();
            }
            return View(inscrito);
        }

        // POST: Inscritos/Edit/id
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Inscrito inscrito)
        {
            if (id != inscrito.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {

                var inscritos = await _context.Inscritos.ToListAsync();

                if (_context.Inscritos.Any(i => i.Email == inscrito.Email))
                {
                    ModelState.AddModelError(string.Empty, "Já existe um inscrito com esse e-mail cadastrado.");
                    return View(nameof(Index), inscritos);
                }

                if (_context.Inscritos.Any(i => i.InstagramUrl == inscrito.InstagramUrl))
                {
                    ModelState.AddModelError(string.Empty, "Já existe um inscrito com esse instagram cadastrado.");
                    return View(nameof(Index), inscritos);
                }



                try
                {
                    _context.Update(inscrito);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InscritoExists(inscrito.Id))
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
            return View(inscrito);
        }

        // GET: Inscritos/Delete/id
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inscrito = await _context.Inscritos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (inscrito == null)
            {
                return NotFound();
            }

            return View(inscrito);
        }

        // POST: Inscritos/Delete/id
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var inscrito = await _context.Inscritos.FindAsync(id);

            if (inscrito == null)
            {
                return NotFound();
            }

            bool hasInscricoes = await _context.Inscricoes.AnyAsync(i => i.InscritoId == id);
            if (hasInscricoes)
            {
                var inscritos = await _context.Inscritos.ToListAsync();
                ModelState.AddModelError(string.Empty, "Este inscrito está sendo referenciado por uma ou mais inscrições e não pode ser excluído.");
                return View(nameof(Index), inscritos);
            }

            try
            {
                _context.Inscritos.Remove(inscrito);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError(string.Empty, "Não foi possível excluir o inscrito. Tente novamente, e se o problema persistir, consulte o administrador do sistema.");
                return RedirectToAction(nameof(Index), new { id, saveChangesError = true });
            }


        }

        private bool InscritoExists(int id)
        {
            return _context.Inscritos.Any(e => e.Id == id);
        }
    }
}
