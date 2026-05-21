using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProcurmentProjectView.Config;
using ProcurmentProjectView.Interfaces;
using ProcurmentProjectView.Models;

namespace ProcurmentProjectView.Controllers
{
    public class ProductController : Controller
    {
        private readonly IBaseApiService _baseApiService;
        public ProductController(IBaseApiService baseApiService) 
        {
            _baseApiService = baseApiService;
        }

        [HttpGet]
        public async Task<IActionResult> ProductList()
        {
            var getProduct = ApiEndPoints.ProductList();
            var token =  User.FindFirst("AccessToken")?.Value ?? "";
            var response = await _baseApiService.GetApiResponse<List<ProductModel>>(getProduct, token);

            if(response.Success)
            {
                return View(response.Data);
            }
            return View(null);
        }
    }
}
