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
   public class OfertaAPIController : ControllerBase
   {

      private readonly ContextoSubasta _contexto;

      public OfertaAPIController(ContextoSubasta context)
      {
         _contexto = context;
      }

      // GET: api/<SubastaProductoAPIController>
      [HttpGet]
      public IEnumerable<Oferta> Get()
      {
         return _contexto.Oferta.ToList();
      }
     
      // GET api/<SubastaProductoAPIController>/5
      [HttpGet("{id}")]
      public Oferta Get(int id)
      {
         return _contexto.Oferta.FirstOrDefault(x => x.IdOferta == id);
      }

      // PUT api/<SubastaProductoAPIController>/5
      


   }
}
