using Microsoft.AspNetCore.Mvc;
using SponteLive.Models;


namespace SponteLive.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetAmountChart()
        {
            var amount = new List<int> { _context.Lives.Count(), _context.Instrutores.Count(), _context.Inscritos.Count(), _context.Inscricoes.Count() };
            return Json(amount);
        }

    }
}