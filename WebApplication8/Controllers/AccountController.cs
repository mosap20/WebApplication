using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApplication8.Models;

namespace WebApplication8.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<WebApplication> _userManager;
        private readonly SignInManager<WebApplication> _signInManager;

        public AccountController(UserManager<WebApplication> userManager, SignInManager<WebApplication> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost]
        public async Task<IActionResult> Login(ErrorViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user != null)
                {
                    if (await _userManager.CheckPasswordAsync(user, model.MotDePasse))
                    {
                        if (user.Role == "Prof")
                        {
                            return RedirectToAction("Index", "Prof");
                        }
                        else if (user.Role == "Etudiant")
                        {
                            return RedirectToAction("Index", "Etudiant");
                        }
                    }
                }
            }
            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            return View(model);
        }
    }
}
