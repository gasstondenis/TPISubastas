using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPISubastas.AccesoDatos;
using TPISubastas.Dominio;

namespace TPISubastas.Sitio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class AccountAPIController : ControllerBase
    {
        private UserManager<Security.SecurityUser> _UserManager;
        private SignInManager<Security.SecurityUser> _SignInManager;
        private Security.SecurityContext _SecurityContext;
        private ContextoSubasta _ContextoSubasta;
        private string _Usuario;
        private string _Contraseña;        
        public AccountAPIController(UserManager<Security.SecurityUser> usermanager, SignInManager<Security.SecurityUser> signinmanager, Security.SecurityContext securitycontext, string usuario, string password)
        {
            
            _UserManager = usermanager;
            _SignInManager = signinmanager;
            _SecurityContext = securitycontext;
            _Usuario = usuario;
            _Contraseña = password;
        }


        [HttpGet]
        public async Task<bool> Get()
        {
           
            var resultado = await _SignInManager.PasswordSignInAsync(_Usuario, _Contraseña, false, false);
            if (resultado.Succeeded)
            {
                return true;
            }
            return false;
        }

        public async Task<IActionResult> Login(Security.SecurityLogin datos, string returnUrl)
        {


            if (!ModelState.IsValid)
            {
                return 
            }
            var resultado = await _SignInManager.PasswordSignInAsync(datos.Usuario, datos.Contraseña, false, false);
            if (resultado.Succeeded)
            {
                if (string.IsNullOrWhiteSpace(returnUrl))
                    return Redirect("/");
                return Redirect(returnUrl);
            }
            else
            {
                ModelState.AddModelError("UserError", "El usuario y/o la contraseña son erroneos");
            }
            return Accepted();
        }
    }
}
