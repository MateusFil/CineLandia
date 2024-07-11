using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TRABALHODEFINITIVO.Data;
using TRABALHODEFINITIVO.Models;

namespace TRABALHODEFINITIVO.Controllers
{
    public class HomeController : Controller
    {
        private readonly TRABALHODEFINITIVOContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, TRABALHODEFINITIVOContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Filme.ToList());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
