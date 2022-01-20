using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TPISubastas.AccesoDatos;
using TPISubastas.Dominio;

namespace TPISubastas.Sitio.Controllers
{
   [Route("api/[controller]")]
   [ApiController]
   public class AccountAPIController : ControllerBase
   {
      private UserManager<Security.SecurityUser> _UserManager;
      private SignInManager<Security.SecurityUser> _SignInManager;
      private Security.SecurityContext _SecurityContext;
      private object usuario;
      private ContextoSubasta _ContextoSubasta;
      private string _Usuario;
      private string _Contraseña;
      public AccountAPIController(UserManager<Security.SecurityUser> usermanager, SignInManager<Security.SecurityUser> signinmanager, Security.SecurityContext securitycontext)
      {

         _UserManager = usermanager;
         _SignInManager = signinmanager;
         _SecurityContext = securitycontext;
      }    

     

   }
}
