using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProcurmentProjectView.Config;
using ProcurmentProjectView.Interfaces;
using ProcurmentProjectView.Models;
using System.Diagnostics.Contracts;

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
            var token = User.FindFirst("AccessToken")?.Value;
            if (string.IsNullOrWhiteSpace(token))
            {
                return RedirectToAction("Login", "Login");
            }

            var response = await _baseApiService.GetApiResponse<List<ProductModel>>(getProduct, token);

            if (!response.Success && response.Message == "Unauthorized")
            {
                return RedirectToAction("Login", "Login");
            }

            if (response.Success)
            {
                return View(response.Data);
            }
            return View(null);
        }
        [HttpGet]
        public IActionResult AddProduct()
        {
            var token = User.FindFirst("AccessToken")?.Value;
            if (string.IsNullOrWhiteSpace(token))
            {
                return RedirectToAction("Login", "Login");
            }

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SaveProduct(ProductModel prod)
        {
            var addProductApiUrl = ApiEndPoints.AddProduct();
            var token = User.FindFirst("AccessToken")?.Value;
            if (string.IsNullOrWhiteSpace(token))
            {
                return RedirectToAction("Login", "Login");
            }

            var response = await _baseApiService.PostAsync<ProductModel, ProductModel>(addProductApiUrl, prod, token);
            if (!response.Success && response.Message == "Unauthorized")
            {
                return RedirectToAction("Login", "Login");
            }

            if(response.Success)
            {
                return RedirectToAction("ProductList");
            }
            ModelState.AddModelError("", response.Message);
            return View("AddProduct");
        }
        [HttpGet]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var deleteProductApiUrl = ApiEndPoints.deleteProduct();
            var token = User.FindFirst("AccessToken")?.Value;
            if (string.IsNullOrWhiteSpace(token))
            {
                return RedirectToAction("Login", "Login");
            }
            var queryUrl = deleteProductApiUrl + $"?prodId={id}";
            var response = await _baseApiService.DeleteAsync<ProductModel, ProductModel>(queryUrl, token);

            if (!response.Success && response.Message == "Unauthorized")
            {
                return RedirectToAction("Login", "Login");
            }

            if (response.Success)
            {
                return RedirectToAction("ProductList");
            }

            ModelState.AddModelError("", response.Message);
            return RedirectToAction("ProductList");
        }
        [HttpGet]
        public async Task<IActionResult> ViewProduct(int id)
        {
            var getProductById = ApiEndPoints.GetProductById(id);
            var token = User.FindFirst("AccessToken")?.Value;

            if (string.IsNullOrWhiteSpace(token))
            {
                return RedirectToAction("Login", "Login");
            }

            var response = await _baseApiService.GetApiResponse<ProductModel>(getProductById, token);
            if(!response.Success && response.Message=="Unauthorized")
            {
                return RedirectToAction("Login", "Login");
            }
            if (response.Success)
            {
                return View(response.Data);
            }
            return RedirectToAction("ProductList", "ProductList");
           
        }

        [HttpGet]
        public async Task<IActionResult> UpdateProduct(int id)
        {
            var getProductById = ApiEndPoints.GetProductById(id);
            var token = User.FindFirst("AccessToken")?.Value;

            if (string.IsNullOrWhiteSpace(token))
            {
                return RedirectToAction("Login", "Login");
            }

            var response = await _baseApiService.GetApiResponse<ProductModel>(getProductById, token);
            if (!response.Success && response.Message == "Unauthorized")
            {
                return RedirectToAction("Login", "Login");
            }
            if (response.Success)
            {
                return View(response.Data);
            }
            return RedirectToAction("ProductList", "Product");
        }

        [HttpPost]
        public async Task<IActionResult> EditProduct(ProductModel prod)
        {
            var updateProduct = ApiEndPoints.UpdateProductById(prod.Id);
            var token = User.FindFirst("AccessToken")?.Value;

            if (string.IsNullOrWhiteSpace(token))
            {
                return RedirectToAction("Login", "Login");
            }

            var response = await _baseApiService.UpdateAsync<ProductModel,ProductModel>(updateProduct,prod, token);
            if (!response.Success && response.Message == "Unauthorized")
            {
                return RedirectToAction("Login", "Login");
            }
            if (response.Success)
            {
                return RedirectToAction("ProductList");
            }
            return RedirectToAction("ProductList", "Product");


        }
    }
}
