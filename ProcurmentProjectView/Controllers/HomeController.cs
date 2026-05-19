using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ProcurmentProjectView.Models;

namespace ProcurmentProjectView.Controllers
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
            return View("PurchaseReqi");
        }

        public IActionResult AddProduct()
        {
            return View();
        }

        public IActionResult ProductList()
        {
            return View();
        }

        public IActionResult ViewProduct()
        {
            return View();
        }

        public IActionResult UpdateProduct()
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
