using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using ProcurmentProjectView.Interfaces;
using ProcurmentProjectView.Models;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ProcurmentProjectView.Controllers
{
    public class LoginController : Controller
    {
        private readonly IAuthService _authService;
        public LoginController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View("Login");
        }
        [HttpPost]
        public async Task<ActionResult> Login(LoginViewModel login)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var response = await _authService.AuthenticationAsync(login);
            if (response != null && !string.IsNullOrEmpty(response.Data))
            {
                var claims = new List<Claim>
                {
                    new Claim("AccessToken",response.Data)
                };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));
                return RedirectToAction("Index", "Home");
            } else if (!response.Success)
            {
                ModelState.AddModelError("", response.Message);
                return View("Login");
            }
            ModelState.AddModelError("", "Something wents wrong. Please Try again sometime later");
                
            return View("Login");
        }

    }
}
