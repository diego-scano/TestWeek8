using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TestWeek8.Core.Interfaces;
using TestWeek8.MVC.Models;

namespace TestWeek8.MVC.Controllers
{
    public class UtenteController : Controller
    {
        private readonly IMainBusinessLayer mainBL;

        public UtenteController(IMainBusinessLayer mainBL)
        {
            this.mainBL = mainBL;
        }

        public IActionResult Login(string returnURL)
        {
            return View(new UtenteViewModel { ReturnUrl = returnURL });
        }

        [HttpPost]
        public async Task<IActionResult> Login(UtenteViewModel uvm)
        {
            if (uvm == null)
            {
                return View("Error");
            }

            var user = mainBL.GetUserByEmail(uvm.Email);
            if (user != null && ModelState.IsValid)
            {
                //Verifica Password
                if (user.Password.Equals(uvm.Password))
                {
                    //UTENTE AUTENTICATO
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Email, user.Email),
                        new Claim(ClaimTypes.Role, user.Ruolo.ToString())
                    };

                    var authProperties = new AuthenticationProperties
                    {
                        ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(30),
                        RedirectUri = uvm.ReturnUrl
                    };

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity),
                        authProperties
                    );
                    return Redirect("/");
                }
                else
                {
                    ModelState.AddModelError(nameof(uvm.Password), "Password non valida");
                    return View(uvm);
                }
            }
            else
            {
                ModelState.AddModelError(nameof(uvm.Email), "Email non valida");
                return View(uvm);
            }

            return View(uvm);
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }

        public IActionResult AccessoNegato()
        {
            return View();
        }
    }
}
