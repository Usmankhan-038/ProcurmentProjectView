using Microsoft.AspNetCore.Mvc;

namespace ProcurmentProjectView.Controllers
{
    public class RequestForQuotationController : Controller
    {
        public IActionResult Create()
        {
            return View();
        }

        public IActionResult RfqList()
        {
            return View();
        }

        public IActionResult RfqDetail()
        {
            return View();
        }

        public async Task<ActionResult> SendEmail(int id)
        {
            // Placeholder for Send Email logic
            TempData["Message"] = "Email sent successfully for RFQ ID: " + id;
            return RedirectToAction(nameof(RfqList));
        }
    }
}
