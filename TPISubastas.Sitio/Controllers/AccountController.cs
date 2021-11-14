using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TPISubastas.AccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TPISubastas.Sitio.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<Security.SecurityUser> _UserManager;
        private SignInManager<Security.SecurityUser> _SignInManager;
        private Security.SecurityContext _SecurityContext;
        private ContextoSubasta _ContextoSubasta;
        public AccountController(UserManager<Security.SecurityUser> usermanager, SignInManager<Security.SecurityUser> signinmanager, Security.SecurityContext securitycontext, ContextoSubasta contextosubasta)
        {
            
            _UserManager = usermanager;
            _SignInManager = signinmanager;
            _SecurityContext = securitycontext;
            _ContextoSubasta = contextosubasta;
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Security.SecurityLogin datos, string ReturnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(datos);
            }
            var resultado = await _SignInManager.PasswordSignInAsync(datos.Usuario, datos.Contraseña, false, false);
            if (resultado.Succeeded)
            {
                if(string.IsNullOrWhiteSpace(ReturnUrl))
                return Redirect("/");
                return Redirect(ReturnUrl);
            }
            else
            {
                ModelState.AddModelError("UserError", "Credenciales incorrectas");
            }
            return View(datos);
        }

        public IActionResult Register()
        {
            return View();
        }

    }
}
