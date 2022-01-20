using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TPISubastas.AccesoDatos;
using TPISubastas.Dominio;

namespace TPISubastas.Sitio.Controllers
{
   [Route("api/[controller]")]
   [ApiController]
   [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
   public class UsuarioAPIController : ControllerBase
   {
      private readonly ContextoSubasta _contexto;
      public UsuarioAPIController(ContextoSubasta context)
      {
         _contexto = context;
      }

      [HttpGet]
      public Usuario Get(int id)
      {
         return _contexto.Usuario.FirstOrDefault(x => x.IdUsuario == id);
      }

      [HttpGet]
      public IEnumerable<Usuario> Get()
      {
         return _contexto.Usuario.ToList();
      }

   }
}
