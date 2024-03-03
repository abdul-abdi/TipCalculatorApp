using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TipCalculatorApp.Models;

namespace TipCalculatorApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
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

        [HttpPost]
        public IActionResult Calculate(TipCalculator model)
        {
            if (!ModelState.IsValid)
            {
                return View(model); // return to Calculate view 
            }

            model.CalculateTip(15);
            model.CalculateTip(20);
            model.CalculateTip(25);

            return View("Results", model); // return to Results view
        }

        public IActionResult Clear()
        {
            return RedirectToAction("Index");
        }
    }
}
