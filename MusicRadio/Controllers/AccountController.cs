using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using MusicRadio.Dtos;
using MusicRadio.Services;


namespace MusicRadio.Controllers
{
    public class AccountController(ISecurityHandler securityHandler, IClientHandler IClientHandler) : Controller
    {
        public IActionResult Login()
        {
            if (User.Identity!.IsAuthenticated)
                return RedirectToAction("Index", "Home");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([Bind("ClientId,Password")] LoginDto loginDto, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                var result = await securityHandler.Login(loginDto, cancellationToken);
                if (result != null)
                {
                    List<Claim> claims =
                    [
                        new Claim(ClaimTypes.Name, result.Name!)
                    ];

                    ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    AuthenticationProperties properties = new AuthenticationProperties()
                    { 
                        AllowRefresh = true,
                    };
                    await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity),
                        properties);


                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    TempData["Message"] = "¡Usuario o contraseña incorrecta!";
                }
            }
            return View(loginDto);
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([Bind("Id,Password,Name,Mail,Direction,Phone")] ClientDto client, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                var result = await IClientHandler.Create(client, cancellationToken);
                TempData["SuccessMessage"] = "¡Cuenta creada exitosamente!";
                return RedirectToPage("/Account/Register");
            }
            return View();
        }
    }
}
