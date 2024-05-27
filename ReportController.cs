using FruitHealth.Areas.Identity.Data;
using FruitHealth.Models;
using Microsoft.AspNetCore.Mvc;

namespace FruitHealth.Controllers
{
    public class ReportController : Controller
    {
        private readonly fruitHealthContext _context;

        public ReportController(fruitHealthContext context)
        {
            _context = context;
        }

        public IActionResult PredictionReport()
        {
            List<FruitHealthPredictionResult> results = _context.FruitHealthPredictionResults.ToList();
            return View(results);
        }
    }
}
