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
    }
}
