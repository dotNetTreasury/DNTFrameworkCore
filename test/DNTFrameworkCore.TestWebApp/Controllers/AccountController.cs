using System;
using System.Threading.Tasks;
using DNTFrameworkCore.TestWebApp.Authentication;
using DNTFrameworkCore.TestWebApp.Models;
using DNTFrameworkCore.Web.Filters;
using DNTFrameworkCore.Web.Mvc.PRG;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DNTFrameworkCore.TestWebApp.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly IAuthenticationService _service;

        public AccountController(IAuthenticationService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        [HttpGet, AllowAnonymous, ImportModelState, NoBrowserCache]
        public IActionResult Login(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost, AllowAnonymous, ExportModelState]
        public async Task<IActionResult> Login(LoginModel model, string returnUrl = null)
        {
            if (!ModelState.IsValid) return RedirectToAction(nameof(Login), new {ReturnUrl = returnUrl});

            var result = await _service.SignInAsync(model.UserName, model.Password);
            if (!result.Failed)
            {
                if (Url.IsLocalUrl(returnUrl))
                {
                    return Redirect(returnUrl);
                }

                return RedirectToAction(nameof(HomeController.Index), "Home");
            }

            ModelState.AddModelError(string.Empty, result.Message);

            return RedirectToAction(nameof(Login), new {ReturnUrl = returnUrl});
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _service.SignOutAsync();

            return RedirectToAction(nameof(Login));
        }
    }
}