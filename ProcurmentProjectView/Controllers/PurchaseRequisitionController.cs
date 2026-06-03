using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProcurmentProjectView.Controllers
{
    public class PurchaseRequisitionController : Controller
    {
        // GET: PrController
        public ActionResult PrDetail()
        {
            return View();
        }

        // GET: PrController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PrController/Create
        public ActionResult Create()
        {
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

        // GET: PrController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PrController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: PrController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PrController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
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
    }
}
