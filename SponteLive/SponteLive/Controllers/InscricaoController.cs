using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SponteLive.Models;

namespace SponteLive.Controllers
{
    public class InscricaoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InscricaoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Inscricao
        public async Task<IActionResult> Index()
        {
            return View(await _context.Inscricoes.Include(i => i.Inscrito).Include(i => i.Live).ToListAsync());
        }

        // GET: Inscricao/Details/id
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inscricao = await _context.Inscricoes
                .Include(i => i.Inscrito)
                .Include(i => i.Live)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (inscricao == null)
            {
                return NotFound();
            }

            return View(inscricao);
        }

        // GET: Inscricao/Create
        public IActionResult Create()
        {

            if (!InscritosExists() || !LivesExists())
            {
                ModelState.AddModelError("", "Você precisa ter inscritos e lives criadas antes de criar uma nova Inscricao.");
                return View("Index", _context.Inscricoes.ToList());
            }

            List<Inscrito> inscritos = _context.Inscritos.ToList();
            List<Live> lives = _context.Lives.ToList();
            ViewData["Inscritos"] = inscritos;
            ViewData["Lives"] = lives;

            return View();
        }

        // POST: Inscricao/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Inscricao inscricao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(inscricao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            List<Inscrito> inscritos = _context.Inscritos.ToList();
            List<Live> lives = _context.Lives.ToList();
            ViewData["Inscritos"] = inscritos;
            ViewData["Lives"] = lives;

            return View(inscricao);
        }


        // GET: Inscricao/Edit/id
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inscricao = _context.Inscricoes.Find(id);
            if (inscricao == null)
            {
                return NotFound();
            }

            return View(inscricao);
        }

        // POST: Inscricao/Edit/id
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, bool statusPagamento)
        {
            var inscricao = _context.Inscricoes.Find(id);

            if (inscricao == null)
            {
                return NotFound();
            }

            inscricao.StatusPagamento = statusPagamento;

            _context.Inscricoes.Update(inscricao);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }


        // GET: Inscricao/Delete/id
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inscricao = _context.Inscricoes
                .Include(i => i.Inscrito)
                .Include(i => i.Live)
                .FirstOrDefault(m => m.Id == id);
            if (inscricao == null)
            {
                return NotFound();
            }

            return View(inscricao);
        }

        // POST: Inscricao/Delete/id
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var inscricao = _context.Inscricoes.Find(id);
            if (inscricao != null) _context.Inscricoes.Remove(inscricao);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public IActionResult GerarLinhaDigitavel(int id)
        {

            var inscricao = _context.Inscricoes.FirstOrDefault(i => i.Id == id);

            // calcula o fator de vencimento
            if (inscricao != null)
            {
                var fatorVencimento = CalcularFatorVencimento(inscricao.DataVencimento).ToString();

                // constrói a linha digitável
                // Formata o valor do boleto como uma string de 10 caracteres preenchidos com zeros à esquerda, se necessário.
                // Formata o valor do boleto com duas casas decimais e remove o ponto e a vírgula
                // Formata o valor do boleto como uma string com duas casas decimais e substitui "," por "."
                string valorFormatado = inscricao.Valor.ToString("N2").Replace(",", ".");

                // Remove os separadores de milhares e preenche com zeros à esquerda até ter 11 caracteres (o último é o ponto decimal)
                valorFormatado = valorFormatado.Replace(".", "").PadLeft(10, '0');

                // Formata o fator de vencimento como uma string com 4 caracteres e preenche com zeros à esquerda, se necessário.
                string fatorVencimentoFormatado = fatorVencimento.PadLeft(4, '0');

                // Monta a linha digitável com as partes 1 a 4 zeradas, o fator de vencimento e o valor do boleto formatado
                string linhaDigitavel =
                    $"00000.00000 00000.000000 00000.000000 0 {fatorVencimentoFormatado}{valorFormatado}";


                return Ok(linhaDigitavel);
            }

            return NotFound();
        }

        private int CalcularFatorVencimento(DateTime dataVencimento)
        {
            var dataBase = new DateTime(1997, 10, 7);
            var dias = (dataVencimento - dataBase).Days;
            return dias;
        }



        private bool InscritosExists()
        {
            return _context.Inscritos.Any();
        }

        private bool LivesExists()
        {
            return _context.Lives.Any();
        }
    }
}