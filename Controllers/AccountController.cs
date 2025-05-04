using Company.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace Company.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountController(SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model, string? returnUrl)
        {

            if (!ModelState.IsValid)  
                    return View(model);

            SignInResult result = await _signInManager.PasswordSignInAsync(model.UserName!, model.Password!, model.RememberMe, false);

            if (result.Succeeded)
                return Redirect(returnUrl ?? "/");

            ModelState.AddModelError(string.Empty, "Неверный логин или пароль");
            return View(result);

        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");

        }

        [HttpGet]
        public async Task<IActionResult> Login(string? returnUrl)
        {
            //Завершаем текущий сеанс работы перед новым логином
            await _signInManager.SignOutAsync();

            ViewBag.ReturnUrl = returnUrl;
            return View(new LoginViewModel());

        }
    }
}
 