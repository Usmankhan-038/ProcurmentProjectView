using Microsoft.AspNetCore.Mvc;
using ProcurmentProjectView.Config;
using ProcurmentProjectView.DTOs;
using ProcurmentProjectView.Interfaces;
using ProcurmentProjectView.Models;
using System.Diagnostics;
using System.Threading.Tasks;

namespace ProcurmentProjectView.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBaseApiService _baseApiService;
        public HomeController(ILogger<HomeController> logger, IBaseApiService baseApiService)
        {

            _logger = logger;
            _baseApiService = baseApiService;
        }

        public async Task<IActionResult> Index()
        {
            var getPrDetail = ApiEndPoints.PrDetail();
            var token = User.FindFirst("AccessToken")?.Value;
            if (string.IsNullOrEmpty(token))
            {
                return View("Login");
            }

            var response = await _baseApiService.GetApiResponse<PrDataDto>(getPrDetail,token);
            if (!response.Success && response.Message == "Unauthorized")
            {
                return RedirectToAction("Login", "Login");
            }
            if (response.Success)
            {
                return View(response.Data); // Pass PrDataDto to the view
            }
            return View();
        }

       

        public IActionResult Privacy()
        {
            return View("PurchaseReqi");
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
