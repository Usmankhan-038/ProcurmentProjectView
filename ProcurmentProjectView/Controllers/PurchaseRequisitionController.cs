using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using ProcurmentProjectView.Config;
using ProcurmentProjectView.Interfaces;
using ProcurmentProjectView.Models;
using System.Threading.Tasks;

namespace ProcurmentProjectView.Controllers
{
    public class PurchaseRequisitionController : Controller
    {
        private readonly IBaseApiService _baseApiService;

        public PurchaseRequisitionController(IBaseApiService baseApiService)
        {
            _baseApiService = baseApiService;
        }
     
        public async Task<ActionResult> PrList()
        {
            var getAllPr = ApiEndPoints.GetAllPrRequest();
            var token = User.FindFirst("AccessToken")?.Value;

            if (string.IsNullOrEmpty(token))
            {
                return RedirectToAction("Login","Login");
            }
            var response = await _baseApiService.GetApiResponse<List<PrDetailResponseModel>>(getAllPr, token);
            if (!response.Success && response.Message == "Unauthorized")
            {
                return View("Login");
            }
            else if (!response.Success)
            {
                ModelState.AddModelError("", response.Message);
                return View();
            }
            else
            {
                return View(response.Data);
            }
            
        }

        public async Task<ActionResult> Detail(int id)
        {
            var getPrById = ApiEndPoints.GetPurchasedRequisitionById(id);
            var token = User.FindFirst("AccessToken")?.Value;

            if (string.IsNullOrEmpty(token))
            {
                return View("Login");
            }

            var response = await _baseApiService.GetApiResponse<PrDetailResponseModel>(getPrById, token);
            if (!response.Success && response.Message == "Unauthorized")
            {
                return View("Login", "Login");
            }
            else if (!response.Success)
            {
                ModelState.AddModelError("", response.Message);
                return View("ViewPr");
            }
            else
            {
                return View("ViewPr", response.Data);
            }
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> SavePrResult(CreatePrRequestModel prRequestModel)
        {
            var addPurhasedRequisition = ApiEndPoints.AddPurchasedRequisition();
            var token = User.FindFirst("AccessToken")?.Value;

            if (string.IsNullOrEmpty(token))
            {
                return View("Login", "Login");
            }

            var response = await _baseApiService.PostAsync<CreatePrRequestModel, CreatePrRequestModel>(addPurhasedRequisition, prRequestModel,token);
            if(!response.Success && response.Message == "Unauthorized")
            {
                return View("Login", "Login");

            }
            else if (!response.Success)
            {
                ModelState.AddModelError("", response.Message);
                return View("Create");
            }
            else if(response.Success)
            {
                return View("PrList");

            }
            return View();
        }

        // POST: PrController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public async Task<ActionResult> Edit(int id)
        {
            var getPrById = ApiEndPoints.GetPurchasedRequisitionById(id);
            var token = User.FindFirst("AccessToken")?.Value;

            if (string.IsNullOrEmpty(token))
            {
                return View("Login","Login");
            }

            var response = await _baseApiService.GetApiResponse<PrDetailResponseModel>(getPrById, token);
            if (!response.Success && response.Message == "Unauthorized")
            {
                return View("Login","Login");
            }
            else if (!response.Success)
            {
                ModelState.AddModelError("", response.Message);
                return View("UpdatePr");
            }
            else
            {
                return View("UpdatePr", response.Data);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, PrDetailResponseModel model)
        {
            var updatePr = ApiEndPoints.UpdatePurchasedRequisition(id);
            var token = User.FindFirst("AccessToken")?.Value;

            if (string.IsNullOrEmpty(token))
            {
                return View("Login", "Login");
            }

            var response = await _baseApiService.UpdateAsync<PrDetailResponseModel, PrDetailResponseModel>(updatePr, model, token);
            if (!response.Success && response.Message == "Unauthorized")
            {
                return View("Login", "Login");
            }
            else if (!response.Success)
            {
                ModelState.AddModelError("", response.Message);
                return View("UpdatePr", model);
            }

            return RedirectToAction(nameof(PrList));
        }

       
        public async Task<ActionResult> Delete(int id)
        {
            var deletePr = ApiEndPoints.DeletePurchasedRequisition(id);
            var token = User.FindFirst("AccessToken")?.Value;

            if (string.IsNullOrEmpty(token))
            {
                return View("Login", "Login");
            }

            var response = await _baseApiService.DeleteAsync<object, string>(deletePr, token);
            if (!response.Success && response.Message == "Unauthorized")
            {
                return View("Login", "Login");
            }
            
            return RedirectToAction(nameof(PrList));
        }
    }
}
