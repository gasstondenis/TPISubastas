using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPISubastas.AccesoDatos;
using TPISubastas.Dominio;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TPISubastas.Sitio.Controllers
{
   [Route("api/[controller]")]
   [ApiController]
   [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
   public class SubastaAPIController : ControllerBase
   {
      private readonly ContextoSubasta _contexto;


      public SubastaAPIController(ContextoSubasta context)
      {
         _contexto = context;
      }

      // GET: api/<SubastaAPIController>
      [HttpGet]
      public IEnumerable<Subasta> Get()
      {
         return _contexto.Subasta.ToList();
      }

      // GET api/<SubastaAPIController>/5
      [HttpGet("{id}")]
      public Subasta Get(int id)
      {
         return _contexto.Subasta.FirstOrDefault(x => x.IdSubasta == id);
      }

      // POST api/<SubastaAPIController>
      [HttpPost]
      public void Post([FromBody] Subasta value)
      {
         _contexto.Subasta.Add(value);
         _contexto.SaveChanges();
      }

      // PUT api/<SubastaAPIController>/5
      [HttpPut("{id}")]
      public void Put(int id, [FromBody] Subasta value)
      {
         var original = _contexto.Subasta.FirstOrDefault(x => x.IdSubasta == id);
         if (original != null)
         {
            original.Descripcion = value.Descripcion;
            original.Duracion = value.Duracion;
            original.FechaCierre = value.FechaCierre;
            original.FechaCreacion = value.FechaCreacion;
            original.FechaInicio = value.FechaInicio;
            original.Habilitada = value.Habilitada;
            original.IdSubasta = value.IdSubasta;
            original.Nombre = value.Nombre;
            _contexto.Entry(original).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _contexto.SaveChanges();
         }
      }

      // DELETE api/<SubastaAPIController>/5
      [HttpDelete("{id}")]
      public void Delete(int id)
      {
         var original = _contexto.Subasta.FirstOrDefault(x => x.IdSubasta == id);

         if (original != null)
         {
            _contexto.Entry(original).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            _contexto.SaveChanges();
         }
      }
   }
}
